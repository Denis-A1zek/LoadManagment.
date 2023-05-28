﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sigida.LoadManagment.Infrastructure.Database;

#nullable disable

namespace Sigida.LoadManagment.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230528131456_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Degree", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Degrees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c8c98d11-33b7-47c9-9a34-f41c830ea5ae"),
                            Title = "Ст. преподаватель"
                        },
                        new
                        {
                            Id = new Guid("b25af79b-fb59-4f79-9951-3c7d295622a8"),
                            Title = "Доцент"
                        });
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DegreeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("PositionId1")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DegreeId");

                    b.HasIndex("PositionId1");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Load", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCouting")
                        .HasColumnType("bit");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecialtyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Loads", (string)null);
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Plans", (string)null);
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("MaxLoad")
                        .HasColumnType("float");

                    b.Property<double>("MinLoad")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions", (string)null);
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Specialty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(96)
                        .HasColumnType("nvarchar(96)");

                    b.HasKey("Id");

                    b.ToTable("Specialties", (string)null);
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Sigida.LoadManagment.Domain.Entities.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigida.LoadManagment.Domain.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId1");

                    b.Navigation("Degree");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Load", b =>
                {
                    b.HasOne("Sigida.LoadManagment.Domain.Entities.Plan", "Plan")
                        .WithMany("Loads")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigida.LoadManagment.Domain.Entities.Specialty", "Specialty")
                        .WithMany()
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sigida.LoadManagment.Domain.Entities.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("Specialty");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Sigida.LoadManagment.Domain.Entities.Plan", b =>
                {
                    b.Navigation("Loads");
                });
#pragma warning restore 612, 618
        }
    }
}
