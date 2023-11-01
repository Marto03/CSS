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
            //int teach = teachers.Count();
            //int student = students.Count();
            foreach (var teacher in teachers)
            {
                if (!bothPeople.Any(person => person.Fname == teacher.Fname && person.Lname == teacher.Lname &&
                    person.Age == teacher.Age && person.IdS == teacher.IdS && person.Speciality == teacher.Speciality))
                {
                    bothPeople.Add(teacher);
                }
            }

            foreach (var student in students)
            {
                if (!bothPeople.Any(person => person.Fname == student.Fname && person.Lname == student.Lname &&
                    person.Age == student.Age && person.IdS == student.IdS && person.Speciality == student.Speciality))
                {
                    bothPeople.Add(student);
                }
            }
            //if (!students[student-1].Equals(teachers[teach-1]))
            //{

            //    bothPeople.AddRange(teachers);
            //    bothPeople.AddRange(students);
            //}
        }
        public List<BothPeople> Peoples
        {
            get { return bothPeople; }
        }
    }
}
