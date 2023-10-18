using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for ShownStudentsView.xaml
    /// </summary>
    public partial class ShownStudentsView : Window
    {
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
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
