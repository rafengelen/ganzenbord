
using Ganzenbord.Business.Logger;

namespace Ganzenbord
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
        public string Input(string message)
        {
            Log(message);
            return Console.ReadLine();
        }
    }
}