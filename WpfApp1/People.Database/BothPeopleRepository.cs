using People.Database.Models;

namespace People.Database
{
    public class BothPeopleRepository
    {
        List<Student> _students;
        List<Teacher> _teachers;
        List<BothPeople> _BothPeople = new();

        public List<BothPeople> GetBothPeople()
        {
            using var context = new PubContext();
            _teachers = context.Teachers.ToList();
            _students = context.Students.ToList();
            _BothPeople.AddRange(_teachers);
            _BothPeople.AddRange(_students);
            return _BothPeople;
        }
    }
}
