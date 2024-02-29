using Ganzenbord.Business.Logger;

namespace Ganzenbord
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}