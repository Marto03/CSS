using System;
using System.ComponentModel;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private readonly Student _st;

        public StudentViewModel()
        {
            _st = new(Fname, Lname, Age, Id, Speciality, Course);
        }
        public string Fname
        {
            get => _st.Fname;
            set
            {
                if (_st.Fname != value)
                {
                    _st.Fname = value;
                    OnPropertyChanged(nameof(Fname));
                }
            }
        }
        public string Lname
        {
            get => _st.Lname;
            set
            {
                if (_st.Lname != value)
                {
                    _st.Lname = value;
                    OnPropertyChanged(nameof(Lname));
                }
            }
        }
        public int Age
        {
            get => _st.Age;
            set
            {
                if (_st.Age != value)
                {
                    _st.Age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }
        public long Id
        {
            get => _st.Id;
            set
            {
                if (_st.Id != value)
                {
                    _st.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }
        public string Speciality
        {
            get => _st.Speciality;
            set
            {
                if (_st.Speciality != value)
                {
                    _st.Speciality = value;
                    OnPropertyChanged(nameof(Speciality));
                }
            }
        }
        public int Course
        {
            get => _st.Course;
            set
            {
                if (_st.Course != value)
                {
                    _st.Course = value;
                    OnPropertyChanged(nameof(Course));
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
