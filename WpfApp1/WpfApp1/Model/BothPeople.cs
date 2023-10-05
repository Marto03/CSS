﻿using System.Collections.Generic;
using System.Windows;
using System;
using System.IO;
using System.Text.Json;
using System.ComponentModel;
namespace WpfApp1.Model
{
    public class BothPeople : IPeople , INotifyPropertyChanged
    {
        public BothPeople(string fname, string lname, int age, long id, string speciality)
        {
            Fname = fname;
            Lname = lname;
            Age = age;
            Id = id;
            Speciality = speciality;
        }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public long Id { get; set; }
        public string Speciality { get; set; }
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";

        public event PropertyChangedEventHandler? PropertyChanged;

        public List<BothPeople> ShownPeople()
        {
            if (File.Exists(pathPeople))
            {
                try
                {
                    var fileContent = File.ReadAllText(pathPeople);
                    List<BothPeople> bothPeople = JsonSerializer.Deserialize<List<BothPeople>>(fileContent);
                    return bothPeople;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return new List<BothPeople>();
        }
    }
}
