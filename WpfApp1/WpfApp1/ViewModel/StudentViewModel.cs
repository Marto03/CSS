using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Model;
using WpfApp1.Validations;
using WpfApp1.Views.StudentView;

namespace WpfApp1.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _st;
        
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        List<Student> students = new List<Student>();

        private bool _StudentExists;
        public StudentViewModel()
        {
            students = ShownStudents();
            Message = "Student's data";
            IsConditionMet = true;
            _st = new(Fname, Lname, Age, Id, Speciality, Course);
        }
        public List<Student> ShownStudents()
        {
            if (File.Exists(pathStudents) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathStudents)))
            {
                string fileContent = File.ReadAllText(pathStudents);
                try
                {
                    List<Student> student = JsonSerializer.Deserialize<List<Student>>(fileContent);
                    return student;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return new List<Student>();
        }
        public string Fname
        {
            get => _st?.Fname;
            set
            {
                if (_st.Fname != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _st.Fname = value;
                        OnPropertyChanged(nameof(Fname));
                    }
                }
            }
        }
        public string Lname
        {
            get => _st?.Lname;
            set
            {
                if (_st.Lname != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _st.Lname = value;
                        OnPropertyChanged(nameof(Lname));
                    }
                        
                }
            }
        }
        public int Age
        {
            get => _st?.Age ?? 0;
            set
            {
                if (_st.Age != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedAge) && parsedAge > 0)
                    {
                        _st.Age = value;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }
        }
        public long Id
        {
            get => _st?.Id ?? 0;
            set
            {
                if (_st.Id != value)
                {
                    if (long.TryParse(value.ToString(), out long parsedId) && parsedId > 0)
                    {
                        if (value.ToString().Length <= 10)
                        {
                            _st.Id = value;
                            OnPropertyChanged(nameof(Id));
                        }
                    }
                       
                }
            }
        }
        public bool StudentExists
        {
            get { return _StudentExists; }
            set
            {
                if (_StudentExists != value)
                {
                    _StudentExists = value;
                    OnPropertyChanged(nameof(StudentExists));
                }
            }
        }
        public string Speciality
        {
            get => _st?.Speciality;
            set
            {
                if (_st.Speciality != value)
                {
                    if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                    {
                        _st.Speciality = value;
                        OnPropertyChanged(nameof(Speciality));
                    }
                }
            }
        }
        public int Course
        {
            get => _st?.Course ?? 0;
            set
            {
                if (_st.Course != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedCourse) && parsedCourse > 0)
                    {
                        _st.Course = value;
                        OnPropertyChanged(nameof(Course));
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

        private RelayCommand createStudentsButton;
        public ICommand CreateStudentsButton => createStudentsButton ??= new RelayCommand(PerformCreateStudentsButton);

        private void PerformCreateStudentsButton()
        {
            string idS = _st.Id.ToString();
            StudentValidations studentValidations = new StudentValidations(this);
            if (studentValidations.IsValid())
            {

                StudentExists = students.Any(person => person.Fname == _st.Fname && person.Lname == _st.Lname &&
                    person.Age == _st.Age && person.Id == _st.Id);

                if (StudentExists)
                {
                    Message = "Student exists";
                }
                else
                {
                    students.Add(_st);
                    string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

                    File.WriteAllText(pathStudents, json);
                    Message = "Created successfully";
                    IsConditionMet = false;
                }
            }
        }
    }
}