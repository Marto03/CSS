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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for WindowTeacher.xaml
    /// </summary>
    public partial class WindowTeacher : Window
    {
        string fname;
        string lname;
        string ageString;
        int age;
        string idString;
        long id;
        int yearsExperience;
        string yearsExperienceString;
        string title;
        string spec;

        List<Teacher> teachers = new List<Teacher>();
        string pathTeachers = "D:\\C#\\RandomFileCreating\\WpfTeachers.json";
        public WindowTeacher()
        {
            InitializeComponent();
            teachers = ShownTeachers();
        }

        public List<Teacher> ShownTeachers()
        {
            if (File.Exists(pathTeachers))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathTeachers);
                    List<Teacher> teacher = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
                    return teacher;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here
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
                if (int.TryParse(ageString, out age))
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
                if (long.TryParse(idString, out id) && idString.Length == 10)
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
                if (int.TryParse(yearsExperienceString, out yearsExperience))
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
                    if(fname != null && lname != null && !age.Equals(null) && !id.Equals(null) && !yearsExperience.Equals(null) && title != null && spec != null)
                    {
                        Teacher teacher = new Teacher(fname, lname, age, id, yearsExperience, title, spec);
                        teachers.Add(teacher);
                        string json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });
                        try
                        {
                            //json = json.Replace(Environment.NewLine, "\n");
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
            //WindowTeacher teacherCreate = new WindowTeacher();
            //teacherCreate.Visibility = Visibility.Collapsed;
            //teacherCreate.Close();
        }

    }
}