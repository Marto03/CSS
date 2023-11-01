using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Text.Json;
using System.Linq;
using People.Database;
using People.Database.Models;
using WpfApp1.Services;

namespace WpfApp1.ViewModel
{
    public class ShownStudentsViewModel : MainWindowViewModel
    {
        List<Student> students = new List<Student>();
        public ShownStudentsViewModel()
        {
            //using var context = new PubContext();
            //students = context.Students.ToList();
            Service s = new();
            students = s.GetStudentsService();
        }
        public List<Student> Students
        {
            get { return students; }
        }
    }
}
