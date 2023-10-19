using System.Windows;
using System.IO;
using WpfApp1.ViewModel;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel _mainViewModel = new MainWindowViewModel();
            DataContext = _mainViewModel;
            string defaultFile = "[]";
            if (!File.Exists(pathStudents))
            {
                File.WriteAllText(pathStudents, defaultFile);
            }
            if (!File.Exists(pathTeachers))
            {
                File.WriteAllText(pathTeachers, defaultFile);
            }
            if(!File.Exists(pathPeople))
            {
                File.WriteAllText(pathPeople, defaultFile);
            }
        }
    }
}