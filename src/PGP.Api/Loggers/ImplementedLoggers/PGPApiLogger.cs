using NLog;

namespace PGP.Api.Loggers.ImplementedLoggers
{
    /// <summary>
    ///
    /// </summary>
    public class PGPApiLogger : NLogger
    {
        #region Private Members

        private Logger m_logger = LogManager.GetCurrentClassLogger();

        #endregion Private Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PGPApiLogger"/> class.
        /// </summary>
        public PGPApiLogger()
        {
            if (m_classLogger == null)
            {
                m_classLogger = LogManager.GetCurrentClassLogger();
            }
        }

        #endregion Constructors

        /// <summary>
        /// Gets or sets the m_class logger.
        /// </summary>
        /// <value>
        /// The m_class logger.
        /// </value>
        protected override Logger m_classLogger
        {
            get
            {
                return m_logger;
            }
            set
            {
                return;
            }
        }
    }
}