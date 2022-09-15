using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreEncapsulate.Data;

public sealed class SchoolContext : DbContext
{
    private readonly string _connectionString;
    private readonly bool _useConsoleLogger;

    //public DbSet<Student> Students { get; set; }
    //public DbSet<Course> Courses { get; set; }
    //public DbSet<Course> Sports { get; set; }
    //public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
    //public DbSet<SportEnrollment> SportEnrollments { get; set; }

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

            // New auto include feature
            x.Navigation(p => p.CourseEnrollments).AutoInclude();
            x.Navigation(p => p.SportEnrollments).AutoInclude();

        });
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("Course").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseID");
            x.Property(p => p.Name).HasMaxLength(200);;
        });
        
        modelBuilder.Entity<Sport>(x =>
        {
            x.ToTable("Sport").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("SportID");
            x.Property(p => p.Name).HasMaxLength(200);;
        });
        
        modelBuilder.Entity<CourseEnrollment>(x =>
        {
            x.ToTable("CourseEnrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseEnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.CourseEnrollments);
            //x.HasOne(p => p.Course).WithMany();
            x.Property(p => p.CourseId); // No Course navigation property
            x.Property(p => p.Grade);

            // New auto include feature
            // x.Navigation(p => p.Course).AutoInclude();
        });

        modelBuilder.Entity<SportEnrollment>(x =>
        {
            x.ToTable("SportEnrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("SportEnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.SportEnrollments);
            //x.HasOne(p => p.Sport).WithMany();
            x.Property(p => p.SportId);
            x.Property(p => p.Grade);

            // New auto include feature
            //x.Navigation(p => p.Sport).AutoInclude();
        });

        modelBuilder.Entity<CourseEnrollmentData>(x =>
        {
            x.HasNoKey();
            x.Property(p => p.StudentId);
            x.Property(p => p.Grade);
            x.Property(p => p.CourseName);
        });

        modelBuilder.Entity<SportEnrollmentData>(x =>
        {
            x.HasNoKey();
            x.Property(p => p.StudentId);
            x.Property(p => p.Grade);
            x.Property(p => p.SportName);
        });

        SeedTestData(modelBuilder);
    }

    private static void SeedTestData(ModelBuilder modelBuilder)
    {
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
                CourseId = physics.Id,
                StudentId = bob.Id,
            },
            new CourseEnrollment
            {
                Id = 2,
                Grade = Grade.A,
                CourseId = mathematics.Id,
                StudentId = alice.Id,
            },
            new CourseEnrollment
            {
                Id = 3,
                Grade = Grade.A,
                CourseId = physics.Id,
                StudentId = alice.Id,
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


        modelBuilder.Entity<Sport>().HasData(
            swimming,
            basketball);


        modelBuilder.Entity<SportEnrollment>().HasData(
            new SportEnrollment
            {
                Id = 1,
                Grade = Grade.C,
                SportId = swimming.Id,
                StudentId = alice.Id
            },
            new SportEnrollment
            {
                Id = 2,
                Grade = Grade.D,
                SportId = basketball.Id,
                StudentId = bob.Id
            }
        );
    }

    // Key-less entity
    internal class CourseEnrollmentData
    {
        public long StudentId { get; set; }
        public int Grade { get; set; }
        public string? CourseName { get; set; }
    }

    internal class SportEnrollmentData
    {
        public long StudentId { get; set; }
        public int Grade { get; set; }
        public string? SportName { get; set; }
    }

}
