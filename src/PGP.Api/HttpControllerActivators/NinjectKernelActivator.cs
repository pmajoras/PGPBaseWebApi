using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace PGP.Api.HttpControllerActivators
{
    /// <summary>
    /// 
    /// </summary>
    public class NinjectKernelActivator : IHttpControllerActivator
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectKernelActivator"/> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectKernelActivator(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </summary>
        /// <param name="request">The message request.</param>
        /// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>
        /// An <see cref="T:System.Web.Http.Controllers.IHttpController" /> object.
        /// </returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = (IHttpController)_kernel.Get(controllerType);
            request.RegisterForDispose(new Release(() => _kernel.Release(controller)));

            return controller;
        }

        /// <summary>
        /// Gets the kernel.
        /// </summary>
        /// <value>
        /// The kernel.
        /// </value>
        public IKernel Kernel
        {
            get
            {
                return _kernel;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class Release : IDisposable
    {
        private readonly Action _release;

        /// <summary>
        /// Initializes a new instance of the <see cref="Release"/> class.
        /// </summary>
        /// <param name="release">The release.</param>
        public Release(Action release)
        {
            _release = release;
        }

        public void Dispose()
        {
            _release();
        }
    }
}