using People.Database.Migrations;
using People.Database.Models;
using People.Database.Services;
using System.Transactions;

namespace People.Database
{
    public class AllPeopleValidation
    {
        private bool _PersonExists;
        BothPeople? both;
        List<BothPeople> bothPeople = new List<BothPeople>();
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        bool flag = false;

        public bool PersonExists
        {
            get { return _PersonExists; }
            set
            {
                if (_PersonExists != value)
                {
                    _PersonExists = value;
                }
            }
        }
        public bool Exists()
        {
            //ShownPeopleViewModel viewModel = new ShownPeopleViewModel();
            Service s = new();
            PersonExists = false;
            students = s.GetStudentsService();
            teachers = s.GetTeachersService();

            //bothPeople.AddRange(students);
            //bothPeople.AddRange(teachers);
            foreach (var teacher in teachers)
            {
                if (!students.Any(person => person.Fname == teacher.Fname && person.Lname == teacher.Lname &&
                    person.Age == teacher.Age && person.IdS == teacher.IdS && person.Speciality == teacher.Speciality))
                {
                    bothPeople.Add(teacher);
                    PersonExists = true;
                }
            }
            foreach (var student in students)
            {
                if (!teachers.Any(person => person.Fname == student.Fname && person.Lname == student.Lname &&
                    person.Age == student.Age && person.IdS == student.IdS && person.Speciality == student.Speciality))
                {
                    bothPeople.Add(student);
                    PersonExists = true;
                }
            }
            //PersonExists = bothPeople.Any(person => person.Fname == both.Fname && person.Lname == both.Lname &&
            //        person.Age == both.Age && person.IdS == both.IdS && person.Speciality == both.Speciality);
            //if (!PersonExists)
            //{
            //    return false;
            //}
            return PersonExists;
        }
    }
}
