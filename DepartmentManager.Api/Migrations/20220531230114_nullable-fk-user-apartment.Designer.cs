﻿// <auto-generated />
using DepartmentManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DepartmentManager.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220531230114_nullable-fk-user-apartment")]
    partial class nullablefkuserapartment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DepartmentManager.Data.Entities.Apartment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HouseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Apartments");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.House", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.Report", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ApartmentId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.Rule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("HouseId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ApartmentId")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.Apartment", b =>
                {
                    b.HasOne("DepartmentManager.Data.Entities.House", "House")
                        .WithMany("Apartments")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.Report", b =>
                {
                    b.HasOne("DepartmentManager.Data.Entities.Apartment", "Apartment")
                        .WithMany("Reports")
                        .HasForeignKey("ApartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DepartmentManager.Data.Entities.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.Rule", b =>
                {
                    b.HasOne("DepartmentManager.Data.Entities.House", "House")
                        .WithMany("Rules")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.User", b =>
                {
                    b.HasOne("DepartmentManager.Data.Entities.Apartment", "Apartment")
                        .WithMany("Users")
                        .HasForeignKey("ApartmentId");

                    b.Navigation("Apartment");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.Apartment", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.House", b =>
                {
                    b.Navigation("Apartments");

                    b.Navigation("Rules");
                });

            modelBuilder.Entity("DepartmentManager.Data.Entities.User", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
