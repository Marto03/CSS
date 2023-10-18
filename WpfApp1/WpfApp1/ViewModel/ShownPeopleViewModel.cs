using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class ShownPeopleViewModel
    {
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        private List<BothPeople> bothPeople = new List<BothPeople>();

        public ShownPeopleViewModel()
        {
            bothPeople = ShownPeople();
        }
    }
}
