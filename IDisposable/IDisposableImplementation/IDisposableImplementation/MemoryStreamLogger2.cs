using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger2
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger2()
        {
            memoryStream = new FileStream(@"D:\.NET MENTORING PROGRSM\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
            try
            {
                streamWriter.Write(message);
            }
            finally
            {
                streamWriter.Dispose();
            }
        }
   }
}