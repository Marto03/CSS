using People.Database.Models;

namespace People.Database
{
    public class StudentRepository
    {
        private Student _st;
        public StudentRepository(Student st)
        {
            _st = st;
        }
        public void AddStudents(Student student)
        {
            using var context = new PubContext();
            context.Students.Add(student);
            context.SaveChanges();
        }
        public List<Student> GetAllStudents(List<Student> s)
        {
            using var context = new PubContext();
            s = context.Students.ToList();
            return s;
        }
    }
}
