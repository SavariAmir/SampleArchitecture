using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models.Categories;

namespace ProductManagement.Persistence.EF.Configurations
{
    public class MainCategoryConfiguration : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.ToTable("MainCategories", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.SubCategories);

            builder.OwnsOne(p => p.Image, image => { image.Property(i => i.Name); });
        }
    }
}