using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Validations;
using WpfApp1.Views.TeacherView;

namespace WpfApp1.ViewModel
{
    public class TeacherViewModel : INotifyPropertyChanged
    {
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        List<Teacher> teachers = new List<Teacher>();
        public bool TeacherExists;

        private Teacher _teacher;
        public TeacherViewModel()
        {
            teachers = ShownTeachers();
            IsConditionMet = true;
            _teacher = new Teacher(Fname, Lname, Age, Id, YearsExperience, Title, Speciality);
        }
        public List<Teacher> ShownTeachers()
        {
            if (File.Exists(pathTeachers) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathTeachers)))
            {
                string fileContent = File.ReadAllText(pathTeachers);
                try
                {
                    List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
                    return teachers;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return new List<Teacher>();
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
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private bool _isConditionMet;
        public bool IsConditionMet
        {
            get { return _isConditionMet; }
            set
            {
                if (_isConditionMet != value)
                {
                    _isConditionMet = value;
                    OnPropertyChanged(nameof(IsConditionMet));
                }
            }
        }
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private RelayCommand backToMenuButton;
        public ICommand BackToMenuButton => backToMenuButton ??= new RelayCommand(PerformBackToMenuButton);


        private void PerformBackToMenuButton()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            mainWindowViewModel.PerformBackToMenuButton();

        }

        private RelayCommand createTeachersButton;
        public ICommand CreateTeachersButton => createTeachersButton ??= new RelayCommand(PerformCreateTeachersButton);

        private void PerformCreateTeachersButton()
        {
            TeacherValidations teacherValidations = new TeacherValidations(this);
            string idS = _teacher.Id.ToString();
            if (teacherValidations.IsValid())
            {
                TeacherExists = teachers.Any(person => person.Fname == _teacher.Fname && person.Lname == _teacher.Lname &&
                    person.Age == _teacher.Age && person.Id == _teacher.Id);
                if (TeacherExists)
                {
                    Message = "Teacher Exists";
                }
                else
                {
                    teachers.Add(_teacher);
                    Message = "Created Successfully";
                    string json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    File.WriteAllText(pathTeachers, json);
                    IsConditionMet = false;
                }
            }

        }
    }

}
