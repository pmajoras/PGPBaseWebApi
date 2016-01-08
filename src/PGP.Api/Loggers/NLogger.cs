using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Tracing;
using NLog;
using System.Text;
using PGP.Infrastructure.Framework.WebApi.Extensions;

namespace PGP.Api.Loggers
{
    public sealed class NLogger : IApiTracer
    {

        #region Private member variables.

        /// <summary>
        /// The NLogger class that is used to log the message.
        /// </summary>
        private static readonly Logger s_classLogger = LogManager.GetCurrentClassLogger();

        private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> s_loggingMap = new Lazy<Dictionary<TraceLevel,
            Action<string>>>(() => new Dictionary<TraceLevel, Action<string>>
            {
                { TraceLevel.Info, s_classLogger.Info },
                { TraceLevel.Debug, s_classLogger.Debug },
                { TraceLevel.Error, s_classLogger.Error },
                { TraceLevel.Fatal, s_classLogger.Fatal },
                { TraceLevel.Warn, s_classLogger.Warn } }
            );

        #endregion

        #region Private properties.

        /// <summary>
        /// Get property for Logger
        /// </summary>
        private Dictionary<TraceLevel, Action<string>> m_logger
        {
            get { return s_loggingMap.Value; }
        }

        #endregion

        #region Public member methods.

        /// <summary>
        /// Invokes the specified traceAction to allow setting values in a new <see cref="T:System.Web.Http.Tracing.TraceRecord" /> if and only if tracing is permitted at the given category and level.
        /// </summary>
        /// <param name="request">The current <see cref="T:System.Net.Http.HttpRequestMessage" />.   It may be null but doing so will prevent subsequent trace analysis  from correlating the trace to a particular request.</param>
        /// <param name="category">The logical category for the trace.  Users can define their own.</param>
        /// <param name="level">The <see cref="T:System.Web.Http.Tracing.TraceLevel" /> at which to write this trace.</param>
        /// <param name="traceAction">The action to invoke if tracing is enabled.  The caller is expected to fill in the fields of the given <see cref="T:System.Web.Http.Tracing.TraceRecord" /> in this action.</param>
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                if (traceAction != null && traceAction.Target != null)
                {
                    category = category + Environment.NewLine + "Action Parameters : " + traceAction.Target.ToJSON();
                }

                var record = new TraceRecord(request, category, level);

                if (traceAction != null) traceAction(record);
                Log(record);
            }
        }
        #endregion

        #region Private member methods.

        /// <summary>
        /// Logs info/Error to Log file
        /// </summary>
        /// <param name="record"></param>
        private void Log(TraceRecord record)
        {
            var message = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append("").Append(record.Message + Environment.NewLine);

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                {
                    message.Append("Method: " + record.Request.Method + Environment.NewLine);
                }

                if (record.Request.RequestUri != null)
                {
                    message.Append("").Append("URL: " + record.Request.RequestUri + Environment.NewLine);
                }

                if (record.Request.Headers != null &&
                    record.Request.Headers.Contains("Token") &&
                    record.Request.Headers.GetValues("Token") != null &&
                    record.Request.Headers.GetValues("Token").FirstOrDefault() != null)
                {
                    message.Append("").Append("Token: " + record.Request.Headers.GetValues("Token").FirstOrDefault() + Environment.NewLine);
                }
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append("").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);


            s_classLogger.Log(GetLogLevel(record.Level), Convert.ToString(message) + Environment.NewLine);
        }

        /// <summary>
        /// Gets the log level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns></returns>
        private LogLevel GetLogLevel(TraceLevel level)
        {
            LogLevel returnLogLevel = null;
            switch (level)
            {
                case TraceLevel.Debug:
                    returnLogLevel = LogLevel.Debug;
                    break;
                case TraceLevel.Info:
                    returnLogLevel = LogLevel.Info;
                    break;
                case TraceLevel.Warn:
                    returnLogLevel = LogLevel.Warn;
                    break;
                case TraceLevel.Error:
                    returnLogLevel = LogLevel.Error;
                    break;
                case TraceLevel.Fatal:
                    returnLogLevel = LogLevel.Fatal;
                    break;
                case TraceLevel.Off:
                    returnLogLevel = LogLevel.Off;
                    break;
            }

            return returnLogLevel;
        }

        #endregion
    }
}