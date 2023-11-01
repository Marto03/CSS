using People.Database.Models;
using People.Database.Services;
using System.Collections.Generic;
using System.Linq;

namespace WpfApp1.Validations
{
    public class PeopleValidations
    {
        private bool _PersonExists;
        BothPeople? both;
        List<BothPeople> bothPeople = new List<BothPeople>();
        public PeopleValidations(BothPeople p)
        {
            this.both = p;
        }

        public bool PersonExists
        {
            get { return _PersonExists; }
            set
            {
                if (_PersonExists != value)
                {
                    _PersonExists = value;
                }
            }
        }
        public bool Exists(BothPeople p)
        {
            //ShownPeopleViewModel viewModel = new ShownPeopleViewModel();
            Service s = new();
            bothPeople = s.GetBothPeopleService();
            PersonExists = bothPeople.Any(person => person.Fname == both.Fname && person.Lname == both.Lname &&
                    person.Age == both.Age && person.IdS == both.IdS && person.Speciality == both.Speciality);
            if (!PersonExists)
            {
                return false;
            }
            return true;
        }
    }
}
