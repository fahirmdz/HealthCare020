using Healthcare020.LoggerService.Interfaces;
using NLog;

namespace Healthcare020.LoggerService.Services
{
    public class LoggerManager:ILoggerManager
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);

        }

        public void LogDebug(string message)
        {
            logger.Debug(message);

        }

        public void LogError(string message)
        {
            logger.Error(message);

        }
    }
}