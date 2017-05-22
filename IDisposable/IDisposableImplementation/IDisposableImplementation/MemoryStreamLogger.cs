using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;

        public MemoryStreamLogger()
        {
            using (memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate))
            {
                using (streamWriter = new StreamWriter(memoryStream))
                {
                }
            }
        }

        public void Log(string message)
        {
            try
            {
                streamWriter.Write(message);
            }
            catch (IOException e)
            {

            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                }
            }
        }

   }
}