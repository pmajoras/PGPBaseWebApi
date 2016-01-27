using Ninject;
using Ninject.Modules;
using PGP.Api.Controllers;
using PGP.Domain.TaskLists;
using PGP.Domain.Tasks;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Repositories.EF;
using PGP.Infrastructure.Repositories.EF.Repositories.TaskLists;
using PGP.Infrastructure.Repositories.EF.Repositories.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGP.Api.ApiModules
{
    /// <summary>
    /// 
    /// </summary>
    public class NinjectApiModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IDomainContext>().To<EFBaseContext>();
            Bind<IUnitOfWork>().To<PGPUnitOfWork>();

            RegisterRepositories();
            RegisterServices();
        }

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        private void RegisterRepositories()
        {
            Bind<ITaskListRepository>().To<TaskListRepository>();
            Bind<ITaskRepository>().To<TaskRepository>();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterServices()
        {
            Bind<ITaskListService>().To<TaskListService>();
            Bind<ITaskService>().To<TaskService>();
        }
    }
}