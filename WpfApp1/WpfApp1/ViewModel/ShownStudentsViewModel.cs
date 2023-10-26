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
    }
}
