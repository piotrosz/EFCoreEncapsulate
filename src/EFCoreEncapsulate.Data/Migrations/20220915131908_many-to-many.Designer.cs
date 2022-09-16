﻿// <auto-generated />
using EFCoreEncapsulate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreEncapsulate.Api.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20220915131908_many-to-many")]
    partial class manytomany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.Property<long>("CoursesId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeachersId")
                        .HasColumnType("bigint");

                    b.HasKey("CoursesId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("CourseTeacher");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Data.SchoolContext+CourseEnrollmentData", b =>
                {
                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.ToTable("CourseEnrollmentData");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Data.SchoolContext+SportEnrollmentData", b =>
                {
                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("SportName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.ToTable("SportEnrollmentData");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CourseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Physics"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Mathematics"
                        });
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.CourseEnrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CourseEnrollmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseEnrollment", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CourseId = 1L,
                            Grade = 2,
                            StudentId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            CourseId = 2L,
                            Grade = 1,
                            StudentId = 2L
                        },
                        new
                        {
                            Id = 3L,
                            CourseId = 1L,
                            Grade = 1,
                            StudentId = 2L
                        });
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.Sport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("SportID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Sport", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Swimming"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Basketball"
                        });
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.SportEnrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("SportEnrollmentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("SportId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("SportEnrollment", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Grade = 3,
                            SportId = 1L,
                            StudentId = 2L
                        },
                        new
                        {
                            Id = 2L,
                            Grade = 4,
                            SportId = 2L,
                            StudentId = 1L
                        });
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("StudentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Email = "bob@bob.pl",
                            Name = "Bob"
                        },
                        new
                        {
                            Id = 2L,
                            Email = "alice@alice.com",
                            Name = "Alice"
                        });
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TeacherID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.HasOne("EFCoreEncapsulate.Model.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreEncapsulate.Model.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.CourseEnrollment", b =>
                {
                    b.HasOne("EFCoreEncapsulate.Model.Student", "Student")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.SportEnrollment", b =>
                {
                    b.HasOne("EFCoreEncapsulate.Model.Student", "Student")
                        .WithMany("SportEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Model.Student", b =>
                {
                    b.Navigation("CourseEnrollments");

                    b.Navigation("SportEnrollments");
                });
#pragma warning restore 612, 618
        }
    }
}