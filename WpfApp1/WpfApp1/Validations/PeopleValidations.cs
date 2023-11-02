using People.Database;
using People.Database.Models;
using People.Database.Services;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.Validations
{
    public class PeopleValidations
    {
        BothPeople People { get; set; }
        public PeopleValidations(BothPeople p)
        {   
            this.People = p;
        }
        public bool IsPersonValid()
        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            using var context = new PubContext();
            students = context.Students.ToList();

            teachers = context.Teachers.ToList();
            bool StudentExists = students.Any(student => student.Fname == People.Fname && student.Lname == People.Lname &&
                 student.Age == People.Age || student.IdS == People.IdS);
            bool TeacherExists = teachers.Any(teacher => teacher.Fname == People.Fname && teacher.Lname == People.Lname &&
            teacher.Age == People.Age || teacher.IdS == People.IdS);

            bool PersonExists = StudentExists || TeacherExists;
            return PersonExists;
        }
    }
}
