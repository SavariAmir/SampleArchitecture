using Anshan.Framework.Application;
using Anshan.Framework.Core;
using Anshan.Framework.Core.Events;
using Anshan.Framework.DI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Products;
using ProductManagement.Config.Bus;
using ProductManagement.Interface.Facade.Contracts;
using ProductManagement.Interface.Facade.Query;

namespace ProductManagement.Config
{
    public static class CoreExtension
    {
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServiceLocator, DotNetCoreServiceLocatorAdapter>();

            //services.AddScoped<IMyCommandBus, MyCommandBus>();

            services.AddScoped<ICategoryQueryFacade, CategoryQueryFacade>();
            services.AddScoped<IDimensionQueryFacade, DimensionQueryFacade>();
            services.AddScoped<ISpecificationQueryFacade, SpecificationQueryFacade>();
            services.AddScoped<IProductQueryFacade, ProductQueryFacade>();

            services.AddTransient(typeof(CommandHandler<>));

            services.AddHandlers<CreateProductCommandHandler>();

            var eventAggregator = new EventAggregator();
            services.AddSingleton<IEventListener>(eventAggregator);
            services.AddSingleton<IEventPublisher>(eventAggregator);
        }
    }
}