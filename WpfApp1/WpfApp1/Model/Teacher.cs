﻿using System.ComponentModel;
namespace WpfApp1.Model
{
    public class Teacher : BothPeople
    {
        public Teacher(string fname, string lname, int age, long id, int yearsExperience, string title, string speciality) : base(fname, lname, age, id, speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            Id = id;
            YearsExperience = yearsExperience;
            Title = title;
            Speciality = speciality;
        }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public long Id { get; set; }
        public int YearsExperience { get; set; }
        public string Title { get; set; }
        public string Speciality { get; set; }

    }
}
