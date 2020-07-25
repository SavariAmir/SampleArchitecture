using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models.Categories;

namespace ProductManagement.Persistence.EF.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);

            builder.OwnsOne(p => p.Image, image => { image.Property(i => i.Name); });
        }
    }
}