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
using System.Web.Http.Dependencies;
using Ninject.Modules;
using System.Reflection;
using Ninject.Syntax;
using System.Diagnostics.Contracts;

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
            var ninjectKernelActivator = new NinjectKernelActivator(new StandardKernel(new NinjectApiModule()));
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                ninjectKernelActivator);
        }
    }
}