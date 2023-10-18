using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for ShownPeopleView.xaml
    /// </summary>
    /// Must fix that View and ViewModel of all People
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
