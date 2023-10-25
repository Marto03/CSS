using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Database
{
    public interface IStudent
    {
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }

    }
}
