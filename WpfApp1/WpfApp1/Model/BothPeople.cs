namespace WpfApp1.Model
{
    public class BothPeople : IPeople
    {
        public BothPeople(string fname, string lname, int age, string id, string speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            Id = id;
            Speciality = speciality;
        }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Speciality { get; set; }
    }
}
