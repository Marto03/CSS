using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using WpfApp1.ViewModel;

namespace WpfApp1.Views.TeacherView
{
    public partial class WindowTeacher : Window , INotifyPropertyChanged
    {
        public WindowTeacher()
        {
            InitializeComponent();
            DataContext = new TeacherViewModel();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}