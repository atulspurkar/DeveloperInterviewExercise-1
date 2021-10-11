using System;

namespace LoggerLib
{
    public class Logger : ILogger
    {
        private readonly ConsoleColor _originalColor;
        public Logger()
        {
            _originalColor = Console.ForegroundColor;
        }
        public void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: {0}", msg);
            Console.ForegroundColor = _originalColor;

        }

        public void LogInfo(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Info: {0}", msg);
            Console.ForegroundColor = _originalColor;
        }

        public void LogSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success: {0}", msg);
            Console.ForegroundColor = _originalColor;
        }

        public void LogFailure(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Fail: {0}", msg);
            Console.ForegroundColor = _originalColor;
        }
    }

    public interface ILogger
    {
        void LogInfo(string msg);
        void LogError(string msg);
        void LogSuccess(string msg);
        void LogFailure(string msg);
    }
}
