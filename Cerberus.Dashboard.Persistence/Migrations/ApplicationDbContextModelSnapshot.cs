﻿// <auto-generated />
using System;
using Cerberus.Dashboard.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cerberus.Dashboard.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("RegistrationTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("StaffNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddressCity")
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddressLine1")
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddressLine2")
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddressLine3")
                        .HasColumnType("text");

                    b.Property<string>("PhysicalAddressPostalCode")
                        .HasColumnType("text");

                    b.Property<string>("PostalAddressCity")
                        .HasColumnType("text");

                    b.Property<string>("PostalAddressLine1")
                        .HasColumnType("text");

                    b.Property<string>("PostalAddressLine2")
                        .HasColumnType("text");

                    b.Property<string>("PostalAddressLine3")
                        .HasColumnType("text");

                    b.Property<string>("PostalAddressPostalCode")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Addresss");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("ApplicationDate")
                        .HasColumnType("text");

                    b.Property<string>("ApplicationStage")
                        .HasColumnType("text");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Ethnicity")
                        .HasColumnType("text");

                    b.Property<string>("Firstname")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDisable")
                        .HasColumnType("boolean");

                    b.Property<string>("Lastname")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Preference")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SchoolId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SchoolId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("InstitutionId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("integer");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMainCampus")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PostCode")
                        .HasColumnType("text");

                    b.Property<string>("Province")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.School", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CreateUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("FacultyId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ModifyUserId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("School");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Account", b =>
                {
                    b.OwnsMany("Cerberus.Dashboard.Domain.Models.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<int>("AccountId")
                                .HasColumnType("integer");

                            b1.Property<DateTime>("CreateDate")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("text");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("text");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("text");

                            b1.Property<string>("Token")
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Application", b =>
                {
                    b.HasOne("Cerberus.Dashboard.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cerberus.Dashboard.Domain.Models.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Courses", b =>
                {
                    b.HasOne("Cerberus.Dashboard.Domain.Models.Application", null)
                        .WithMany("Courses")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cerberus.Dashboard.Domain.Models.Department", null)
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Department", b =>
                {
                    b.HasOne("Cerberus.Dashboard.Domain.Models.School", null)
                        .WithMany("Departments")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Faculty", b =>
                {
                    b.HasOne("Cerberus.Dashboard.Domain.Models.Institution", null)
                        .WithMany("Faculties")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Institution", b =>
                {
                    b.HasOne("Cerberus.Dashboard.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.School", b =>
                {
                    b.HasOne("Cerberus.Dashboard.Domain.Models.Faculty", null)
                        .WithMany("Schools")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Application", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Department", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Faculty", b =>
                {
                    b.Navigation("Schools");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.Institution", b =>
                {
                    b.Navigation("Faculties");
                });

            modelBuilder.Entity("Cerberus.Dashboard.Domain.Models.School", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
