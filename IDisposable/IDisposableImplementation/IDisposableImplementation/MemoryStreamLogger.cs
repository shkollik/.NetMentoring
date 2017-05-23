using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger()
        {
            memoryStream = new FileStream(@"D:\.NET MENTORING PROGRSM\log.txt", FileMode.OpenOrCreate);
        }

        public void Log(string message)
        {
            using(streamWriter = new StreamWriter(memoryStream))
            {
                streamWriter.Write(message);
            }
        }

   }
}