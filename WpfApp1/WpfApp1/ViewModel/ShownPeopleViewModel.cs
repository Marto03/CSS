using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class ShownPeopleViewModel : MainWindowViewModel
    {
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        private List<BothPeople> bothPeople = new List<BothPeople>();

        public ShownPeopleViewModel()
        {
            bothPeople = ShownPeople();
        }

        public List<BothPeople> ShownPeople()
        {
            if (File.Exists(pathPeople) && !string.IsNullOrWhiteSpace(File.ReadAllText(pathPeople)))
            {
                string fileContent = File.ReadAllText(pathPeople);
                try
                {
                    List<BothPeople> people = JsonSerializer.Deserialize<List<BothPeople>>(fileContent);
                    return people;
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
