using Microsoft.EntityFrameworkCore;
using People.Database.Models;

namespace People.Database
{
    /*
     * Here in order to work i must add Interfaces for the students and teachers and implement them in the main project 
     * Also need Dependency injection
     */

    public class TeacherRepository
    {
        private Teacher _teacher;
        public TeacherRepository(Teacher teacher)
        {
            _teacher = teacher;
        }
        public void AddTeachers(Teacher teachers)
        {
            using var context = new PubContext();
            context.Teachers.Add(teachers);
            context.SaveChanges();
        }
        public List<Teacher> GetAllTeachers(List<Teacher> t)
        {
            using var context = new PubContext();
            t = context.Teachers.ToList();
            return t;
        }
    }
}
