using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Linq;
using People.Database;
using People.Database.Models;

namespace WpfApp1.ViewModel
{
    public class ShownStudentsViewModel : MainWindowViewModel
    {
        //private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        List<Student> students = new List<Student>();
        public ShownStudentsViewModel()
        {
            using var context = new PubContext();
            students = context.Students.ToList();
        }
        public List<Student> Students
        {
            get { return students; }
        }
        //public List<Student> ShownStudents()
        //{
        //    if (File.Exists(pathStudents) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathStudents)))
        //    {
        //        string fileContent = File.ReadAllText(pathStudents);
        //        try
        //        {
        //            List<Student> student = JsonSerializer.Deserialize<List<Student>>(fileContent);
        //            return student;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"Error: {ex.Message}");
        //        }
        //    }
        //    return new List<Student>();
        //}
    }
}
