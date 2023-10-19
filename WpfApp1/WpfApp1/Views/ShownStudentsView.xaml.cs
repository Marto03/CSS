using System.Collections.Generic;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    public partial class ShownStudentsView : Window
    {
        List<Student> students = new List<Student>();
        public ShownStudentsView()
        {
            InitializeComponent();
            ShownStudentsViewModel shown = new ShownStudentsViewModel();
            students = shown.ShownStudents();
            studentListView.ItemsSource = students;
        }
    }
}
