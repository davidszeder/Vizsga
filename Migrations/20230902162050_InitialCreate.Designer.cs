﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vizsgafeladat;

#nullable disable

namespace Vizsgafeladat.Migrations
{
    [DbContext(typeof(ReportDbContext))]
    [Migration("20230902162050_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vizsgafeladat.Entities.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReportDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Vizsgafeladat.Entities.TheTask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("RepairDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RepairType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReportID")
                        .HasColumnType("int");

                    b.Property<int>("WorkerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ReportID");

                    b.HasIndex("WorkerID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Vizsgafeladat.Entities.Worker", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("Vizsgafeladat.Entities.TheTask", b =>
                {
                    b.HasOne("Vizsgafeladat.Entities.Report", "Report")
                        .WithMany("Tasks")
                        .HasForeignKey("ReportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vizsgafeladat.Entities.Worker", "Worker")
                        .WithMany("Tasks")
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Report");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("Vizsgafeladat.Entities.Report", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Vizsgafeladat.Entities.Worker", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}