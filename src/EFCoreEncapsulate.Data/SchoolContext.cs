﻿using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreEncapsulate.Data;

public sealed class SchoolContext : DbContext
{
    private readonly string _connectionString;
    private readonly bool _useConsoleLogger;

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    // This is a way to encapsulate DbContext (reduce number of possible config options, keeping invariants)
    public SchoolContext(string connectionString, bool useConsoleLogger)
    {
        _connectionString = connectionString;
        _useConsoleLogger = useConsoleLogger;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);

        if (_useConsoleLogger)
        {
            optionsBuilder
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        }
        else
        {
            optionsBuilder
                .UseLoggerFactory(CreateEmptyLoggerFactory());
        }
    }

    private static ILoggerFactory CreateEmptyLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((_, _) => false));
    }

    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder
            .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
            .AddConsole());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(x =>
        {
            x.ToTable("Student").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("StudentID");
            x.Property(p => p.Email).HasMaxLength(200);
            x.Property(p => p.Name).HasMaxLength(200);
            x.HasMany(p => p.Enrollments).WithOne(p => p.Student);
        });
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("Course").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseID");
            x.Property(p => p.Name).HasMaxLength(200);;
        });
        modelBuilder.Entity<Enrollment>(x =>
        {
            x.ToTable("Enrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("EnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.Enrollments);
            x.HasOne(p => p.Course).WithMany();
            x.Property(p => p.Grade);
        });

        // Seeding data
        var bob = new Student 
        {
            Id = 1,
            Email = "bob@bob.pl",
            Name = "Bob"
        };

        var alice = new Student 
        {
            Id = 2,
            Email = "alice@alice.com",
            Name = "Alice"
        };

        modelBuilder.Entity<Student>().HasData(bob, alice);

        var physics = new Course 
        {
            Id = 1,
            Name = "Physics"
        };

        var mathematics = new Course 
        {
            Id = 2,
            Name = "Mathematics"
        };

        modelBuilder.Entity<Course>().HasData(
            physics, 
            mathematics);

        modelBuilder.Entity<Enrollment>().HasData(
            new Enrollment
            {
                Id = 1,
                Grade = Grade.B,
                Course = physics,
                Student = bob  
            },
            new Enrollment
            {
                Id = 2,
                Grade = Grade.A,
                Course = mathematics,
                Student = alice
            },
            new Enrollment
            {
                Id = 1,
                Grade = Grade.A,
                Course = physics,
                Student = alice
            }
        );
    }
}
