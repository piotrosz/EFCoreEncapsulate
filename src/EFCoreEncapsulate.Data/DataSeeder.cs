using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;

internal static class DataSeeder
{
    public static void SeedTestData(ModelBuilder modelBuilder)
    {
        var bob = new Student(1, "Bob", Email.Create("bob@bob.pl").Value);
        var alice = new Student(2, "Alice", Email.Create("alice@alice.com").Value);
        modelBuilder.Entity<Student>().HasData(bob, alice);

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