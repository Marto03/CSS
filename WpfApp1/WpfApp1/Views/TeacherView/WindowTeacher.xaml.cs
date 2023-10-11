using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.ViewModel;

namespace WpfApp1.Views.TeacherView
{
    public partial class WindowTeacher : Window , INotifyPropertyChanged
    {
        private string fname;
        private string lname;
        private string ageString;
        private int age;
        private string idString;
        private long id;
        private int yearsExperience;
        private string yearsExperienceString;
        private string title;
        private string spec;
        private List<Teacher> teachers = new List<Teacher>();
        private List<BothPeople> bothPeople = new List<BothPeople>();
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";


        public WindowTeacher()
        {
            InitializeComponent();
            DataContext = new TeacherViewModel();
            teachers = ShownTeachers();
            BothPeople peoples = new BothPeople(fname, lname, age, id, spec);
            bothPeople = peoples.ShownPeople();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Teacher> ShownTeachers()
        {
            if (File.Exists(pathTeachers))
            {
                string fileContent = File.ReadAllText(pathTeachers);
                try
                {
                    List<Teacher> teacher = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
                    return teacher;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return new List<Teacher>();
        }

        private RelayCommand backToMenuButton;
        public ICommand BackToMenuButton => backToMenuButton ??= new RelayCommand(PerformBackToMenuButton);

        public void PerformBackToMenuButton()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.InitializeComponent();
            mainWindow.Show();
            Close();
        }
    }
}