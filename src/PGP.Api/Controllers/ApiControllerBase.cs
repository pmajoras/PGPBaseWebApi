using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PGP.Api.ApiMessageHandlers;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;
using PGP.Infrastructure.Framework.WebApi.Controllers;

namespace PGP.Api.Controllers
{
    public class ApiControllerBase : PGPApiController
    {
        protected IMessageHandler m_messageHandler = new MessageHandler();

        /// <summary>
        /// The current authentication token
        /// </summary>
        public AuthenticationToken CurrentAuthToken;
    }
}