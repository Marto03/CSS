using System.ComponentModel.DataAnnotations;

namespace People.Database.Models
{
    public class Student : BothPeople
    {
        private string fname;

        public Student(string fname, string lname, int age, string idS, string speciality, int course) : base(fname, lname, age, idS, speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            IdS = idS;
            Speciality = speciality;
            Course = course;
        }
        [Key]
        public int Id {  get; set; }
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
        public string IdS { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
    }

}
