﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Convestudo.Unmanaged
{
    public class FileWriter: IFileWriter, IDisposable
    {
        // Pointer to an external unmanaged resource.
        private IntPtr _fileHandle;

        /// <summary>
        /// Creates file
        /// <see cref="http://msdn.microsoft.com/en-us/library/windows/desktop/aa363858(v=vs.85).aspx"/>
        /// </summary>
        /// <param name="lpFileName"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="dwShareMode"></param>
        /// <param name="lpSecurityAttributes"></param>
        /// <param name="dwCreationDisposition"></param>
        /// <param name="dwFlagsAndAttributes"></param>
        /// <param name="hTemplateFile"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr CreateFile(string lpFileName, DesiredAccess dwDesiredAccess, ShareMode dwShareMode, IntPtr lpSecurityAttributes, CreationDisposition dwCreationDisposition, FlagsAndAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

        /// <summary>
        /// Writes data into a file
        /// </summary>
        /// <param name="hFile"></param>
        /// <param name="aBuffer"></param>
        /// <param name="cbToWrite"></param>
        /// <param name="cbThatWereWritten"></param>
        /// <param name="pOverlapped"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteFile(IntPtr hFile, Byte[] aBuffer, UInt32 cbToWrite, ref UInt32 cbThatWereWritten, IntPtr pOverlapped);

        private void ThrowLastWin32Err()
        {
            var error = Marshal.GetHRForLastWin32Error();
            // if file is open do not throw the exception
            if ((error & 0xffff) != 0 && (error & 0xffff) != 183)
            {
                Marshal.ThrowExceptionForHR(error);
            }
        }

        public FileWriter(string fileName)
        {
            _fileHandle = CreateFile(
                fileName,
                DesiredAccess.Write,
                ShareMode.None, 
                IntPtr.Zero, 
                CreationDisposition.CreateAlways,
                FlagsAndAttributes.Normal,
                IntPtr.Zero);

            ThrowLastWin32Err();
        }

        public void Write(string str)
        {
            if (_fileHandle == IntPtr.Zero)
            {
                throw new InvalidOperationException("file is already closed");
            }
            var bytes = GetBytes(str);
            uint bytesWritten = 0;
            WriteFile(_fileHandle, bytes, (uint) bytes.Length, ref bytesWritten, IntPtr.Zero);
        }

        public void WriteLine(string str)
        {
            Write(String.Format("{0}{1}", str, Environment.NewLine));
        }

        /// <summary>
        /// Converts string to byte array
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static byte[] GetBytes(string str)
        {
            var bytes = Encoding.ASCII.GetBytes(str);
            return bytes;
        }

        public void Dispose()
        {
            // Clean up
            if (_fileHandle != IntPtr.Zero)
            {
                CloseHandle(_fileHandle);
                _fileHandle = IntPtr.Zero; 
            }

            GC.SuppressFinalize(this);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32", SetLastError = true)]
        private extern static bool CloseHandle(IntPtr handle);

        ~FileWriter()
        {
            Dispose();
        }

    }
}