namespace EFCoreEncapsulate.DataContracts
{
    public class StudentDto
    {
        public long StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public IReadOnlyList<CourseEnrollmentDto> CourseEnrollments { get; set; }
        public IReadOnlyList<SportEnrollmentDto> SportEnrollments { get; set; }
    }
}