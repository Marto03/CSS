namespace WpfApp1.Model
{
    public class Student : BothPeople
    {
        private string fname;

        public Student(string fname, string lname, int age, string id, string speciality, int course) : base(fname, lname, age, id, speciality)
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
        public string Id { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
    }
}
