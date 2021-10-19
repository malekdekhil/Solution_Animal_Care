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
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("TbSpetialities");
            builder.HasKey(a => a.IdSpeciality);
            builder.Property(a => a.Name);
            builder.HasOne(a => a.User).WithMany(a => a.Specialities).HasForeignKey(a => a.IdUser_FK);
        }
    }
}
