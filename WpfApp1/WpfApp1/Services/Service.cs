using Microsoft.EntityFrameworkCore;
using People.Database;
using People.Database.Models;

namespace WpfApp1.Services
{
    public class Service
    {
        public DbSet<Student> Students { get; set; }
        private PubContext _context;
        private Student _student;
        private Teacher _teacher;
        private BothPeople _people;
        public void AddStudentsService(Student st)
        {
            _student = st;
            var studentRepository = new StudentRepository(_student);
            studentRepository.AddStudents(_student);
        }
        public void AddTeachersService(Teacher teacher)
        {
            _teacher = teacher;
            var teacherRepository = new TeacherRepository(_teacher);
            teacherRepository.AddTeachers(_teacher);
        }
    }
}
