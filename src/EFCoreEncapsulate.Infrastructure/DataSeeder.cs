using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;

[Obsolete]
internal static class DataSeeder
{
    public static void SeedTestData(this ModelBuilder modelBuilder)
    {
        // https://github.com/dotnet/efcore/issues/10000
        var bob = new Student(1, "Bob", Email.Create("bob@bob.pl").Value);
        var alice = new Student(2, "Alice", Email.Create("alice@alice.com").Value);
        modelBuilder.Entity<Student>().HasData(
        new {
            Id = bob.Id,
            Name = bob.Name
        },
        new {
            Id = alice.Id,
            Name = alice.Name,
        });

        modelBuilder.Entity<Email>().HasData(
            new
            {
                StudentId = bob.Id,
                Value = bob.Email.Value
            },
            new
            {
                StudentId = alice.Id,
                Value = alice.Email.Value
            }
        );
        
        
        var physics = new Course(1, "Physics");
        var mathematics = new Course(2, "Mathematics");

        modelBuilder.Entity<Course>().HasData(
            physics,
            mathematics);

        modelBuilder.Entity<CourseEnrollment>().HasData(
            new CourseEnrollment(1, bob.Id, physics.Id, Grade.B),
            new CourseEnrollment(2, alice.Id, mathematics.Id, Grade.A),
            new CourseEnrollment(3, alice.Id, physics.Id, Grade.A)
        );

        var swimming = new Sport(1, "Swimming");
        var basketball = new Sport(2, "Basketball");
        modelBuilder.Entity<Sport>().HasData(
            swimming,
            basketball);


        modelBuilder.Entity<SportEnrollment>().HasData(
            new SportEnrollment(1, alice.Id, swimming.Id, Grade.C),
            new SportEnrollment(2, bob.Id, basketball.Id, Grade.A)
        );
    }
}