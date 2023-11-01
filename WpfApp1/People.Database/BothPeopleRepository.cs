using Microsoft.EntityFrameworkCore;
using People.Database.Models;

namespace People.Database
{
    public class BothPeopleRepository
    {
        List<Student> _students;
        List<Teacher> _teachers;
        List<BothPeople> _BothPeople;
        public List<BothPeople> GetBothPeople()
        {
            using var context = new PubContext();

            _teachers = context.Teachers.ToList();
            _students = context.Students.ToList();
            _BothPeople = new List<BothPeople>();
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
