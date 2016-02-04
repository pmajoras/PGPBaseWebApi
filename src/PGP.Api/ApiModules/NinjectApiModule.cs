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
            Bind<IDomainContext>().ToMethod((c) => new EFBaseContext()).InRequestScope();
            Bind<IUnitOfWork>().ToMethod((c) => new PGPUnitOfWork(Kernel.Get<IDomainContext>()))
                .InRequestScope();

            RegisterRepositories();
            RegisterServices();
            RegisterApiServices();
        }

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        private void RegisterRepositories()
        {
            Bind<ITaskListRepository>().To<TaskListRepository>().InRequestScope();
            Bind<ITaskRepository>().To<TaskRepository>().InRequestScope();
            Bind<IUserRepository>().ToMethod((c) => new UserRepository(Kernel.Get<IDomainContext>())).InRequestScope();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterServices()
        {
            Bind<ITaskListService>().To<TaskListService>().InRequestScope();
            Bind<ITaskService>().To<TaskService>().InRequestScope();
            Bind<IUserService>().ToMethod((c) => new UserService(Kernel.Get<IUnitOfWork>(), Kernel.Get<IUserRepository>())).InRequestScope();
        }

        private void RegisterApiServices()
        {
            Bind<ITokenService>().To<JWTService>().InRequestScope();
            Bind<IAuthenticationService>().To<AuthenticationService>().InRequestScope();
            Bind<AccountsController>().ToMethod((c) =>
            {
                var domainContext = new EFBaseContext();
                var service = new UserService(new PGPUnitOfWork(domainContext), new UserRepository(domainContext));
                return new AccountsController(new AuthenticationService(new JWTService(), service));
            });
        }
    }
}