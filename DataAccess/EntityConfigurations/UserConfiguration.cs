using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Gender).HasMaxLength(1).IsFixedLength(true).IsRequired();
            builder.Property(x => x.TcNo).HasMaxLength(11).IsFixedLength(true).IsRequired();
            builder.Property(x => x.PhoneNumber).HasMaxLength(10).IsFixedLength(true).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasIndex(x => x.Id);
            builder.HasIndex(x => x.PhoneNumber);
            builder.HasQueryFilter(x => x.IsDeleted);
        }
    }
}