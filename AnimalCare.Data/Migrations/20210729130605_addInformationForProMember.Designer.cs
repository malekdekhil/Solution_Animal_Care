﻿// <auto-generated />
using System;
using AnimalCare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimalCare.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210729130605_addInformationForProMember")]
    partial class addInformationForProMember
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domains.Event", b =>
                {
                    b.Property<int>("IdEvent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEvent")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId_FK")
                        .HasColumnType("int");

                    b.HasKey("IdEvent");

                    b.HasIndex("UserId_FK");

                    b.ToTable("TbEvents");
                });

            modelBuilder.Entity("Domains.InformationForProMember", b =>
                {
                    b.Property<int>("IdInfoProMember")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActiveSubscribe")
                        .HasColumnType("datetime2");

                    b.Property<string>("Siret")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId_Fk")
                        .HasColumnType("int");

                    b.Property<bool>("isValidSubscribe")
                        .HasColumnType("bit");

                    b.HasKey("IdInfoProMember");

                    b.HasIndex("UserId_Fk");

                    b.ToTable("TbInformationForProMember");
                });

            modelBuilder.Entity("Domains.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId_FK")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdRole");

                    b.HasIndex("RoleId_FK");

                    b.ToTable("TbRoles");
                });

            modelBuilder.Entity("Domains.Speciality", b =>
                {
                    b.Property<int>("IdSpeciality")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUser_FK")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSpeciality");

                    b.HasIndex("IdUser_FK");

                    b.ToTable("TbSpetialities");
                });

            modelBuilder.Entity("Domains.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StreetInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUser");

                    b.ToTable("TbUsers");
                });

            modelBuilder.Entity("Domains.Event", b =>
                {
                    b.HasOne("Domains.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domains.InformationForProMember", b =>
                {
                    b.HasOne("Domains.User", "User")
                        .WithMany("ListInfoProMember")
                        .HasForeignKey("UserId_Fk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domains.Role", b =>
                {
                    b.HasOne("Domains.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("RoleId_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domains.Speciality", b =>
                {
                    b.HasOne("Domains.User", "User")
                        .WithMany("Specialities")
                        .HasForeignKey("IdUser_FK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domains.User", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("ListInfoProMember");

                    b.Navigation("Roles");

                    b.Navigation("Specialities");
                });
#pragma warning restore 612, 618
        }
    }
}
