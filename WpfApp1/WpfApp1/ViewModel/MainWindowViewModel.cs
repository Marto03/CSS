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
using WpfApp1.Views;
using WpfApp1.Views.StudentView;
using WpfApp1.Views.TeacherView;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //public ICommand? ButtonBackToMenu { get; private set; }
        //private List<Window> openedWindows = new List<Window>();
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
            Application.Current.MainWindow.Hide();
            CloseAllOpenWindows();

            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.Show();
            }
        }

    //    openedWindows.Add(student);
    //        openedWindows.Add(teacher);
    //        foreach (var window in openedWindows)
    //        {
    //            window.Close();
    //        }
    //teacher.Visibility = Visibility.Collapsed;
    //        teacher.Close();
    //        student.Close();

        private RelayCommand buttonAddStudents;
        public ICommand ButtonAddStudents => buttonAddStudents ??= new RelayCommand(PerformButtonAddStudents);
        private void PerformButtonAddStudents()
        {
            WindowStudent student = new WindowStudent();
            StudentViewModel studentViewModel = new StudentViewModel();
            student.DataContext = studentViewModel;
            student.Show();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private RelayCommand buttonAddTeachers;
        public ICommand ButtonAddTeachers => buttonAddTeachers ??= new RelayCommand(PerformButtonAddTeachers);

        private void PerformButtonAddTeachers()
        {
            WindowTeacher teacher = new WindowTeacher();
            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacher.DataContext = teacherViewModel;
            teacher.Show();
        }

        private RelayCommand buttonShowStudents;
        public ICommand ButtonShowStudents => buttonShowStudents ??= new RelayCommand(PerformButtonShowStudents);

        private void PerformButtonShowStudents()
        {
            ShownStudentsView shownStudentsView = new ShownStudentsView();
            ShownStudentsViewModel vw = new ShownStudentsViewModel();
            shownStudentsView.DataContext = vw;
            shownStudentsView.Show();
        }

        private RelayCommand buttonShowTeachers;
        public ICommand ButtonShowTeachers => buttonShowTeachers ??= new RelayCommand(PerformButtonShowTeachers);

        private void PerformButtonShowTeachers()
        {
        }


    }
}
