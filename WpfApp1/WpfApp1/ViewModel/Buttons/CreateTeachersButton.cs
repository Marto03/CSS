using System.IO;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Views.TeacherView;

namespace WpfApp1.ViewModel.Buttons
{
    public class CreateTeachersButton
    {
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        public ICommand ButtonAddTeachers { get; private set; }
        public CreateTeachersButton()
        {
            ButtonAddTeachers = new RelayCommand(TeachersCreating);
        }
        private void TeachersCreating()
        {
            if (!File.Exists(pathTeachers))
            {
                File.Create(pathTeachers);
                string defaultFile = "[]";
                File.WriteAllText(pathTeachers, defaultFile);
            }
            if (string.IsNullOrWhiteSpace(File.ReadAllText(pathTeachers)))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathTeachers, defaultFile);

            }
            WindowTeacher teacher = new WindowTeacher();
            var teacherViewModel = new TeacherViewModel();
            teacher.DataContext = teacherViewModel;
            teacher.Show();
        }
    }
}
