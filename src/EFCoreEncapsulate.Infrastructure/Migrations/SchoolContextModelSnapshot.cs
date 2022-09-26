﻿// <auto-generated />
using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreEncapsulate.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("EFCoreEncapsulate.Domain.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.CourseEnrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseEnrollment");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.Sport", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Sport");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.SportEnrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("SportId")
                        .HasColumnType("bigint");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("SportEnrollment");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("CourseTeacher", b =>
                {
                    b.HasOne("EFCoreEncapsulate.Domain.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreEncapsulate.Domain.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.CourseEnrollment", b =>
                {
                    b.HasOne("EFCoreEncapsulate.Domain.Student", "Student")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.SportEnrollment", b =>
                {
                    b.HasOne("EFCoreEncapsulate.Domain.Student", "Student")
                        .WithMany("SportEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.Student", b =>
                {
                    b.OwnsOne("EFCoreEncapsulate.Domain.Email", "Email", b1 =>
                        {
                            b1.Property<long>("StudentId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.HasKey("StudentId");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentId");
                        });

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreEncapsulate.Domain.Student", b =>
                {
                    b.Navigation("CourseEnrollments");

                    b.Navigation("SportEnrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
