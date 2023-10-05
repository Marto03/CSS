using System.ComponentModel;
namespace WpfApp1.Model
{
    public class Student : BothPeople
    {
        private string fname;

        public Student(string fname, string lname, int age, long id, string speciality, int course) : base(fname, lname, age, id, speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            Id = id;
            Speciality = speciality;
            Course = course;
        }
        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
            }
        }
        public string Lname { get; set; }
        public int Age { get; set; }
        public long Id { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
    }
}
