﻿using System.ComponentModel;
namespace WpfApp1.Model
{
    public interface IPeople
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Speciality { get; set; }
    }
}
