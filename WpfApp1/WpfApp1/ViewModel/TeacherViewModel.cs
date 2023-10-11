using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Views.TeacherView;

namespace WpfApp1.ViewModel
{
    public class TeacherViewModel : INotifyPropertyChanged
    {
        //private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private Teacher _teacher;
        public TeacherViewModel()
        {
            _teacher = new Teacher(Fname, Lname, Age, Id, YearsExperience, Title, Speciality);
        }
        public string Fname
        {
            get => _teacher?.Fname;
            set
            {
                if (_teacher.Fname != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _teacher.Fname = value;
                        OnPropertyChanged(nameof(Fname));
                    }
                }
            }
        }
        public string Lname
        {
            get => _teacher?.Lname;
            set
            {
                if (_teacher.Lname != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _teacher.Lname = value;
                        OnPropertyChanged(nameof(Lname));
                    }
                }
            }
        }
        public int Age
        {
            get => _teacher?.Age ?? 0;
            set
            {
                if (_teacher.Age != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedAge) && parsedAge > 0)
                    {
                        _teacher.Age = parsedAge;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }
        }
        public long Id
        {
            get => _teacher?.Id ?? 0;
            set
            {
                if (_teacher.Id != value)
                {
                    if (long.TryParse(value.ToString(), out long parsedId) && parsedId > 0)
                    {
                        if (value.ToString().Length <= 10)
                        {
                            _teacher.Id = parsedId;
                            OnPropertyChanged(nameof(Id));
                        }
                    }
                }
            }
        }
        public int YearsExperience
        {
            get => _teacher?.YearsExperience ?? 0;
            set
            {
                if (_teacher.YearsExperience != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedYearsExperience) && parsedYearsExperience > 0)
                    {
                        _teacher.YearsExperience = parsedYearsExperience;
                        OnPropertyChanged(nameof(YearsExperience));
                    }
                }
            }
        }
        public string Title
        {
            get => _teacher?.Title;
            set
            {
                if (_teacher.Title != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _teacher.Title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
            }
        }
        public string Speciality
        {
            get => _teacher?.Speciality;
            set
            {
                if (_teacher.Speciality != value)
                {

                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _teacher.Speciality = value;
                        OnPropertyChanged(nameof(Speciality));
                    }
                }
            }
        }
        //private List<Teacher> teachers = new List<Teacher>();
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));

            //teachers.Add(_teacher);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private RelayCommand backToMenuButton;
        public ICommand BackToMenuButton => backToMenuButton ??= new RelayCommand(PerformBackToMenuButton);


        private void PerformBackToMenuButton()
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.InitializeComponent();
            //mainWindow.Show();

            WindowTeacher viewModel = new WindowTeacher();
            viewModel.PerformBackToMenuButton();

            //string json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //});

            //File.WriteAllText(pathTeachers, json);

        }
    }

}
