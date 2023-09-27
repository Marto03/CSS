namespace WpfApp1.Models
{
    public class Student
    {
        private string fname;

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

        public Student(string fname, string lname, int age, long id, string speciality, int course)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            Id = id;
            Speciality = speciality;
            Course = course;
        }
    }
}
