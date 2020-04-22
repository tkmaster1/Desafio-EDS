[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EDS.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EDS.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace EDS.MVC.App_Start
{
    using EDS.Application.Interfaces;
    using EDS.Application.Interfaces.Base;
    using EDS.Application.Services;
    using EDS.Application.Services.Base;
    using EDS.Domain.Interfaces.Repository;
    using EDS.Domain.Interfaces.Repository.Base;
    using EDS.Domain.Interfaces.Services;
    using EDS.Domain.Interfaces.Services.Base;
    using EDS.Domain.Services;
    using EDS.Domain.Services.Base;
    using EDS.Infrastructure.Data.Repositories;
    using EDS.Infrastructure.Data.Repositories.Base;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // 1 - Application
            kernel.Bind(typeof(IApplicationServiceBase<>)).To(typeof(ApplicationServiceBase<>));
            kernel.Bind<IAssuntoApplicationService>().To<AssuntoApplicationService>();
            kernel.Bind<IAutorApplicationService>().To<AutorApplicationService>();
            kernel.Bind<ILivroApplicationService>().To<LivroApplicationService>();
            kernel.Bind<ILivroAssuntoApplicationService>().To<LivroAssuntoApplicationService>();
            kernel.Bind<ILivroAutorApplicationService>().To<LivroAutorApplicationService>();

            // 2 - Domain
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IAssuntoService>().To<AssuntoService>();
            kernel.Bind<IAutorService>().To<AutorService>();
            kernel.Bind<ILivroService>().To<LivroService>();
            kernel.Bind<ILivroAssuntoService>().To<LivroAssuntoService>();
            kernel.Bind<ILivroAutorService>().To<LivroAutorService>();

            // 3 - Infrastructure.Data
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IAssuntoRepository>().To<AssuntoRepository>();
            kernel.Bind<IAutorRepository>().To<AutorRepository>();
            kernel.Bind<ILivroAssuntoRepository>().To<LivroAssuntoRepository>();
            kernel.Bind<ILivroAutorRepository>().To<LivroAutorRepository>();
            kernel.Bind<ILivroRepository>().To<LivroRepository>();

            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
