using People.Database.Models;
using System.Collections.Generic;
using System.Linq;
using WpfApp1.Services;
using WpfApp1.ViewModel;

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
        public bool Exists()
        {
            //ShownPeopleViewModel viewModel = new ShownPeopleViewModel();
            Service s = new();
            bothPeople = s.GetBothPeopleService();
            PersonExists = bothPeople.Any(person => person.Fname == both.Fname && person.Lname == both.Lname &&
                    person.Age == both.Age && person.IdS == both.IdS && person.Speciality == both.Speciality);
            if(!PersonExists)
            {
                return false;
            }
            return true;
        }
    }
}
