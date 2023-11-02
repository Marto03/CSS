using People.Database.Models;

namespace People.Database
{

    public class TeacherRepository
    {
        public static void AddTeachers(Teacher teachers)
        {
            using var context = new PubContext();
            context.Teachers.Add(teachers);
            context.SaveChanges();
        }
        public static List<Teacher> GetAllTeachers(List<Teacher> t)
        {
            using var context = new PubContext();
            t = context.Teachers.ToList();
            return t;
        }
    }
}
