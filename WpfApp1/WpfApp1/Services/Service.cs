using Microsoft.EntityFrameworkCore;
using People.Database;
using People.Database.Migrations;
using People.Database.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace WpfApp1.Services
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
        public List<Student> GetStudentsService()
        {
            using var context = new PubContext();
            _students = context.Students.ToList();
            return _students;
        }
        public void AddTeachersService(Teacher teacher)
        {
            _teacher = teacher;
            var teacherRepository = new TeacherRepository(_teacher);
            teacherRepository.AddTeachers(_teacher);
        }
        public List<Teacher> GetTeachersService()
        {
            using var context = new PubContext();
            _teachers = context.Teachers.ToList();
            return _teachers;
        }
        public List<BothPeople> GetBothPeopleService()
        {
            foreach (var teacher in _teachers)
            {
                if (!_BothPeople.Any(person => person.Fname == teacher.Fname && person.Lname == teacher.Lname &&
                    person.Age == teacher.Age && person.IdS == teacher.IdS && person.Speciality == teacher.Speciality))
                {
                    _BothPeople.Add(teacher);
                }
            }
            foreach (var student in _students)
            {
                if (!_BothPeople.Any(person => person.Fname == student.Fname && person.Lname == student.Lname &&
                    person.Age == student.Age && person.IdS == student.IdS && person.Speciality == student.Speciality))
                {
                    _BothPeople.Add(student);
                }
            }

            return _BothPeople;
        }
    }
}
