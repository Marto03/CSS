using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for ShownStudentsView.xaml
    /// </summary>
    public partial class ShownStudentsView : Window
    {
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        public ShownStudentsView()
        {
            InitializeComponent();
            if (!File.Exists(pathStudents))
            {
                File.Create(pathStudents);
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);
            }
            if (string.IsNullOrWhiteSpace(File.ReadAllText(pathStudents)))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);
            }
            DataContext = new ShownStudentsViewModel();
        }
    }
}
