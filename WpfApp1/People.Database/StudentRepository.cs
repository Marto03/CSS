using Azure;
using People.Database.Migrations;
using People.Database.Models;

namespace People.Database
{
    public class StudentRepository
    {
        public static void AddStudents(Student student)
        {
            using var context = new PubContext();
            context.Students.Add(student);
            context.SaveChanges();
        }
        public static List<Student> GetAllStudents(List<Student> s)
        {
            using var context = new PubContext();
            s = context.Students.ToList();
            return s;
        }
    }
}
