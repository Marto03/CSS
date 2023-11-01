namespace People.Database.Models
{
    public class BothPeople : IPeople
    {
        public BothPeople(string fname, string lname, int age, string ids, string speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            IdS = ids;
            Speciality = speciality;
        }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string IdS { get; set; }
        public string Speciality { get; set; }
    }
}
