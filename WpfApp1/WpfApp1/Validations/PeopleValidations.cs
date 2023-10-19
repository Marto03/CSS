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
        List<BothPeople> bothPeople = new List<BothPeople>();

        public bool PersonExists
        {
            get { return _PersonExists; }
            set
            {
                if (_PersonExists != value)
                {
                    _PersonExists = value;
                    OnPropertyChanged(nameof(PersonExists));
                }
            }
        }
        BothPeople? both;
        public PeopleValidations(BothPeople p)
        {
            this.both = p;
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
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        
    }
}
