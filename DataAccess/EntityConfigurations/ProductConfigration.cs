using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.HasQueryFilter(p => p.IsDeleted);
            builder.Property(x=>x.Price).IsRequired();
            builder.HasOne(x => x.Category);
        }
    }
}