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
        private int age;
        private long id;
        private string spec;
        private List<BothPeople> bothPeople = new List<BothPeople>();
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";


        public WindowTeacher()
        {
            InitializeComponent();
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
            DataContext = new TeacherViewModel();
            //teachers = ShownTeachers();
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
    }
}