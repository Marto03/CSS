using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using WpfApp1.Model;
using System.IO;
using System.Text.Json;
using WpfApp1.Views;

namespace WpfApp1.ViewModel
{
    public class ShownStudentsViewModel : MainWindowViewModel
    {
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        List<Student> students = new List<Student>();

        public ShownStudentsViewModel()
        {
            students = ShownStudents();
        }
        public List<Student> ShownStudents()
        {
            if (!File.Exists(pathStudents))
            {
                File.Create(pathStudents);
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);
            }
            if (string.IsNullOrWhiteSpace(File.ReadAllText(pathStudents)))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);
            }
            if (File.Exists(pathStudents) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathStudents)))
            {
                string fileContent = File.ReadAllText(pathStudents);
                try
                {
                    List<Student> student = JsonSerializer.Deserialize<List<Student>>(fileContent);
                    return student;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return new List<Student>();
        }
    }
}
