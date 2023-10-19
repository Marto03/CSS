using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Views;
using WpfApp1.Views.StudentView;
using WpfApp1.Views.TeacherView;

namespace WpfApp1.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
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
        private RelayCommand buttonAddStudents;
        public ICommand ButtonAddStudents => buttonAddStudents ??= new RelayCommand(PerformButtonAddStudents);
        private void PerformButtonAddStudents()
        {
            Application.Current.MainWindow.Hide();
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
            Application.Current.MainWindow.Hide();
            WindowTeacher teacher = new WindowTeacher();
            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacher.DataContext = teacherViewModel;
            teacher.Show();
        }

        private RelayCommand buttonShowStudents;
        public ICommand ButtonShowStudents => buttonShowStudents ??= new RelayCommand(PerformButtonShowStudents);

        private void PerformButtonShowStudents()
        {
            Application.Current.MainWindow.Hide();
            ShownStudentsView shownStudentsView = new ShownStudentsView();
            ShownStudentsViewModel vw = new ShownStudentsViewModel();
            shownStudentsView.DataContext = vw;
            shownStudentsView.Show();
        }

        private RelayCommand buttonShowTeachers;
        public ICommand ButtonShowTeachers => buttonShowTeachers ??= new RelayCommand(PerformButtonShowTeachers);

        private void PerformButtonShowTeachers()
        {
            Application.Current.MainWindow.Hide();
            ShownTeachersView shownTeachersView = new ShownTeachersView();
            ShownTeachersViewModel shownTeachersViewModel = new ShownTeachersViewModel();
            shownTeachersView.DataContext = shownTeachersViewModel;
            shownTeachersView.Show();
        }

        private RelayCommand buttonShowAllPeople;
        public ICommand ButtonShowAllPeople => buttonShowAllPeople ??= new RelayCommand(PerformButtonShowAllPeople);

        private void PerformButtonShowAllPeople()
        {
            Application.Current.MainWindow.Hide();
            ShownPeopleView shownPeopleView = new ShownPeopleView();
            ShownPeopleViewModel shownPeopleViewModel = new ShownPeopleViewModel();
            shownPeopleView.DataContext = shownPeopleViewModel;
            shownPeopleView.Show();
        }

    }
}
