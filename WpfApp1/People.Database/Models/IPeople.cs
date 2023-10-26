namespace People.Database.Models
{
    public interface IPeople
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string IdS { get; set; }
        public string Speciality { get; set; }
    }

}
