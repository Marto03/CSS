using System.Collections.Generic;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class ShownTeachersView : Window
    {
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
