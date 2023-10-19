﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Validations;

namespace WpfApp1.ViewModel
{
    public class TeacherViewModel : INotifyPropertyChanged
    {
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        List<Teacher> teachers = new List<Teacher>();
        List<BothPeople> bothPeople = new List<BothPeople>();
        public bool TeacherExists;

        private Teacher _teacher;
        public TeacherViewModel()
        {
            Message = "Teacher's data";
            teachers = ShownTeachers();
            ShownPeopleViewModel viewModel = new ShownPeopleViewModel();

            bothPeople = viewModel.ShownPeople();
            IsConditionMet = true;
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
        private string _Fname;
        public string Fname
        {
            get => _Fname;
            set
            {
                if (_Fname != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _Fname = value;
                        OnPropertyChanged(nameof(Fname));
                    }
                }
            }
        }
        private string _Lname;
        public string Lname
        {
            get => _Lname;
            set
            {
                if (_Lname != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _Lname = value;
                        OnPropertyChanged(nameof(Lname));
                    }
                }
            }
        }
        private int _Age;
        public int Age
        {
            get => _Age;
            set
            {
                if (_Age != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedAge) && parsedAge > 0)
                    {
                        _Age = parsedAge;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }
        }
        private string _Id;
        public string Id
        {
            get => _Id;
            set
            {
                if (_Id != value)
                {
                    if (long.TryParse(value, out long parsedId))
                    {
                        if (value.Length <= 10)
                        {
                            _Id = value;
                            OnPropertyChanged(nameof(Id));
                        }
                    }
                }
            }
        }
        private int _YearsExperience;
        public int YearsExperience
        {
            get => _YearsExperience;
            set
            {
                if (_YearsExperience != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedYearsExperience) && parsedYearsExperience > 0)
                    {
                        _YearsExperience = parsedYearsExperience;
                        OnPropertyChanged(nameof(YearsExperience));
                    }
                }
            }
        }
        private string _Title;
        public string Title
        {
            get => _Title;
            set
            {
                if (_Title != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _Title = value;
                        OnPropertyChanged(nameof(Title));
                    }
                }
            }
        }
        private string _Speciality;
        public string Speciality
        {
            get => _Speciality;
            set
            {
                if (_Speciality != value)
                {

                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _Speciality = value;
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
            long IdLong = long.Parse(Id);
            Id = "D10";
            if (teacherValidations.IsValid())
            {
                TeacherExists = teachers.Any(person => person.Fname == Fname && person.Lname == Lname &&
                    person.Age == Age && person.Id == Id);
                if (TeacherExists)
                {
                    Message = "Teacher Exists";
                }
                else
                {
                    _teacher = new Teacher(Fname, Lname, Age, Id, YearsExperience, Title, Speciality);
                    teachers.Add(_teacher);
                    PeopleValidations peopleValidations = new PeopleValidations(_teacher);
                    if (!peopleValidations.Exists())
                    {
                        bothPeople.Add(_teacher);
                    }
                    Message = "Created Successfully";
                    string json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    string json1 = JsonSerializer.Serialize(bothPeople, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    File.WriteAllText(pathTeachers, json);
                    File.WriteAllText(pathPeople, json1);
                    IsConditionMet = false;
                }
            }

        }
    }

}
