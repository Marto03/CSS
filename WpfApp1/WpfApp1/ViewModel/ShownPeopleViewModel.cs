using People.Database;
using People.Database.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;

namespace WpfApp1.ViewModel
{
    public class ShownPeopleViewModel : MainWindowViewModel
    {
        //private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";

        List<BothPeople> bothPeople = new List<BothPeople>();
        List<Teacher> teachers = new List<Teacher>();
        List<Student> students = new List<Student>();

        public ShownPeopleViewModel()
        {

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

        //public List<BothPeople> ShownPeople()
        //{
        //    if (File.Exists(pathPeople) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathPeople)))
        //    {
        //        string fileContent = File.ReadAllText(pathPeople);
        //        try
        //        {
        //            List<BothPeople> people = JsonSerializer.Deserialize<List<BothPeople>>(fileContent);
        //            return people;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //    return new List<BothPeople>();
        //}
    }
}
