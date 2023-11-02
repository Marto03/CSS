using People.Database.Models;
using People.Database.Services;

namespace People.Database
{
    public class AllPeopleValidation
    {
        private bool _PersonExists;
        List<BothPeople> bothPeople = new List<BothPeople>();
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();

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
            foreach (var teacher in teachers)
            {
                if (bothPeople.Any(person => IsMatching(person,teacher)))
                {
                    PersonExists = true;

                }
                bothPeople.Add(teacher);
            }
            foreach (var student in students)
            {
                if (PersonExists = bothPeople.Any(person => IsMatching(person, student)))
                {
                    PersonExists = true;
                }
                bothPeople.Add(student);
            }

            return PersonExists;
            //foreach (var teacher in teachers)
            //{
            //    if (!students.Exists(person => person.Fname == teacher.Fname && person.Lname == teacher.Lname &&
            //        person.Age == teacher.Age && person.IdS == teacher.IdS && person.Speciality == teacher.Speciality))
            //    {

            //        bothPeople.Add(teacher);
            //        PersonExists = true;
            //    }
            //}
            //foreach (var student in students)
            //{
            //    if (!teachers.Any(person => person.Fname == student.Fname && person.Lname == student.Lname &&
            //        person.Age == student.Age && person.IdS == student.IdS && person.Speciality == student.Speciality))
            //    {
            //        bothPeople.Add(student);
            //        PersonExists = true;
            //    }
            //}
            //PersonExists = bothPeople.Any(person => person.Fname == both.Fname && person.Lname == both.Lname &&
            //        person.Age == both.Age && person.IdS == both.IdS && person.Speciality == both.Speciality);

            //var existingPerson = bothPeople.OfType<BothPeople>().FirstOrDefault(s =>
            //        s.Fname == both.Fname && s.Lname == both.Lname &&
            //        s.Age == both.Age && s.IdS == both.IdS && s.Speciality == both.Speciality);

            //if (!PersonExists)
            //{
            //    return false;
            //}
            //bothPeople.Remove(existingPerson);
            //return PersonExists;
        }
        public static bool IsMatching(BothPeople exists, BothPeople newPerson)
        {
            return exists.Fname == newPerson.Fname &&
                exists.Lname == newPerson.Lname &&
                exists.Age == newPerson.Age &&
                exists.IdS == newPerson.IdS &&
                exists.Speciality == newPerson.Speciality;
        }
    }
}
