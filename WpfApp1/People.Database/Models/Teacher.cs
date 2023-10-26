namespace People.Database.Models
{
    public class Teacher : BothPeople
    {
        
        public Teacher(string fname, string lname, int age, string idS, int yearsExperience, string title, string speciality) : base(fname, lname, age, idS, speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            IdS = idS;
            YearsExperience = yearsExperience;
            Title = title;
            Speciality = speciality;
        }

        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string IdS { get; set; }
        public int YearsExperience { get; set; }
        public string Title { get; set; }
        public string Speciality { get; set; }

    }

}
