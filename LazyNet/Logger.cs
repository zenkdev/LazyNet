using System;
using System.Collections.Generic;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Dekart.LazyNet
{
    public static class Logger
    {
        static List<string> _logs;

        static List<string> Logs => _logs ?? (_logs = new List<string>());

        static string InitLogger(string logFileName = "DefaultLog")
        {
            if (Logs.Contains(logFileName)) return logFileName;

            Logs.Add(logFileName);

            var path = "Log\\" + logFileName + ".log";

            var hierarchy = (Hierarchy)LogManager.GetRepository();
            var log = (log4net.Repository.Hierarchy.Logger)hierarchy.GetLogger(logFileName);
            log.Level = Level.All;
            log.Additivity = true;

            var fileAppender = new RollingFileAppender
            {
                File = path,
                Layout = new PatternLayout("%d - %m%n"),
                ImmediateFlush = true,
                RollingStyle = RollingFileAppender.RollingMode.Size,
                MaximumFileSize = "10MB",
                AppendToFile = true,
                MaxSizeRollBackups = 10,
                Threshold = Level.All
            };
            fileAppender.ActivateOptions();
            fileAppender.LockingModel = new FileAppender.MinimalLock();

            log.AddAppender(fileAppender);

            hierarchy.Configured = true;

            return logFileName;
        }

        public static void Info(string info)
        {
            var logFileName = InitLogger();
            LogManager.GetLogger(logFileName).Info(info);
        }

        public static void Debug(string message, string category = "")
        {
            var logFileName = InitLogger();
            LogManager.GetLogger(logFileName).Debug((!string.IsNullOrWhiteSpace(category) ? category + " - " + message : message));
        }

        public static void Debug(object value, string category = "")
        {
            var logFileName = InitLogger();
            LogManager.GetLogger(logFileName).Debug((!string.IsNullOrWhiteSpace(category) ? category + " - " + value : value));
        }

        public static void Error(string message, Exception ex = null)
        {
            var logFileName = InitLogger();
            LogManager.GetLogger(logFileName).Error(message, ex);
        }
    }
}
