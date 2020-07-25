using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models.Products;

namespace ProductManagement.Persistence.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);

            ProductColorVarieties(builder);

            ProductDimension(builder);

            ProductOverview(builder);

            ProductSpecification(builder);

            ProductVideo(builder);
        }

        private static void ProductVideo(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(p => p.ProductVideo, video => { video.Property(v => v.ProductVideoLink); });
        }

        private static void ProductColorVarieties(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsMany(e => e.ProductColorVarieties, eb =>
            {
                eb.WithOwner().HasForeignKey("ProductId");

                eb.OwnsOne(p => p.ColorImage, pi => { pi.Property(p => p.Name); });

                eb.Property(p => p.ProductImageType);
                eb.Property(p => p.ColorType);
                eb.OwnsOne(p => p.ProductPrice, pi =>
                {
                    pi.OwnsOne(p => p.Amount, amount =>
                    {
                        amount.Property(p => p.Value).HasColumnName("Amount");
                    });
                    pi.OwnsOne(p => p.DiscountAmount, amount =>
                    {
                        amount.Property(p => p.Value).HasColumnName("DiscountAmount");
                    });
                    pi.OwnsOne(p => p.DueAmount, amount =>
                    {
                        amount.Property(p => p.Value).HasColumnName("DueAmount"); ;
                    });
                });

                eb.OwnsMany(p => p.Images, images =>
                {
                    eb.WithOwner().HasForeignKey("ProductId");
                    images.Property(p => p.Name);

                    images.ToTable("ProductColorVarietyImages", ProductManagementContext.DefaultSchema);
                    images.Property<int>("Id");
                    images.HasKey("Id");
                });

                eb.Property(p => p.ProductImageType);
                eb.ToTable("ProductColorVarieties", ProductManagementContext.DefaultSchema);
                eb.Property<int>("Id");
                eb.HasKey("Id");
            });
        }

        private static void ProductDimension(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(e => e.ProductDimension, eb =>
            {
                eb.Property(p => p.Description);
                eb.OwnsOne(p => p.Image, pi => { pi.Property(p => p.Name); });
                eb.OwnsMany(p => p.ProductDimensionItemValues, pb =>
                {
                    pb.WithOwner().HasForeignKey("ProductId");

                    pb.Property(cm => cm.DimensionItemId);
                    pb.Property(cm => cm.Value);

                    pb.ToTable("ProductDimensionItemValues", ProductManagementContext.DefaultSchema);
                    pb.Property<int>("Id");
                    pb.HasKey("Id");
                });
            });
        }

        private static void ProductOverview(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(e => e.Overview, eb =>
            {
                eb.Property(p => p.Description);
                eb.Property(p => p.AtAGlance);
            });
        }

        private static void ProductSpecification(EntityTypeBuilder<Product> builder)
        {
            builder.OwnsOne(e => e.ProductSpecification, eb =>
            {
                eb.Property(p => p.Description);
                eb.OwnsMany(p => p.ProductSpecificationValues, pb =>
                {
                    pb.WithOwner().HasForeignKey("ProductId");

                    pb.Property(cm => cm.SpecificationItemId);
                    pb.Property(cm => cm.Value);

                    pb.ToTable("ProductSpecificationValues", ProductManagementContext.DefaultSchema);
                    pb.Property<int>("Id");
                    pb.HasKey("Id");
                });
            });
        }
    }
}