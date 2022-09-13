using EFCoreEncapsulate.Model;

namespace EFCoreEncapsulate.Api.Dtos
{
    public class EnrollInCourseDto
    {
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public Grade Grade { get; set; }
    }
}
