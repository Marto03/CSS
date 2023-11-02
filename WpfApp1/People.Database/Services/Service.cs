using Microsoft.EntityFrameworkCore;
using People.Database.Models;

namespace People.Database.Services
{
    public class Service
    {
        public DbSet<Student> Students { get; set; }
        private Student _student;
        private Teacher _teacher;
        List<Student> _students;
        List<Teacher> _teachers;
        List<BothPeople> _BothPeople;

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
        public List<Student> GetStudentsService()
        {
            var studentRepository = new StudentRepository(_student);
            _students = studentRepository.GetAllStudents(_students);
            return _students;
        }
        public List<Teacher> GetTeachersService()
        {
            var teacherRepo = new TeacherRepository(_teacher);
            _teachers = teacherRepo.GetAllTeachers(_teachers);
            return _teachers;
        }

        public List<BothPeople> GetBothPeopleService()
        {
            var bothPeopleRepo = new BothPeopleRepository();
            _BothPeople = bothPeopleRepo.GetBothPeople();
            return _BothPeople;
        }
    }
}
