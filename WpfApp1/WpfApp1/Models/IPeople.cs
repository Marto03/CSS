namespace WpfApp1.Models
{
    public interface IPeople
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public long Id { get; set; }
        public string Speciality { get; set; }

    }
}
