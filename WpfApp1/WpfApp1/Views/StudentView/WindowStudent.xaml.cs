using System.ComponentModel;
using System.Windows;

namespace WpfApp1.Views.StudentView
{
    public partial class WindowStudent : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public WindowStudent()
        {
            InitializeComponent();
        }
    }
}