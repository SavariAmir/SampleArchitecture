using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models.LeafCategories;

namespace ProductManagement.Persistence.EF.Configurations
{
    public class LeafCategoryConfiguration : IEntityTypeConfiguration<LeafCategory>
    {
        public void Configure(EntityTypeBuilder<LeafCategory> builder)
        {
            builder.ToTable("LeafCategories", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);

            builder.OwnsOne(p => p.Image, image => { image.Property(i => i.Name); });
        }
    }
}