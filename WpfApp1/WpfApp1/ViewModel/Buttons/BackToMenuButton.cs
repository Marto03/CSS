using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;

namespace WpfApp1.ViewModel.Buttons
{
    public class BackToMenuButton
    {
        public ICommand ButtonBackToMenu { get; private set; }
        public BackToMenuButton()
        {
            ButtonBackToMenu = new RelayCommand(BackMenu);
        }
        private void BackMenu()
        {
            MainWindow main = new();
            main.InitializeComponent();
            main.Show();
        }
    }
}
