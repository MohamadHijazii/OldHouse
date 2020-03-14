﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OldHouse.Data;

namespace OldHouse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200307154037_InitTables")]
    partial class InitTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OldHouse.Data.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("BloodType");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("DisplayName");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Gender")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int?>("MachineId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.HasKey("PatientId");

                    b.HasIndex("MachineId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("OldHouse.Models.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<string>("Level")
                        .HasMaxLength(2147483647);

                    b.Property<int>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("OldHouse.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Battery");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("Status");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("OldHouse.Models.Record", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("BloodPressure");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2147483647);

                    b.Property<float>("GlucoseLevel");

                    b.Property<float>("HeartRate");

                    b.Property<int>("PatientId");

                    b.Property<float>("Temperature");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("OldHouse.Models.Relative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<int>("PatientId");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Relatives");
                });

            modelBuilder.Entity("OldHouse.Data.Patient", b =>
                {
                    b.HasOne("OldHouse.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId");
                });

            modelBuilder.Entity("OldHouse.Models.Alert", b =>
                {
                    b.HasOne("OldHouse.Data.Patient", "Patient")
                        .WithMany("Alerts")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OldHouse.Models.Record", b =>
                {
                    b.HasOne("OldHouse.Data.Patient", "Patient")
                        .WithMany("Records")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OldHouse.Models.Relative", b =>
                {
                    b.HasOne("OldHouse.Data.Patient", "Patient")
                        .WithOne("Relative")
                        .HasForeignKey("OldHouse.Models.Relative", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
