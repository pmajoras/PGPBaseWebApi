using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.DomainHelpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class DomainMessageHelper
    {
        /// <summary>
        /// The s_message handler
        /// </summary>
        private static IMessageHandler s_messageHandler;

        /// <summary>
        /// Gets or sets the message handler.
        /// </summary>
        /// <value>
        /// The message handler.
        /// </value>
        public static IMessageHandler MessageHandler
        {
            get
            {
                if (s_messageHandler == null)
                {
                    throw new InvalidOperationException("The MessageHandler is not initialized");
                }

                return s_messageHandler;
            }
            set
            {
                s_messageHandler = value;
            }
        }
    }
}
