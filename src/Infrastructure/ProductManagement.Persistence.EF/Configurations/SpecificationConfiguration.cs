using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Models.Specifications;

namespace ProductManagement.Persistence.EF.Configurations
{
    public class SpecificationConfiguration : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.ToTable("Specifications", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.SpecificationGroups);
        }
    }

    public class SpecificationGroupConfiguration : IEntityTypeConfiguration<SpecificationGroup>
    {
        public void Configure(EntityTypeBuilder<SpecificationGroup> builder)
        {
            builder.ToTable("SpecificationGroups", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.SpecificationItems);
        }
    }

    public class SpecificationItemConfiguration : IEntityTypeConfiguration<SpecificationItem>
    {
        public void Configure(EntityTypeBuilder<SpecificationItem> builder)
        {
            builder.ToTable("SpecificationItems", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
            builder.HasMany(o => o.SpecificationItemOptions);
        }
    }

    public class SpecificationItemOptionConfiguration : IEntityTypeConfiguration<SpecificationItemOption>
    {
        public void Configure(EntityTypeBuilder<SpecificationItemOption> builder)
        {
            builder.ToTable("SpecificationItemsOptions", ProductManagementContext.DefaultSchema);
            builder.HasKey(o => o.Id);
        }
    }
}