using People.Database.Models;
using People.Database.Services;
using System.Collections.Generic;

namespace WpfApp1.ViewModel
{
    public class ShownPeopleViewModel : MainWindowViewModel
    {
        List<BothPeople> bothPeople = new List<BothPeople>();

        public ShownPeopleViewModel()
        {
            Service s = new();
            bothPeople = s.GetBothPeopleService();
        }
        public List<BothPeople> Peoples
        {
            get { return bothPeople; }
        }
    }
}
