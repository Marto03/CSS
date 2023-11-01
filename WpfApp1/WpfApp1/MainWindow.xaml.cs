using System.Windows;
using System.IO;
using WpfApp1.ViewModel;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel _mainViewModel = new MainWindowViewModel();
            DataContext = _mainViewModel;
        }
    }
}