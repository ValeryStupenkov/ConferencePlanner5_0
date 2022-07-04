using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ConferencePlanner5._0
{
    public class FileLogger : ILogger
    {
        private string filepath;
        private static object _lock = new object();
        public FileLogger(string path)
        {
            filepath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    File.AppendAllText(filepath, formatter(state, exception) + Environment.NewLine);
                }
            }
        }
    }
}
