using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private readonly string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private readonly string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        private List<Window> openedWindows = new List<Window>();
        private RelayCommand backToMenuButton;
        public ICommand BackToMenuButton => backToMenuButton ??= new RelayCommand(PerformBackToMenuButton);

        public void CloseAllOpenWindows()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window != Application.Current.MainWindow)
                {
                    window.Close();
                }
            }
        }


        public void PerformBackToMenuButton()
        {
            CloseAllOpenWindows();

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
        }
        //openedWindows.Add(student);
        //openedWindows.Add(teacher);
        //foreach (var window in openedWindows)
        //{
        //    window.Close();
        //}
        //teacher.Visibility = Visibility.Collapsed;
        //teacher.Close();
        //student.Close();

        private RelayCommand buttonAddStudents;
        public ICommand ButtonAddStudents => buttonAddStudents ??= new RelayCommand(PerformButtonAddStudents);
        private void PerformButtonAddStudents()
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
            StudentViewModel studentViewModel = new StudentViewModel();
            studentViewModel.Message = "Student's data";
            student.DataContext = studentViewModel;
            student.Show();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private RelayCommand buttonAddTeachers;
        public ICommand ButtonAddTeachers => buttonAddTeachers ??= new RelayCommand(PerformButtonAddTeachers);

        private void PerformButtonAddTeachers()
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
            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Message = "Teacher's data";
            teacher.DataContext = teacherViewModel;
            teacher.Show();
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
