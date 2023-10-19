using System.Collections.Generic;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class ShownPeopleView : Window
    {
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        private List<BothPeople> bothPeople = new List<BothPeople>();
        public ShownPeopleView()
        {
            InitializeComponent();
            ShownPeopleViewModel shown = new ShownPeopleViewModel();
            bothPeople = shown.ShownPeople(); 
            PeopleListView.ItemsSource = bothPeople;
        }
    }
}
