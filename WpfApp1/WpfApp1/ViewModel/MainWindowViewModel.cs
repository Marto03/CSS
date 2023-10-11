using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.ViewModel.Buttons;
using WpfApp1.Views.StudentView;
using WpfApp1.Views.TeacherView;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
            //public ICommand? ButtonBackToMenu { get; private set; }
            private RelayCommand backToMenuButton;
            public ICommand BackToMenuButton => backToMenuButton ??= new RelayCommand(PerformBackToMenuButton);

            public void PerformBackToMenuButton()
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.InitializeComponent();
                mainWindow.Show();
                
            }
        
        public class CreateStudentsButton
        {
            private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
            public RelayCommand ButtonAddStudents;
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
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";

        public event PropertyChangedEventHandler? PropertyChanged;

        public RelayCommand? ButtonAddTeachers;
        public ICommand CreateTeachersButton => ButtonAddTeachers ??= new RelayCommand(PerformCreateTeachersButton);

        private void PerformCreateTeachersButton()
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
            teacher.InitializeComponent();
            var teacherViewModel = new TeacherViewModel();
            teacher.DataContext = teacherViewModel;
            teacher.Show();
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
            teacher.InitializeComponent();
            var teacherViewModel = new TeacherViewModel();
            teacher.DataContext = teacherViewModel;
            teacher.Show();
        }

        private RelayCommand buttonAddStudents;
        public ICommand ButtonAddStudents => buttonAddStudents ??= new RelayCommand(PerformButtonAddStudents);

        private void PerformButtonAddStudents()
        {
            WindowStudent windowstudent = new WindowStudent();
            var studentViewModel = new StudentViewModel();
            windowstudent.InitializeComponent();
            windowstudent.DataContext = studentViewModel;
            windowstudent.Show();

        }

        private RelayCommand buttonShowStudents;
        public ICommand ButtonShowStudents => buttonShowStudents ??= new RelayCommand(PerformButtonShowStudents);

        private void PerformButtonShowStudents()
        {

        }

        private RelayCommand buttonShowTeachers;
        public ICommand ButtonShowTeachers => buttonShowTeachers ??= new RelayCommand(PerformButtonShowTeachers);

        private void PerformButtonShowTeachers()
        {
        }
    }
}
