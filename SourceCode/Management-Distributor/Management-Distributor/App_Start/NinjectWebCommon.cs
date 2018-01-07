[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Distributor.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Distributor.App_Start.NinjectWebCommon), "Stop")]

namespace Distributor.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Distributor.Service.Interfaces;
    using Distributor.Service.Implementations;
    using Distributor.Dao.Interfaces;
    using Distributor.Dao.Implementations;
    using NLog;
    using System.Data.Entity;
    using Management_Distributor.Service.Interfaces;
    using Management_Distributor.Service.Implementations;

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
            kernel.Bind<IUnitOfWork>().To<GenericUnitOfWork>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<IEmployeeService>().To<EmployeeService>();
            kernel.Bind<IDeparmentService>().To<DepartmentService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IOrderDetailService>().To<OrderDetailService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IRegionService>().To<RegionService>();
            kernel.Bind<IDistributorService>().To<DistributorService>();
            kernel.Bind<IUnitService>().To<UnitService>();
            kernel.Bind<IProductUnitService>().To<ProductUnitService>();
        }        
    }
}