using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PGP.Api.ApiMessageHandlers;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using PGP.Api.App_Start;
using PGP.Infrastructure.Framework.Repositories;
using System.Web.Http;
using PGP.Api.HttpControllerActivators;
using Ninject;

namespace PGP.Api.Controllers
{
    public class ApiControllerBase : PGPApiController
    {
        protected IMessageHandler m_messageHandler = new MessageHandler();

        /// <summary>
        /// The current authentication token
        /// </summary>
        public AuthenticationToken CurrentAuthToken;

        protected void Commit()
        {
            var activator = GlobalConfiguration.Configuration.Services.GetHttpControllerActivator() as NinjectKernelActivator;
            if (activator != null)
            {
                var unitOfWork = activator.Kernel.Get<IUnitOfWork>();
                if (unitOfWork == null)
                {
                    throw new InvalidOperationException("The UnitOfWork is not being used in this method");
                }

                unitOfWork.Commit();
            }
        }
    }
}