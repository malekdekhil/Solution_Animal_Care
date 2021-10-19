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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("TbEvents");
            builder.HasKey(a => a.IdEvent);
            builder.Property(a => a.Status);
            builder.Property(a => a.DateEvent).IsRequired();
            builder.HasOne(a => a.User).WithMany(a => a.Events).HasForeignKey(fk => fk.UserId_FK);
          }
    }
}
