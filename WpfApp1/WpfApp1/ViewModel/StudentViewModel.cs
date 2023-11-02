using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Commands;
using WpfApp1.Validations;
using People.Database.Models;
using People.Database.Services;

namespace WpfApp1.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _st;
        
        private string _Fname;
        private string _Lname;
        private int _Age;
        private string _Id;
        private string _Speciality;
        private int _Course;
        private string _message;
        private bool _isConditionMet;
        public StudentViewModel()
        {
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
            //StudentValidations studentValidations = new StudentValidations(this);
            if (StudentValidations.IsValid(this))
            {
                _st = new(Fname, Lname, Age, IdS, Speciality, Course);
                Service s = new();

                if (PeopleValidations.IsPersonValid(_st))
                {
                    Message = "Person exists";
                }
                else
                {
                    s.AddStudentsService(_st);
                    Message = "Created successfully";
                    IsConditionMet = false;
                }
            }
        }
    }
}