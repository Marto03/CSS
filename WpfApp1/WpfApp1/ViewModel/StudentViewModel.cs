using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Validations;
using WpfApp1.Services;
using People.Database.Models;

namespace WpfApp1.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _st;
        
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        List<Student> students = new List<Student>();
        List<BothPeople> bothPeople = new List<BothPeople>();
        private string _Fname;
        private string _Lname;
        private int _Age;
        private string _Id;
        private string _Speciality;
        private int _Course;
        private bool _StudentExists;
        private string _message;
        private bool _isConditionMet;
        public StudentViewModel()
        {
            //ShownPeopleViewModel viewModel = new ShownPeopleViewModel();
            //bothPeople = viewModel.ShownPeople();
            //using var context = new PubContext();
            //students = context.Students.ToList();
            //context.SaveChanges();
            //students = ShownStudents();
            Message = "Student's data";
            IsConditionMet = true;
        }
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
        public int Age
        {
            get => _Age;
            set
            {
                if (_Age != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedAge) && parsedAge > 0)
                    {
                        _Age = value;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }
        }
        public string IdS
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
                            OnPropertyChanged(nameof(IdS));
                        }
                    }
                       
                }
            }
        }
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
        public int Course
        {
            get => _Course;
            set
            {
                if (_Course != value)
                {
                    if (int.TryParse(value.ToString(), out int parsedCourse) && parsedCourse > 0)
                    {
                        _Course = value;
                        OnPropertyChanged(nameof(Course));
                    }
                }
            }
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

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
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
            StudentValidations studentValidations = new StudentValidations(this);
            if (studentValidations.IsValid())
            {
                StudentExists = students.Any(person => (person.Fname == Fname && person.Lname == Lname &&
                    person.Age == Age) || (person.IdS == IdS));

                if (StudentExists)
                {
                    Message = "Student exists";
                }
                else
                {
                    //StudentRepository studentRepository = new();
                    _st = new(Fname, Lname, Age, IdS, Speciality, Course);
                    Service s = new();
                    s.AddStudentsService(_st);
                    // Must remove those from here and instead place it in Service, which has add method who is calling the Repo who is doing those
                    //using var context = new PubContext();
                    //using var context = new PubContext();
                    //context.Students.Add(_st);
                    
                    //context.SaveChanges();
                    // ===================================================================================================

                    //StudentRepository.AddStudent(_st);
                    PeopleValidations peopleValidations = new PeopleValidations(_st);
                    //students.Add(_st);
                    //if (!peopleValidations.Exists())
                    //{
                    //    bothPeople.Add(_st);
                    //}
                    //string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
                    //{
                    //    WriteIndented = true
                    //});

                    //string json1 = JsonSerializer.Serialize(bothPeople, new JsonSerializerOptions
                    //{
                    //    WriteIndented = true
                    //});

                    //File.WriteAllText(pathStudents, json);
                    //File.WriteAllText(pathPeople, json1);
                    Message = "Created successfully";
                    IsConditionMet = false;
                }
            }
        }
    }
}