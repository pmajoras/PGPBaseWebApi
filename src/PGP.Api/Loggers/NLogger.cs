using System;
using System.Text;
using NLog;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;

namespace PGP.Api.Loggers
{
    /// <summary>
    /// The class that will log the messages using Nlog
    /// </summary>
    public abstract class NLogger : IPGPLogger
    {
        /// <summary>
        /// The NLogger class that is used to log the message.
        /// </summary>
        protected abstract Logger m_classLogger { get; set; }

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NLogger"/> class.
        /// </summary>
        public NLogger()
        {
        }

        #endregion Constructors

        #region Interface Methods

        /// <summary>
        /// Logs a Debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            Log(LogLevel.Debug, message);
        }

        /// <summary>
        /// Logs an Information message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Info(string message)
        {
            Log(LogLevel.Info, message);
        }

        /// <summary>
        /// Logs an errors message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Error(string message)
        {
            Log(LogLevel.Error, message);
        }

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Warning(string message)
        {
            Log(LogLevel.Warn, message);
        }

        /// <summary>
        /// Logs a fatal error message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(string message)
        {
            Log(LogLevel.Fatal, message);
        }

        /// <summary>
        /// Traces the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Trace(string message)
        {
            Log(LogLevel.Trace, message);
        }

        #endregion Interface Methods

        #region Private Methods

        /// <summary>
        /// Logs the specified log level.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        /// <param name="message">The message.</param>
        private void Log(LogLevel logLevel, string message)
        {
            if (message == null)
            {
                message = string.Empty;
            }

            if (m_classLogger == null)
            {
                m_classLogger = LogManager.GetCurrentClassLogger();
            }

            m_classLogger.Log(logLevel, message);
        }

        #endregion Private Methods
    }
}