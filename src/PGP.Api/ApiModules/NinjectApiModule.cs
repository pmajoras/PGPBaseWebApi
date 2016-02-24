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
using PGP.Infrastructure.Repositories.EF.Repositories.Users;
using PGP.Domain.Users;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;
using PGP.Api.Services.Accounts;
using PGP.Api.Services;
using Ninject.Web.Common;
using System.Web;
using PGP.Domain.Boards;
using PGP.Infrastructure.Repositories.EF.Repositories.Boards;

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
            Kernel.Bind<IDomainContext>().To<EFBaseContext>().InRequestScope();
            Kernel.Bind<IUnitOfWork>().To<PGPUnitOfWork>().InRequestScope();

            RegisterRepositories();
            RegisterServices();
            RegisterApiServices();
        }

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        private void RegisterRepositories()
        {
            Kernel.Bind<ITaskListRepository>().To<TaskListRepository>().InRequestScope();
            Kernel.Bind<ITaskRepository>().To<TaskRepository>().InRequestScope();
            Kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            Kernel.Bind<IBoardRepository>().To<BoardRepository>().InRequestScope();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterServices()
        {
            Kernel.Bind<ITaskListService>().To<TaskListService>().InRequestScope();
            Kernel.Bind<ITaskService>().To<TaskService>().InRequestScope();
            Kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            Kernel.Bind<IBoardService>().To<BoardService>().InRequestScope();
        }

        private void RegisterApiServices()
        {
            Kernel.Bind<ITokenService>().To<JWTService>().InRequestScope();
            Kernel.Bind<IAuthenticationService>().To<AuthenticationService>().InRequestScope();
        }
    }
}