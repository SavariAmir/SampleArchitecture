using Anshan.Framework.Application.Command;
using Anshan.Framework.Core;
using Anshan.Framework.DI;
using Anshan.Framework.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Domain.Models.Categories;
using ProductManagement.Domain.Models.Dimensions;
using ProductManagement.Domain.Models.LeafCategories;
using ProductManagement.Domain.Models.Products;
using ProductManagement.Domain.Models.Specifications;
using ProductManagement.Persistence.EF;
using ProductManagement.Persistence.EF.Repositories;

namespace ProductManagement.Config
{
    public static class EFExtenstion
    {
        public static void AddEFService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductManagementContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfWork, EfUnitOfWork<ProductManagementContext>>();

            services.AddScoped<IServiceLocator, DotNetCoreServiceLocatorAdapter>();

            services.AddScoped<ICommandBus, CommandBus>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILeafCategoryRepository, LeafCategoryRepository>();

            services.AddScoped<ISpecificationRepository, SpecificationRepository>();

            services.AddScoped<IDimensionRepository, DimensionRepository>();
            services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();

            services.AddTransient(typeof(TransactionalCommandHandlerDecorator<>));
        }
    }
}