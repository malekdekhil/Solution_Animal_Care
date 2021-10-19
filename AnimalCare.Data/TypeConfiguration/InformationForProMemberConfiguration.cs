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
    class InformationForProMemberConfiguration: IEntityTypeConfiguration<InformationForProMember>
    {
        
        public void Configure(EntityTypeBuilder<InformationForProMember> builder)
        {
            builder.ToTable("TbInformationForProMember");
            builder.HasKey(a => a.IdInfoProMember);
            builder.Property(a => a.Siret);
            builder.Property(a => a.isValidSubscribe);
            builder.HasOne(a => a.User).WithMany(a => a.ListInfoProMember).HasForeignKey(a => a.UserId_Fk);
        }
         
    }
}
