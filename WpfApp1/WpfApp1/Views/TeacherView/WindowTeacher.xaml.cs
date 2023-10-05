using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Model;

namespace WpfApp1.Views.TeacherViews
{
    public partial class WindowTeacher : Window , INotifyPropertyChanged
    {
        private string fname;
        private string lname;
        private string ageString;
        private int age;
        private string idString;
        private long id;
        private int yearsExperience;
        private string yearsExperienceString;
        private string title;
        private string spec;
        private List<Teacher> teachers = new List<Teacher>();
        private List<BothPeople> bothPeople = new List<BothPeople>();
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";

        public event PropertyChangedEventHandler? PropertyChanged;

        public WindowTeacher()
        {
            InitializeComponent();
            teachers = ShownTeachers();
            BothPeople peoples = new BothPeople(fname, lname, age, id, spec);
            bothPeople = peoples.ShownPeople();
        }
        public List<Teacher> ShownTeachers()
        {
            if (File.Exists(pathTeachers))
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
        private void FirstNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                fname = firstNameBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(fname) || !fname.All(char.IsLetter))
                {
                    firstNameBox.Text = "Invalid name";
                    TextBoxPlaceHolder.SetPlaceholder(firstNameBox, "Invalid name");
                    fname = firstNameBox.Text;
                    lastNameBox.Focus();
                }
                else
                {
                    lastNameBox.Focus();
                }
            }
        }
        private void LastNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                lname = lastNameBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(lname) || !lname.All(char.IsLetter))
                {
                    lastNameBox.Text = "Invalid name";
                    TextBoxPlaceHolder.SetPlaceholder(lastNameBox, "Invalid name");
                    lname = lastNameBox.Text;
                    ageBox.Focus();
                }
                else
                {
                    ageBox.Focus();
                }
            }
        }
        private void AgeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                ageString = ageBox.Text;
                if (int.TryParse(ageString, out age) && age > 0)
                {
                    idBox.Focus();
                }
                else
                {
                    ageBox.Text = "Wrong age";
                    TextBoxPlaceHolder.SetPlaceholder(ageBox, "Wrong age");
                    ageString = ageBox.Text;
                    idBox.Focus();
                }
            }
        }
        private void IdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                idString = idBox.Text;
                if (long.TryParse(idString, out id) && idString.Length == 10 && id > 0)
                {
                    bool TeacherExists = teachers.Any(person => person.Fname == fname && person.Lname == lname &&
                        person.Age == age && person.Id == id);
                    if (!TeacherExists)
                    {
                        yearsExperienceBox.Focus();
                    }
                    else
                    {
                        idBox.Text = "Teacher already exists";
                        TextBoxPlaceHolder.SetPlaceholder(idBox, "Teacher already exists");
                        idString = idBox.Text;
                        yearsExperienceBox.Focus();
                    }
                }
                else
                {
                    idBox.Text = "EGN Must be 10 digits";
                    TextBoxPlaceHolder.SetPlaceholder(idBox, "EGN Must be 10 digits");
                    idString = idBox.Text;
                    yearsExperienceBox.Focus();
                }
            }
        }
        private void YearsExperienceBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                yearsExperienceString = yearsExperienceBox.Text;
                if (int.TryParse(yearsExperienceString, out yearsExperience) && yearsExperience > 0)
                {
                    titleBox.Focus();
                }
                else
                {
                    yearsExperienceBox.Text = "Wrong number,Input Teacher's work experience";
                    TextBoxPlaceHolder.SetPlaceholder(yearsExperienceBox, "Wrong number,Input Teacher's work experience");
                    yearsExperienceString = yearsExperienceBox.Text;
                    titleBox.Focus();
                }
            }
        }
        private void TitleBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                title = titleBox.Text;
                if (string.IsNullOrEmpty(title) || !title.All(char.IsLetter))
                {
                    titleBox.Text = "Invalid title";
                    TextBoxPlaceHolder.SetPlaceholder(titleBox, "Invalid title");
                    title = titleBox.Text;
                    specBox.Focus();
                }
                else
                {
                    specBox.Focus();
                }
            }
        }
        private void SpecBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                spec = specBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(spec) || !spec.All(char.IsLetter))
                {
                    specBox.Text = "Invalid speciality";
                    TextBoxPlaceHolder.SetPlaceholder(specBox, "Invalid speciality");
                    spec = specBox.Text;
                    firstNameBox.Focus();
                }
                else
                {
                    if (!fname.Contains("Invalid name") && !lname.Contains("Invalid name") && !age.Equals(0) && !id.Equals(0) && !yearsExperience.Equals(0) && !title.Contains("Invalid title") && !spec.Contains("Invalid speciality"))
                    {
                        Teacher teacher = new Teacher(fname, lname, age, id, yearsExperience, title, spec);
                        teachers.Add(teacher);

                        bool PersonExists = bothPeople.Any(person => person.Fname == fname && person.Lname == lname &&
                            person.Age == age && person.Id == id);
                        if (!PersonExists)
                        {
                            bothPeople.Add(teacher);
                        }
                        string json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });
                        string jsonPeople = JsonSerializer.Serialize(bothPeople, new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });
                        try
                        {
                            File.WriteAllText(pathPeople, jsonPeople);
                            File.WriteAllText(pathTeachers, json);
                        }
                        catch (Exception es)
                        {
                            showTeachersData.Text = es.Message;
                        }
                        finally
                        {
                            showTeachersData.Text = "Teacher created succesfully";
                            firstNameBox.Focusable = false;
                            lastNameBox.Focusable = false;
                            ageBox.Focusable = false;
                            idBox.Focusable = false;
                            yearsExperienceBox.Focusable = false;
                            titleBox.Focusable = false;
                            specBox.Focusable = false;
                        }
                    }
                    else
                    {
                        e.Handled = false;
                        firstNameBox.Focus();
                    }
                }
            }
        }
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.InitializeComponent();
            mainWindow.Show();
            Close();
        }
    }
}