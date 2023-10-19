using System;
using System.Collections.Generic;
using System.Windows;
using WpfApp1.Model;
using System.IO;
using System.Text.Json;

namespace WpfApp1.ViewModel
{
    public class ShownTeachersViewModel : MainWindowViewModel
    {
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        List<Teacher> teachers = new List<Teacher>();

        public ShownTeachersViewModel()
        {
            teachers = ShownTeachers();
        }
        public List<Teacher> ShownTeachers()
        {
            if (File.Exists(pathTeachers) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathTeachers)))
            {
                string fileContent = File.ReadAllText(pathTeachers);
                try
                {
                    List<Teacher> teacher = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
                    return teacher;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return new List<Teacher>();
        }

    }
}
