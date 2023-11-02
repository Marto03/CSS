using Microsoft.EntityFrameworkCore;
using People.Database.Models;

namespace People.Database.Services
{
    public class Service
    {
        private Student _student;
        private Teacher _teacher;
        List<Student> _students;
        List<Teacher> _teachers;
        List<BothPeople> _BothPeople;

        public void AddStudentsService(Student st)
        {
            _student = st;
            
            StudentRepository.AddStudents(_student);
        }
        public void AddTeachersService(Teacher teacher)
        {
            _teacher = teacher;
            TeacherRepository.AddTeachers(_teacher);
        }
        public List<Student> GetStudentsService()
        {
            _students = StudentRepository.GetAllStudents(_students);
            return _students;
        }
        public List<Teacher> GetTeachersService()
        {
            _teachers = TeacherRepository.GetAllTeachers(_teachers);
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
