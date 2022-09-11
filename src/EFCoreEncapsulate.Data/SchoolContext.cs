using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreEncapsulate.Data;

public sealed class SchoolContext : DbContext
{
    private readonly string _connectionString;
    private readonly bool _useConsoleLogger;

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    public DbSet<Course> Sports { get; set; }

    public DbSet<CourseEnrollment> CourseEnrollments { get; set; }

    public DbSet<SportEnrollment> SportEnrollments { get; set; }

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
            x.HasMany(p => p.CourseEnrollments).WithOne(p => p.Student);
            x.HasMany(p => p.SportEnrollments).WithOne(p => p.Student);

        });
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("Course").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseID");
            x.Property(p => p.Name).HasMaxLength(200);;
        });
        modelBuilder.Entity<CourseEnrollment>(x =>
        {
            x.ToTable("CourseEnrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseEnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.CourseEnrollments);
            x.HasOne(p => p.Course).WithMany();
            x.Property(p => p.Grade);
        });

        modelBuilder.Entity<SportEnrollment>(x =>
        {
            x.ToTable("SportEnrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("SportEnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.SportEnrollments);
            x.HasOne(p => p.Sport).WithMany();
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

        modelBuilder.Entity<CourseEnrollment>().HasData(
            new CourseEnrollment
            {
                Id = 1,
                Grade = Grade.B,
                Course = physics,
                Student = bob  
            },
            new CourseEnrollment
            {
                Id = 2,
                Grade = Grade.A,
                Course = mathematics,
                Student = alice
            },
            new CourseEnrollment
            {
                Id = 1,
                Grade = Grade.A,
                Course = physics,
                Student = alice
            }
        );

        var swimming = new Sport 
        {
            Id = 1,
            Name = "Swimming"
        };

        var basketball = new Sport 
        {
            Id = 2,
            Name = "Basketball"
        };

        modelBuilder.Entity<SportEnrollment>().HasData(
            new SportEnrollment 
            {
                Id = 1, 
                Grade = Grade.C,
                Sport = swimming,
                Student = alice
            },
            new SportEnrollment 
            {
                Id = 2, 
                Grade = Grade.D,
                Sport = basketball,
                Student = bob
            }
            
        );
    }
}
