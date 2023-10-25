using Microsoft.EntityFrameworkCore;
namespace People.Database
{
    /*
     * Here in order to work i must add Interfaces for the students and teachers and implement them in the main project 
     * Also need Dependency injection
     */

    public class StudentRepository
    {
        private PubContext _context;
        private IStudent _student;
        public StudentRepository(IStudent student)
        {
            _context = context;
            _student = student;
        }
        public List<IStudent> GetStudents()
        {
            return _student.toList();
        }
    }
}
