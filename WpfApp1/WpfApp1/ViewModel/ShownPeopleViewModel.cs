using People.Database;
using People.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using WpfApp1.Validations;

namespace WpfApp1.ViewModel
{
    public class ShownPeopleViewModel : MainWindowViewModel
    {
        List<BothPeople> bothPeople = new List<BothPeople>();
        List<Teacher> teachers = new List<Teacher>();
        List<Student> students = new List<Student>();

        public ShownPeopleViewModel()
        {
            // It is getting here first , and then check if a person exists , which is always true because , it appends it first and is always there
            // must be fixed
            
            using var context = new PubContext();
            teachers = context.Teachers.ToList();
            students = context.Students.ToList();
            bothPeople.AddRange(teachers);
            bothPeople.AddRange(students);
        }
        public List<BothPeople> Peoples
        {
            get { return bothPeople; }
        }
    }
}
