using Microsoft.EntityFrameworkCore;
using People.Database.Models;

namespace People.Database
{
    /*
     * Here in order to work i must add Interfaces for the students and teachers and implement them in the main project 
     * Also need Dependency injection
     */

    public class StudentRepository
    {
        private Student _st;
        public StudentRepository(Student st)
        {
            _st = st;
        }
        public void AddStudents(Student student)
        {
            using var context = new PubContext();
            context.Students.Add(student);
            context.SaveChanges();
        }
    }
}
