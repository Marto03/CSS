namespace WpfApp1.Models
{
    public class Teacher
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public long Id { get; set; }
        public int YearsExperience { get; set; }
        public string Title { get; set; }
        public string Speciality { get; set; }

        public Teacher(string fname, string lname, int age, long id, int yearsExperience, string title, string speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            Id = id;
            YearsExperience = yearsExperience;
            Title = title;
            Speciality = speciality;
        }
    }
}
