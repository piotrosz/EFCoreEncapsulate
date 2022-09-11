using EFCoreEncapsulate.Model;

namespace EFCoreEncapsulate.Data
{
    public class StudentRepository
    {
        private readonly SchoolContext _schoolContext;
        public StudentRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public Student? GetByIdOrNull(long id)
        {
            //return _schoolContext.Students.SingleOrDefault(x => x.Id == id);

            // only Find reads from cache (AutoInclude)
            return _schoolContext.Students.Find(id);
        }
    }
}
