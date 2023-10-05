using System.IO;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Views.StudentView;

namespace WpfApp1.ViewModel.Buttons
{
    public class CreateStudentsButton
    {
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        public ICommand ButtonAddStudents { get; private set; }
        public CreateStudentsButton()
        {
            ButtonAddStudents = new RelayCommand(StudentsCreating);
        }
        private void StudentsCreating()
        {
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
            WindowStudent student = new WindowStudent();
            var studentViewModel = new StudentViewModel();
            student.DataContext = studentViewModel;
            student.Show();
        }
    }

}
