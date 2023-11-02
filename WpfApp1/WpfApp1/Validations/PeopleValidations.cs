using People.Database;
using People.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.Validations
{
    public class PeopleValidations
    {
        public static bool IsPersonValid(BothPeople People)
        {
            List<Student> students = new();
            List<Teacher> teachers = new();
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
