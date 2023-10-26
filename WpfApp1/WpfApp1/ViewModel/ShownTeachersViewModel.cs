using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Text.Json;
using People.Database.Models;
using People.Database;
using System.Linq;

namespace WpfApp1.ViewModel
{
    public class ShownTeachersViewModel : MainWindowViewModel
    {
        List<Teacher> teachers = new List<Teacher>();
        public ShownTeachersViewModel()
        {
            using var context = new PubContext();
            teachers = context.Teachers.ToList();
        }
        public List<Teacher> Teachers
        {
            get { return teachers; }
        }
    }
}
