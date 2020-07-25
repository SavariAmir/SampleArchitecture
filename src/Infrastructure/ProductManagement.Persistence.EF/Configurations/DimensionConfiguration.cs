using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models.Dimensions;

namespace ProductManagement.Persistence.EF.Configurations
{
    public class DimensionConfiguration : IEntityTypeConfiguration<Dimension>
    {
        public void Configure(EntityTypeBuilder<Dimension> builder)
        {
            builder.ToTable("Dimensions", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.DimensionGroups);
        }
    }

    public class DimensionGroupConfiguration : IEntityTypeConfiguration<DimensionGroup>
    {
        public void Configure(EntityTypeBuilder<DimensionGroup> builder)
        {
            builder.ToTable("DimensionGroups", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.DimensionItems);
        }
    }

    public class DimensionItemConfiguration : IEntityTypeConfiguration<DimensionItem>
    {
        public void Configure(EntityTypeBuilder<DimensionItem> builder)
        {
            builder.ToTable("DimensionItems", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
        }
    }
}