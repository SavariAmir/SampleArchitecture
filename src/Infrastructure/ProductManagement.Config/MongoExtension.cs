using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProductManagement.Domain.Models.Products;
using ProductManagement.Persistence.Mongo;

namespace ProductManagement.Config
{
    public static class MongoExtension
    {
        public static void AddMongoService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<ProductManagementDatabaseSettings>(Configuration.GetSection(nameof(ProductManagementDatabaseSettings)));

            services.AddSingleton<IProductManagementDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProductManagementDatabaseSettings>>().Value);

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IDbContext, DbContext>();

            MapClass.Map();
        }
    }
}