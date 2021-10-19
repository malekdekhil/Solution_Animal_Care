using AnimalCare.Data.TypeConfiguration;
using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalCare.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
            modelBuilder.ApplyConfiguration(new InformationForProMemberConfiguration());
        }
        public DbSet<User> TbUsers { get; set; }
        public DbSet<Event> TbEvents { get; set; }
        public DbSet<Event> TbRoles { get; set; }
        public DbSet<Speciality> TbSpecialities { get; set; }
        public DbSet<InformationForProMember> TbInformationForProMember { get; set; }

    }
}
