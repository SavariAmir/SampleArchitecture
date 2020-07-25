using Anshan.Framework.EF;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Models.Categories;
using ProductManagement.Domain.Models.Dimensions;
using ProductManagement.Domain.Models.LeafCategories;
using ProductManagement.Domain.Models.Products;
using ProductManagement.Domain.Models.Specifications;
using ProductManagement.Persistence.EF.Configurations;

namespace ProductManagement.Persistence.EF
{
    public class ProductManagementContext : CoreDbContext
    {
        public const string DefaultSchema = "ProductManagement";

        public ProductManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Dimension> Dimensions { set; get; }
        public DbSet<Specification> Specifications { set; get; }
        public DbSet<DimensionGroup> DimensionGroups { set; get; }
        public DbSet<DimensionItem> DimensionItems { set; get; }
        public DbSet<LeafCategory> LeafCategories { set; get; }
        public DbSet<MainCategory> MainCategories { set; get; }
        public DbSet<Category> Categories { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        }
    }
}