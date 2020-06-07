using System;
using System.IO;
using System.Reflection;
using System.Xml;
using log4net;
using log4net.Config;

namespace TestApi.Providers
{
    public interface ILoggerManager
    {
        void LogInformation(string message);
    }

    public class LoggerManager : ILoggerManager
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));

        public LoggerManager()
        {
            try
            {
                XmlDocument log4netConfig = new XmlDocument();

                using (var fs = File.OpenRead("log4net.config"))
                {
                    log4netConfig.Load(fs);
                    var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
                    XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
                    _logger.Info("Log System Initialized");
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error", ex);
            }
        }
        public void LogInformation(string message)
        {
            _logger.Info(message);
        }
    }
}