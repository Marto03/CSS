using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1
{
    public partial class WindowStudent : Window
    {
        private string fname;
        private string lname;
        private string ageString;
        private int age;
        private string idString;
        private long id;
        private string spec;
        private string courseString;
        private int course;
        private List<Student> students = new List<Student>();
        private List<BothPeople> bothPeople = new List<BothPeople>();
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        public WindowStudent()
        {
            InitializeComponent();
            students = ShownStudents();
            BothPeople allPeople = new BothPeople(fname,lname,age,id,spec);
            bothPeople = allPeople.ShownPeople();
        }
        public List<Student> ShownStudents()
        {
            if (!File.Exists(pathStudents))
            {
                File.Create(pathStudents);
            }

            else if (File.Exists(pathStudents) && File.ReadAllText(pathStudents).Contains(""))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);
            }
            else if (File.Exists(pathStudents))
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
                    TextBoxPlaceHolder.GetPlaceholder(ageBox);
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
                    bool StudentExists = students.Any(person => person.Fname == fname && person.Lname == lname &&
                        person.Age == age && person.Id == id);
                    if (!StudentExists)
                    {
                        specBox.Focus();
                    }
                    else
                    {
                        idBox.Text = "Student already exists";
                        TextBoxPlaceHolder.SetPlaceholder(idBox, "Student already exists");
                        idString = idBox.Text;
                        specBox.Focus();
                    }
                }
                else
                {
                    idBox.Text = "EGN Must be 10 digits";
                    TextBoxPlaceHolder.SetPlaceholder(idBox, "EGN Must be 10 digits");
                    idString = idBox.Text;
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
                    specBox.Text = "Wrong speciality";
                    TextBoxPlaceHolder.SetPlaceholder(specBox, "Wrong speciality");
                    spec = specBox.Text;
                    courseBox.Focus();
                }
                else
                {
                    courseBox.Focus();
                }
            }
        }

        private void CourseBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == System.Windows.Input.Key.Enter)
            {
                courseString = courseBox.Text;
                if (int.TryParse(courseString, out course) && course > 0)
                {
                    if (!fname.Contains("Invalid name") && !lname.Contains("Invalid name") && !age.Equals(0) && !id.Equals(0) && !spec.Contains("Wrong speciality"))
                    {
                        Student student = new Student(fname, lname, age, id, spec, course);
                        students.Add(student);
                        bothPeople.Add(student);
                        string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
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
                            File.WriteAllText(pathStudents, json);
                        }
                        catch (Exception es)
                        {
                            showStudentsData.Text = es.Message;
                        }
                        finally
                        {
                            showStudentsData.Text = "Student created succesfully";
                            firstNameBox.Focusable = false;
                            lastNameBox.Focusable = false;
                            ageBox.Focusable = false;
                            idBox.Focusable = false;
                            specBox.Focusable = false;
                            courseBox.Focusable = false;
                        }
                    }
                    else
                    {
                        firstNameBox.Focus();
                    }
                }
                else
                {
                    courseBox.Text = "Invalid number, Input Student's course";
                    TextBoxPlaceHolder.SetPlaceholder(courseBox, "Invalid number, Input Student's course");
                    firstNameBox.Focus();
                    courseString = courseBox.Text;
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