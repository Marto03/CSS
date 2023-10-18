using System.Collections.Generic;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for ShownTeachersView.xaml
    /// </summary>
    public partial class ShownTeachersView : Window
    {

        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        List<Teacher> teachers = new List<Teacher>();
        public ShownTeachersView()
        {
            InitializeComponent();
            ShownTeachersViewModel shown = new ShownTeachersViewModel();
            teachers = shown.ShownTeachers();
            TeacherListView.ItemsSource = teachers;
        }
    }
}
