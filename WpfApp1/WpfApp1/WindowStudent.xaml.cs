using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class WindowStudent : Window
    {
        string fname;
        string lname;
        string ageString;
        int age;
        string idString;
        long id;
        string spec;
        string courseString;
        int course;
        List<Student> students = new List<Student>();
        string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        public WindowStudent()
        {
            InitializeComponent();
        }

        private void FirstNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                fname = firstNameBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(fname) || !fname.All(char.IsLetter))
                {
                    fname = firstNameBox.Text;
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
                    lname = lastNameBox.Text;
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
                if (int.TryParse(ageString, out age))
                {
                    idBox.Focus();
                }
                else
                {
                    ageBox.Text = "Wrong age";
                    ageString = ageBox.Text;
                }

            }
        }

        private void IdBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;

                idString = idBox.Text;
                if (long.TryParse(idString, out id) && idString.Length == 10)
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
                        idString = idBox.Text;
                    }

                }
                else
                {
                    idBox.Text = "EGN Must be 10 digits";
                    idString = idBox.Text;
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
                    spec = specBox.Text;
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
                if (int.TryParse(courseString, out course))
                {
                    Student student = new Student(fname, lname, age, id, spec, course);
                    students.Add(student);
                    string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });
                    try
                    {
                        //json = json.Replace(Environment.NewLine, "\n");
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
                    //}

                }
                else
                {
                    courseBox.Text = "Invalid number, Input Student's course";
                    courseString = courseBox.Text;
                }

            }
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.InitializeComponent();
            //mainWindow.Show();
            Close();
        }
    }
}
