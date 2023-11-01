using People.Database.Models;

namespace People.Database
{

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
