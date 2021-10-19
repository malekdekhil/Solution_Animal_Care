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
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("TbRoles");
            builder.HasKey(a => a.IdRole);
            builder.Property(a => a.RoleName);
            builder.Property(a => a.RoleName);
            builder.HasOne(a => a.User).WithMany(a => a.Roles).HasForeignKey(a => a.RoleId_FK);
        }
    }
}
