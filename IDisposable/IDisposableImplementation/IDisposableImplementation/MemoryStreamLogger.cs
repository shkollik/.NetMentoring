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
            if (streamWriter != null)
            {
                streamWriter.Dispose();
                streamWriter = null; 
            }

            GC.SuppressFinalize(this);
        }

        ~MemoryStreamLogger()
        {
            Dispose();
        }


    }
}
