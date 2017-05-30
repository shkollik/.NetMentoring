using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentoring
{
    class MemoryStreamLogger : IDisposable
    {
        // Track whether Dispose has been called.
        private bool disposed = false;

        private FileStream memoryStream;
        private StreamWriter streamWriter;
        public MemoryStreamLogger()
        {
            memoryStream = new FileStream(@"D:\.NET MENTORING PROGRSM\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
            if (streamWriter == null) return;

            streamWriter.Write(message);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // free managed resources
                    if(streamWriter != null)
                    {
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                }

                //free native resources if there are any

                // Note that disposing has been done.
                disposed = true;
            }
        }

        ~MemoryStreamLogger()
        {
            Dispose(false);
        }
    }
}
