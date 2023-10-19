using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WpfApp1.Model;
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
            ShownPeopleViewModel viewModel = new ShownPeopleViewModel();
            bothPeople = viewModel.ShownPeople();
            PersonExists = bothPeople.Any(person => person.Fname == both.Fname && person.Lname == both.Lname &&
                    person.Age == both.Age && person.Id == both.Id && person.Speciality == both.Speciality);
            if(!PersonExists)
            {
                return false;
            }
            return true;
        }
    }
}
