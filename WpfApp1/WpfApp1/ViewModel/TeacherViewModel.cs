using System;
using System.ComponentModel;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class TeacherViewModel : INotifyPropertyChanged
    {
        private readonly Teacher _st;

        public TeacherViewModel()
        {
            _st = new(Fname, Lname, Age, Id,YearsExperience,Title,Speciality);
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
        public int YearsExperience
        {
            get => _st.YearsExperience;
            set
            {
                if (_st.YearsExperience != value)
                {
                    _st.YearsExperience = value;
                    OnPropertyChanged(nameof(YearsExperience));
                }
            }
        }
        public string Title
        {
            get => _st.Title;
            set
            {
                if (_st.Title != value)
                {
                    _st.Title = value;
                    OnPropertyChanged(nameof(Title));
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
        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
