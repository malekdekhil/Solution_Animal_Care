using Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCare.Data.TypeConfiguration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TbUsers");
            builder.HasKey(k => k.IdUser);
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Username).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.PasswordHash);
            builder.Property(p => p.PasswordSalt);
            builder.Property(p => p.City);
            builder.Property(p => p.Address);
            builder.Property(p => p.StreetInfo);
            builder.Property(p => p.ZipCode);
        }
    }
}
