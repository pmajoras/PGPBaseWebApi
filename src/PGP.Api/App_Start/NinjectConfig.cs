using Ninject;
using PGP.Api.ApiModules;
using PGP.Api.HttpControllerActivators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Ninject.Web.Common;

namespace PGP.Api.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public static class NinjectConfig
    {
        /// <summary>
        /// Setups the ninject.
        /// </summary>
        public static void SetupNinject()
        {
            IKernel kernel = new StandardKernel(new NinjectApiModule());
            var ninjectKernelActivator = new NinjectKernelActivator(kernel);
        
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                ninjectKernelActivator);
        }
    }
}