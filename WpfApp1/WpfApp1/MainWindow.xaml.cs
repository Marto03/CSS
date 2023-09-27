using System.Collections.Generic;
using System.Text.Json;
using System;
using System.Windows;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text;
using System.IO;
using System.Linq;
<<<<<<< HEAD
using WpfApp1.Models;
=======
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        bool backMenu = true;
        int ageParsed;
        long idParsed;
        string fname;
        string specString;
        string lname;
        string id;
        string experienceString;
        string titleTeacher;
        int yearsExperience;
        string ageString;
        string courseStringStudents;
        bool createdStudents;
        bool shownAllPeople = false;
        bool StudentExists;
        bool TeacherExists;
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        //List<object> bothList = new List<object>();
<<<<<<< HEAD
        //string pathStudents = "D:\\C#\\RandomFileCreating\\WpfStudents.json";
        string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        //string pathTeachers = "D:\\C#\\RandomFileCreating\\WpfTeachers.json";
=======
        string pathStudents = "D:\\C#\\RandomFileCreating\\WpfStudents.json";
        string pathTeachers = "D:\\C#\\RandomFileCreating\\WpfTeachers.json";
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        //string pathPeople = "D:\\C#\\Random file creating\\WpfallPeople.json";
        private GridLength originalHeightRow0;
        private GridLength originalHeightRow1;
        private GridLength originalHeightRow2;
        private GridLength originalHeightRow3;
        private GridLength originalHeightRow4;
        public MainWindow()
        {

            InitializeComponent();
<<<<<<< HEAD
            
            
=======
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
            originalHeightRow0 = row0.Height;
            originalHeightRow1 = row1.Height;
            originalHeightRow2 = row2.Height;
            originalHeightRow3 = row3.Height;
            originalHeightRow4 = row4.Height;
<<<<<<< HEAD

        }


        private void AddStudents_Click(object sender, RoutedEventArgs e)
        {
            WindowStudent student = new WindowStudent();
            student.InitializeComponent();
            student.firstNameBox.Focus();
            student.Show();
            student.firstNameBox.Focus();
            this.Visibility = Visibility.Collapsed;
            //Close();
            

            //firstNameBox.Focus();

        }

        private void AddTeachers_Click(object sender, RoutedEventArgs e)
        {
            //AddObject.Visibility = Visibility.Hidden;
            //showSeparately.Visibility = Visibility.Collapsed;
            //ShowPeople.Visibility = Visibility.Collapsed;
            //botCol.Visibility = Visibility.Collapsed;
            //backToMenu.Visibility = Visibility.Visible;

            //firstNameTeacherBlock.Visibility = Visibility.Visible;
            //firstNameTeacherBox.Visibility = Visibility.Visible;
            
            this.Visibility = Visibility.Collapsed;
           
            WindowTeacher windowTeacher = new WindowTeacher();
            windowTeacher.InitializeComponent();
            windowTeacher.firstNameBox.Focus();
            windowTeacher.Show();

            //firstNameTeacherBox.Focus();
            //firstNameTeacherBlock.FontSize = 40;
            //firstNameTeacherBox.Focus();
            //firstNameTeacherBlock.Text = "Input Teacher's first name: ";
        }

        private void ShowStudents_Click(object sender, RoutedEventArgs e)
=======
        }

        private void addStudents_Click(object sender, RoutedEventArgs e)
        {

            AddObject.Visibility = Visibility.Hidden;
            showSeparately.Visibility = Visibility.Collapsed;
            ShowPeople.Visibility = Visibility.Collapsed;
            botCol.Visibility = Visibility.Collapsed;
            backToMenu.Visibility = Visibility.Visible;

            firstNameBlock.Visibility = Visibility.Visible;
            firstNameBox.Visibility = Visibility.Visible;

            firstNameBlock.FontSize = 40;
            firstNameBox.Focus();
            firstNameBlock.Text = "Input Student's first name: ";

        }

        private void addTeachers_Click(object sender, RoutedEventArgs e)
        {
            AddObject.Visibility = Visibility.Hidden;
            showSeparately.Visibility = Visibility.Collapsed;
            ShowPeople.Visibility = Visibility.Collapsed;
            botCol.Visibility = Visibility.Collapsed;
            backToMenu.Visibility = Visibility.Visible;

            firstNameTeacherBlock.Visibility = Visibility.Visible;
            firstNameTeacherBox.Visibility = Visibility.Visible;

            firstNameTeacherBlock.FontSize = 40;
            firstNameTeacherBox.Focus();
            firstNameTeacherBlock.Text = "Input Teacher's first name: ";
        }

        private void showStudents_Click(object sender, RoutedEventArgs e)
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        {

            AddObject.Visibility = Visibility.Collapsed;
            showSeparately.Visibility = Visibility.Collapsed;
            showAllPeople.Visibility = Visibility.Collapsed;
            showStudentsChoice.Visibility = Visibility.Visible;
            studentsChoiceColor.Visibility = Visibility.Visible;
            CenterShownStudents.Visibility = Visibility.Visible;
            CenterShownStudents.FontSize = 30;
            CenterShownStudents.HorizontalAlignment = HorizontalAlignment.Center;
            CenterShownStudents.VerticalAlignment = VerticalAlignment.Center;

            backToMenu.Visibility = Visibility.Visible;

            studentListView.Visibility = Visibility.Visible;

            List<Student> studentsList = new List<Student>();
            if (File.Exists(pathStudents))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathStudents);
                    if (string.IsNullOrWhiteSpace(fileContent))
                    {

                        studentListView.Visibility = Visibility.Collapsed;
                        CenterShownStudents.Text = "File is empty";
                    }
                    List<Student> students = JsonSerializer.Deserialize<List<Student>>(fileContent);
                    studentsList.AddRange(students);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here
                    MessageBox.Show($"Error: {ex.Message}");
                }

                studentListView.ItemsSource = studentsList;
            }
            else
            {
                studentListView.Visibility = Visibility.Collapsed;
                CenterShownStudents.Text = "No such file";
            }

            //StringBuilder everyStudent = new StringBuilder();
            //foreach (var i in students)
            //{
            //    everyStudent.AppendLine($"{i.Fname}, {i.Lname}, {i.Age}, {i.Id}, {i.Speciality}, {i.Course}");
            //}
            //CenterShownStudents.Text = everyStudent.ToString();
        }

<<<<<<< HEAD
        private void ShowTeachers_Click(object sender, RoutedEventArgs e)
=======
        private void showTeachers_Click(object sender, RoutedEventArgs e)
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        {

            AddObject.Visibility = Visibility.Collapsed;
            showSeparately.Visibility = Visibility.Collapsed;
            showAllPeople.Visibility = Visibility.Collapsed;
            showTeachersChoice.Visibility = Visibility.Visible;
            teachersChoiceColor.Visibility = Visibility.Visible;
            backToMenu.Visibility = Visibility.Visible;

            CenterShownTeachers.Visibility = Visibility.Visible;
            CenterShownTeachers.FontSize = 30;
            CenterShownTeachers.HorizontalAlignment = HorizontalAlignment.Center;
            CenterShownTeachers.VerticalAlignment = VerticalAlignment.Center;

            TeacherListView.Visibility = Visibility.Visible;


            List<Teacher> teachersList = new List<Teacher>();
            if (File.Exists(pathTeachers))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathTeachers);
                    if (string.IsNullOrWhiteSpace(fileContent))
                    {

                        TeacherListView.Visibility = Visibility.Collapsed;
                        CenterShownTeachers.Text = "File is empty";
                    }
                    List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
                    teachersList.AddRange(teachers);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here
                    MessageBox.Show($"Error: {ex.Message}");
                }

                TeacherListView.ItemsSource = teachersList;
            }
            else
            {
                TeacherListView.Visibility = Visibility.Collapsed;
                CenterShownTeachers.Text = "No such file";
            }
        }

<<<<<<< HEAD
    private void ShowAllPeople_Click(object sender, RoutedEventArgs e)
=======
        private void showAllPeople_Click(object sender, RoutedEventArgs e)
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
        {
            AddObject.Visibility = Visibility.Collapsed;
            showSeparately.Visibility = Visibility.Collapsed;
            showAllPeople.Visibility = Visibility.Collapsed;
            showStudentsChoice.Visibility = Visibility.Visible;
            showStudentsChoice.FontSize = 50;
            showTeachersCh.FontSize = 50;

            backToMenu.Visibility = Visibility.Visible;

            studentListView.Visibility = Visibility.Visible;

            TeacherListView.Visibility = Visibility.Visible;

            studentsChoiceColor.Visibility = Visibility.Visible;

            showTeachersCh.Visibility = Visibility.Visible;
            teachersChoice.Visibility = Visibility.Visible;
            //Grid.SetRow(CenterShownTeachers, 3);
            ShownTeachersText.FontSize = 30;
            ShownTeachersText.HorizontalAlignment = HorizontalAlignment.Center;
            ShownTeachersText.VerticalAlignment = VerticalAlignment.Center;

            CenterShownStudents.FontSize = 30;
            CenterShownStudents.HorizontalAlignment = HorizontalAlignment.Center;
            CenterShownStudents.VerticalAlignment = VerticalAlignment.Center;
            List<Teacher> teachersList = new List<Teacher>();
            if (File.Exists(pathTeachers))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathTeachers);
                    if (string.IsNullOrWhiteSpace(fileContent))
                    {

                        TeacherListView.Visibility = Visibility.Collapsed;

                        ShownTeachersText.Visibility = Visibility.Visible;
                        ShownTeachersText.Text = "File is empty";
                    }
                    List<Teacher> teachers = JsonSerializer.Deserialize<List<Teacher>>(fileContent);
                    teachersList.AddRange(teachers);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here
                    MessageBox.Show($"Error: {ex.Message}");
                }

                TeacherListView.ItemsSource = teachersList;
            }
            else
            {
                TeacherListView.Visibility = Visibility.Collapsed;

                ShownTeachersText.Visibility = Visibility.Visible;

                ShownTeachersText.Text = "No such file";
            }

            List<Student> studentsList = new List<Student>();
            if (File.Exists(pathStudents))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathStudents);
                    if (string.IsNullOrWhiteSpace(fileContent))
                    {

                        studentListView.Visibility = Visibility.Collapsed;
                        CenterShownStudents.Visibility = Visibility.Visible;
                        CenterShownStudents.Text = "File is empty";
                    }
                    List<Student> students = JsonSerializer.Deserialize<List<Student>>(fileContent);
                    studentsList.AddRange(students);
                }
                catch (Exception ex)
                {
                    // Handle any exceptions here
                    MessageBox.Show($"Error: {ex.Message}");
                }

                studentListView.ItemsSource = studentsList;
            }
            else
            {
                studentListView.Visibility = Visibility.Collapsed;
                CenterShownStudents.Visibility = Visibility.Visible;
                CenterShownStudents.Text = "No such file";
            }

            row0.Height = new GridLength(50);
            row2.Height = new GridLength(50);
            row4.Height = new GridLength(50);
            Grid.SetRow(TeacherListView, 3);
            Grid.SetRowSpan(studentListView, 1);
            Grid.SetRowSpan(TeacherListView, 1);

        }

        // ====================================================Student==========================================================================
<<<<<<< HEAD
        //private void firstNameStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        fname = firstNameBox.Text;
        //        e.Handled = true;
        //        if (string.IsNullOrEmpty(fname) || !fname.All(char.IsLetter))
        //        {
        //            fname = firstNameBox.Text;
        //        }
        //        else
        //        {
        //            firstNameBlock.Visibility = Visibility.Collapsed;
        //            firstNameBox.Visibility = Visibility.Collapsed;

        //            lastNameBox.Focus();
        //            lastNameBlock.Text = "Input student's last name:";
        //            lastNameBlock.FontSize = 40;
        //            lastNameBox.Visibility = Visibility.Visible;
        //            lastNameBlock.Visibility = Visibility.Visible;
        //        }

        //    }
        //}

        //private void lastNameStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        lname = lastNameBox.Text;
        //        e.Handled = true;
        //        if (string.IsNullOrEmpty(lname) || !lname.All(char.IsLetter))
        //        {
        //            lname = lastNameBox.Text;
        //        }
        //        else
        //        {
        //            lastNameBlock.Visibility = Visibility.Collapsed;
        //            lastNameBox.Visibility = Visibility.Collapsed;


        //            ageBlock.FontSize = 40;
        //            ageBox.Focus();
        //            ageBlock.Text = "Input Student's year:";
        //            ageBlock.Visibility = Visibility.Visible;
        //            ageBox.Visibility = Visibility.Visible;
        //        }

        //    }
        //}

        //private void ageStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        e.Handled = true;

        //        ageString = ageBox.Text;
        //        if (int.TryParse(ageString, out ageParsed))
        //        {

        //            ageBlock.Visibility = Visibility.Collapsed;
        //            ageBox.Visibility = Visibility.Collapsed;

        //            idBlock.FontSize = 40;
        //            idBox.Focus();
        //            idBlock.Text = "Input Student's ID:";
        //            idBlock.Visibility = Visibility.Visible;
        //            idBox.Visibility = Visibility.Visible;
        //        }
        //        else
        //        {
        //            ageBlock.Text = "Wrong number,Input Student's year:";
        //            ageString = ageBox.Text;
        //        }

        //    }
        //}

        //private void idStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        e.Handled = true;

        //        id = idBox.Text;
        //        if (long.TryParse(id, out idParsed) && id.Length == 10)
        //        {
        //            StudentExists = students.Any(person => person.Fname == fname && person.Lname == lname &&
        //                person.Age == ageParsed && person.Id == idParsed);
        //            if (!StudentExists)
        //            {
        //                idBlock.Visibility = Visibility.Collapsed;
        //                idBox.Visibility = Visibility.Collapsed;

        //                specBlock.FontSize = 40;
        //                specBox.Focus();
        //                specBlock.Text = "Input Student's speciality:";
        //                specBlock.Visibility = Visibility.Visible;
        //                specBox.Visibility = Visibility.Visible;
        //            }
        //            else
        //            {
        //                idBlock.Text = "Student already exists";
        //                id = idBox.Text;
        //            }

        //        }
        //        else
        //        {
        //            idBlock.Text = "EGN Must be 10 digits,Input Student's ID:";
        //            id = idBox.Text;
        //        }

        //    }

        //}

        //private void specStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        specString = specBox.Text;
        //        e.Handled = true;
        //        if (string.IsNullOrEmpty(specString) || !specString.All(char.IsLetter))
        //        {
        //            specString = specBox.Text;
        //        }
        //        else
        //        {
        //            specBlock.Visibility = Visibility.Collapsed;
        //            specBox.Visibility = Visibility.Collapsed;

        //            courseBlock.FontSize = 40;
        //            courseBox.Focus();
        //            courseBlock.Text = "Input Student's course:";
        //            courseBlock.Visibility = Visibility.Visible;
        //            courseBox.Visibility = Visibility.Visible;

        //        }


        //        //specBlock.Visibility = Visibility.Visible;
        //        //specBox.Visibility = Visibility.Visible;
        //    }
        //}

        //private void CourseBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        courseStringStudents = courseBox.Text;

        //        if (int.TryParse(courseStringStudents, out int course))
        //        {
        //            //StudentExists = students.Any(person => person.Fname == fname && person.Lname == lname &&
        //            //    person.Age == ageParsed && person.Id == idParsed &&
        //            //    person.Speciality == specString && person.Course == course);
        //            //if (StudentExists)
        //            //{
        //            //    courseBlock.Text = "Student already exists";
        //            //    courseStringStudents = courseBox.Text;
        //            //    int.TryParse(courseStringStudents, out course);
        //            //}
        //            //else
        //            //{
        //            courseBlock.FontSize = 60;
        //            courseBlock.Height = 85;
        //            courseBox.Visibility = Visibility.Hidden;
        //            Student student = new Student(fname, lname, ageParsed, idParsed, specString, course);
        //            students.Add(student);
        //            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions
        //            {
        //                WriteIndented = true
        //            });
        //            try
        //            {
        //                //json = json.Replace(Environment.NewLine, "\n");
        //                File.WriteAllText(pathStudents, json);
        //            }
        //            catch (Exception es)
        //            {
        //                CenterShownStudents.Text = es.Message;
        //            }
        //            finally
        //            {
        //                courseBlock.Text = "Student created succesfully";
        //            }
        //            //}

        //        }
        //        else
        //        {
        //            courseBlock.Text = "Invalid number, Input Student's course";
        //            courseStringStudents = courseBox.Text;
        //        }

        //    }
        //}
        // =========================================================Student======================================================================

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {

            WindowStudent windowStudent = new WindowStudent();
            windowStudent.Visibility = Visibility.Collapsed;
            windowStudent.Close();

            WindowTeacher windowTeacher = new WindowTeacher();
            windowTeacher.Visibility = Visibility.Collapsed;
            windowTeacher.Close();
            Visibility = Visibility.Collapsed;

            MainWindow mainWindow = new MainWindow();
            mainWindow.InitializeComponent();
            mainWindow.Show();


            //row0.Height = originalHeightRow0;
            //row1.Height = originalHeightRow1;
            //row2.Height = originalHeightRow2;
            //row3.Height = originalHeightRow3;
            //row4.Height = originalHeightRow4;

            //Grid.SetRow(TeacherListView, 1);
            //Grid.SetRowSpan(studentListView, 3);
            //Grid.SetRowSpan(TeacherListView, 3);

            //teachersChoice.Visibility = Visibility.Collapsed;
            //showTeachersCh.Visibility = Visibility.Collapsed;
            //showTeachers.Visibility = Visibility.Collapsed;
            //showStudentsChoice.Visibility = Visibility.Collapsed;
            //showTeachersChoice.Visibility = Visibility.Collapsed;
            //studentsChoiceColor.Visibility = Visibility.Collapsed;
            //teachersChoiceColor.Visibility = Visibility.Collapsed;
            //CenterShownStudents.Visibility = Visibility.Collapsed;
            //CenterShownTeachers.Visibility = Visibility.Collapsed;
            //studentListView.Visibility = Visibility.Collapsed;
            //TeacherListView.Visibility = Visibility.Collapsed;
            //ShownTeachersText.Visibility = Visibility.Collapsed;

            //
            //backToMenu.Visibility = Visibility.Collapsed;
            //firstNameBlock.Visibility = Visibility.Collapsed;
            //lastNameBlock.Visibility = Visibility.Collapsed;
            //firstNameBox.Visibility = Visibility.Collapsed;
            //lastNameBox.Visibility = Visibility.Collapsed;
            //ageBlock.Visibility = Visibility.Collapsed;
            //ageBox.Visibility = Visibility.Collapsed;
            //idBlock.Visibility = Visibility.Collapsed;
            //idBox.Visibility = Visibility.Collapsed;
            //specBlock.Visibility = Visibility.Collapsed;
            //specBox.Visibility = Visibility.Collapsed;
            //courseBlock.Visibility = Visibility.Collapsed;
            //courseBox.Visibility = Visibility.Collapsed;

            //firstNameTeacherBlock.Visibility = Visibility.Collapsed;
            //lastNameTeacherBlock.Visibility = Visibility.Collapsed;
            //firstNameTeacherBox.Visibility = Visibility.Collapsed;
            //lastNameTeacherBox.Visibility = Visibility.Collapsed;
            //ageTeacherBlock.Visibility = Visibility.Collapsed;
            //ageTeacherBox.Visibility = Visibility.Collapsed;
            //idTeacherBlock.Visibility = Visibility.Collapsed;
            //idTeacherBox.Visibility = Visibility.Collapsed;
            //yearsExperienceTeacherBlock.Visibility = Visibility.Collapsed;
            //yearsExperienceTeacherBox.Visibility = Visibility.Collapsed;
            //titleTeacherBlock.Visibility = Visibility.Collapsed;
            //titleTeacherBox.Visibility = Visibility.Collapsed;
            //specTeacherBlock.Visibility = Visibility.Collapsed;
            //specTeacherBox.Visibility = Visibility.Collapsed;

            //firstNameBox.Clear();
            //firstNameTeacherBox.Clear();
            //lastNameBox.Clear();
            //lastNameTeacherBox.Clear();
            //ageBox.Clear();
            //ageTeacherBox.Clear();
            //idBox.Clear();
            //idTeacherBox.Clear();
            //yearsExperienceTeacherBox.Clear();
            //titleTeacherBox.Clear();
            //specBox.Clear();
            //specTeacherBox.Clear();
            //courseBox.Clear();
        }
        // =====================================================Teacher==========================================================================
        //private void firstNameTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        fname = firstNameTeacherBox.Text;
        //        e.Handled = true;
        //        if (string.IsNullOrEmpty(fname) || !fname.All(char.IsLetter))
        //        {
        //            fname = firstNameTeacherBox.Text;
        //        }
        //        else
        //        {
        //            firstNameTeacherBlock.Visibility = Visibility.Collapsed;
        //            firstNameTeacherBox.Visibility = Visibility.Collapsed;

        //            lastNameTeacherBox.Focus();
        //            lastNameTeacherBlock.Text = "Input Teacher's last name:";
        //            lastNameTeacherBlock.FontSize = 40;
        //            lastNameTeacherBox.Visibility = Visibility.Visible;
        //            lastNameTeacherBlock.Visibility = Visibility.Visible;
        //        }

        //    }
        //}

        //private void lastNameTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        lname = lastNameTeacherBox.Text;
        //        e.Handled = true;
        //        if (string.IsNullOrEmpty(lname) || !lname.All(char.IsLetter))
        //        {
        //            lname = lastNameTeacherBox.Text;
        //        }
        //        else
        //        {
        //            lastNameTeacherBlock.Visibility = Visibility.Collapsed;
        //            lastNameTeacherBox.Visibility = Visibility.Collapsed;


        //            ageTeacherBlock.FontSize = 40;
        //            ageTeacherBox.Focus();
        //            ageTeacherBlock.Text = "Input Teacher's year:";
        //            ageTeacherBlock.Visibility = Visibility.Visible;
        //            ageTeacherBox.Visibility = Visibility.Visible;
        //        }

        //    }
        //}

        //private void ageTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        e.Handled = true;

        //        ageString = ageTeacherBox.Text;
        //        if (int.TryParse(ageString, out ageParsed))
        //        {

        //            ageTeacherBlock.Visibility = Visibility.Collapsed;
        //            ageTeacherBox.Visibility = Visibility.Collapsed;

        //            idTeacherBlock.FontSize = 40;
        //            idTeacherBox.Focus();
        //            idTeacherBlock.Text = "Input Teacher's ID:";
        //            idTeacherBlock.Visibility = Visibility.Visible;
        //            idTeacherBox.Visibility = Visibility.Visible;
        //        }
        //        else
        //        {
        //            ageTeacherBlock.Text = "Wrong number,Input Teacher's age:";
        //            ageString = ageTeacherBox.Text;
        //        }
        //    }
        //}

        //private void idTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        e.Handled = true;
        //        id = idTeacherBox.Text;

        //        if (long.TryParse(id, out idParsed) && id.Length == 10)
        //        {
        //            TeacherExists = teachers.Any(person => person.Fname == fname && person.Lname == lname &&
        //                person.Age == ageParsed && person.Id == idParsed);
        //            if (!TeacherExists)
        //            {
        //                idTeacherBlock.Visibility = Visibility.Collapsed;
        //                idTeacherBox.Visibility = Visibility.Collapsed;

        //                yearsExperienceTeacherBlock.FontSize = 40;
        //                yearsExperienceTeacherBox.Focus();
        //                yearsExperienceTeacherBlock.Text = "Input Teacher's work Experience:";
        //                yearsExperienceTeacherBlock.Visibility = Visibility.Visible;
        //                yearsExperienceTeacherBox.Visibility = Visibility.Visible;
        //            }
        //            else
        //            {
        //                idTeacherBlock.Text = "Teacher already exists";
        //                id = idTeacherBox.Text;
        //            }

        //        }


        //        else
        //        {
        //            idTeacherBlock.Text = "EGN Must be 10 digits,Input Teacher's ID:";
        //            id = idTeacherBox.Text;
        //        }

        //    }
        //}
        //private void yearsExperienceTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        e.Handled = true;
        //        experienceString = yearsExperienceTeacherBox.Text;
        //        if (int.TryParse(experienceString, out yearsExperience))
        //        {
        //            yearsExperienceTeacherBlock.Visibility = Visibility.Collapsed;
        //            yearsExperienceTeacherBox.Visibility = Visibility.Collapsed;

        //            titleTeacherBlock.FontSize = 40;
        //            titleTeacherBox.Focus();
        //            titleTeacherBlock.Text = "Input Teacher's title:";
        //            titleTeacherBlock.Visibility = Visibility.Visible;
        //            titleTeacherBox.Visibility = Visibility.Visible;
        //        }
        //        else
        //        {
        //            yearsExperienceTeacherBlock.FontSize = 30;
        //            yearsExperienceTeacherBlock.Text = "Wrong number,Input Teacher's work experience:";
        //            experienceString = yearsExperienceTeacherBox.Text;
        //        }
        //    }
        //}

        //private void titleTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        e.Handled = true;
        //        titleTeacher = titleTeacherBox.Text;
        //        if (string.IsNullOrEmpty(titleTeacher) || !titleTeacher.All(char.IsLetter))
        //        {
        //            titleTeacher = titleTeacherBox.Text;
        //        }
        //        else
        //        {
        //            titleTeacherBlock.Visibility = Visibility.Collapsed;
        //            titleTeacherBox.Visibility = Visibility.Collapsed;

        //            specTeacherBlock.FontSize = 40;
        //            specTeacherBox.Focus();
        //            specTeacherBlock.Text = "Input Teacher's speciality:";
        //            specTeacherBlock.Visibility = Visibility.Visible;
        //            specTeacherBox.Visibility = Visibility.Visible;
        //        }

        //    }
        //}

        //private void specTeacherBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == System.Windows.Input.Key.Enter)
        //    {
        //        specString = specTeacherBox.Text;
        //        if (!string.IsNullOrEmpty(specString) && specString.All(char.IsLetter))
        //        {
        //            //TeacherExists = teachers.Any(person => person.Fname == fname && person.Lname == lname &&
        //            //    person.Age == ageParsed && person.Id == idParsed && person.YearsExperience == yearsExperience &&
        //            //    person.Title == titleTeacher && person.Speciality == specString);
        //            //if (TeacherExists)
        //            //{
        //            //    specTeacherBlock.Text = "Teacher already exists";
        //            //    specString = specTeacherBox.Text;
        //            //}
        //            //else
        //            //{
        //            specTeacherBlock.Visibility = Visibility.Collapsed;
        //            specTeacherBox.Visibility = Visibility.Collapsed;
        //            Teacher teacher = new Teacher(fname, lname, ageParsed, idParsed, yearsExperience, titleTeacher, specString);
        //            teachers.Add(teacher);
        //            string json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions
        //            {
        //                WriteIndented = true
        //            });
        //            try
        //            {
        //                //json = json.Replace(Environment.NewLine, "\n");
        //                File.WriteAllText(pathTeachers, json);
        //            }
        //            catch (Exception es)
        //            {
        //                CenterShownStudents.Text = es.Message;
        //            }
        //            finally
        //            {
        //                specTeacherBlock.Visibility = Visibility.Visible;
        //                specTeacherBlock.Text = "Teacher created succesfully";
        //            }
        //            //}

        //        }

        //    }
        //    else
        //    {
        //        specTeacherBlock.Text = "Input Teacher's speciality:";
        //        specString = specTeacherBox.Text;
        //    }

        //}
=======
        private void firstNameStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                    firstNameBlock.Visibility = Visibility.Collapsed;
                    firstNameBox.Visibility = Visibility.Collapsed;

                    lastNameBox.Focus();
                    lastNameBlock.Text = "Input student's last name:";
                    lastNameBlock.FontSize = 40;
                    lastNameBox.Visibility = Visibility.Visible;
                    lastNameBlock.Visibility = Visibility.Visible;
                }

            }
        }

        private void lastNameStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
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
                    lastNameBlock.Visibility = Visibility.Collapsed;
                    lastNameBox.Visibility = Visibility.Collapsed;


                    ageBlock.FontSize = 40;
                    ageBox.Focus();
                    ageBlock.Text = "Input Student's year:";
                    ageBlock.Visibility = Visibility.Visible;
                    ageBox.Visibility = Visibility.Visible;
                }

            }
        }

        private void ageStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;

                ageString = ageBox.Text;
                if (int.TryParse(ageString, out ageParsed))
                {

                    ageBlock.Visibility = Visibility.Collapsed;
                    ageBox.Visibility = Visibility.Collapsed;

                    idBlock.FontSize = 40;
                    idBox.Focus();
                    idBlock.Text = "Input Student's ID:";
                    idBlock.Visibility = Visibility.Visible;
                    idBox.Visibility = Visibility.Visible;
                }
                else
                {
                    ageBlock.Text = "Wrong number,Input Student's year:";
                    ageString = ageBox.Text;
                }

            }
        }

        private void idStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;

                id = idBox.Text;
                if (long.TryParse(id, out idParsed) && id.Length == 10)
                {
                    StudentExists = students.Any(person => person.Fname == fname && person.Lname == lname &&
                        person.Age == ageParsed && person.Id == idParsed);
                    if (!StudentExists)
                    {
                        idBlock.Visibility = Visibility.Collapsed;
                        idBox.Visibility = Visibility.Collapsed;

                        specBlock.FontSize = 40;
                        specBox.Focus();
                        specBlock.Text = "Input Student's speciality:";
                        specBlock.Visibility = Visibility.Visible;
                        specBox.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        idBlock.Text = "Student already exists";
                        id = idBox.Text;
                    }

                }
                else
                {
                    idBlock.Text = "EGN Must be 10 digits,Input Student's ID:";
                    id = idBox.Text;
                }

            }

        }

        private void specStudentsBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                specString = specBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(specString) || !specString.All(char.IsLetter))
                {
                    specString = specBox.Text;
                }
                else
                {
                    specBlock.Visibility = Visibility.Collapsed;
                    specBox.Visibility = Visibility.Collapsed;

                    courseBlock.FontSize = 40;
                    courseBox.Focus();
                    courseBlock.Text = "Input Student's course:";
                    courseBlock.Visibility = Visibility.Visible;
                    courseBox.Visibility = Visibility.Visible;

                }


                //specBlock.Visibility = Visibility.Visible;
                //specBox.Visibility = Visibility.Visible;
            }
        }

        private void courseBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                courseStringStudents = courseBox.Text;

                if (int.TryParse(courseStringStudents, out int course))
                {
                    //StudentExists = students.Any(person => person.Fname == fname && person.Lname == lname &&
                    //    person.Age == ageParsed && person.Id == idParsed &&
                    //    person.Speciality == specString && person.Course == course);
                    //if (StudentExists)
                    //{
                    //    courseBlock.Text = "Student already exists";
                    //    courseStringStudents = courseBox.Text;
                    //    int.TryParse(courseStringStudents, out course);
                    //}
                    //else
                    //{
                    courseBlock.FontSize = 60;
                    courseBlock.Height = 85;
                    courseBox.Visibility = Visibility.Hidden;
                    Student student = new Student(fname, lname, ageParsed, idParsed, specString, course);
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
                        CenterShownStudents.Text = es.Message;
                    }
                    finally
                    {
                        courseBlock.Text = "Student created succesfully";
                    }
                    //}

                }
                else
                {
                    courseBlock.Text = "Invalid number, Input Student's course";
                    courseStringStudents = courseBox.Text;
                }

            }
        }
        // =========================================================Student======================================================================

        private void backToMenu_Click(object sender, RoutedEventArgs e)
        {
            row0.Height = originalHeightRow0;
            row1.Height = originalHeightRow1;
            row2.Height = originalHeightRow2;
            row3.Height = originalHeightRow3;
            row4.Height = originalHeightRow4;

            Grid.SetRow(TeacherListView, 1);
            Grid.SetRowSpan(studentListView, 3);
            Grid.SetRowSpan(TeacherListView, 3);

            teachersChoice.Visibility = Visibility.Collapsed;
            showTeachersCh.Visibility = Visibility.Collapsed;
            showTeachers.Visibility = Visibility.Collapsed;
            showStudentsChoice.Visibility = Visibility.Collapsed;
            showTeachersChoice.Visibility = Visibility.Collapsed;
            studentsChoiceColor.Visibility = Visibility.Collapsed;
            teachersChoiceColor.Visibility = Visibility.Collapsed;
            CenterShownStudents.Visibility = Visibility.Collapsed;
            CenterShownTeachers.Visibility = Visibility.Collapsed;
            studentListView.Visibility = Visibility.Collapsed;
            TeacherListView.Visibility = Visibility.Collapsed;
            ShownTeachersText.Visibility = Visibility.Collapsed;

            AddObject.Visibility = Visibility.Visible;
            showSeparately.Visibility = Visibility.Visible;
            ShowPeople.Visibility = Visibility.Visible;
            showTeachers.Visibility = Visibility.Visible;
            showAllPeople.Visibility = Visibility.Visible;
            botCol.Visibility = Visibility.Visible;
            backToMenu.Visibility = Visibility.Collapsed;
            firstNameBlock.Visibility = Visibility.Collapsed;
            lastNameBlock.Visibility = Visibility.Collapsed;
            firstNameBox.Visibility = Visibility.Collapsed;
            lastNameBox.Visibility = Visibility.Collapsed;
            ageBlock.Visibility = Visibility.Collapsed;
            ageBox.Visibility = Visibility.Collapsed;
            idBlock.Visibility = Visibility.Collapsed;
            idBox.Visibility = Visibility.Collapsed;
            specBlock.Visibility = Visibility.Collapsed;
            specBox.Visibility = Visibility.Collapsed;
            courseBlock.Visibility = Visibility.Collapsed;
            courseBox.Visibility = Visibility.Collapsed;

            firstNameTeacherBlock.Visibility = Visibility.Collapsed;
            lastNameTeacherBlock.Visibility = Visibility.Collapsed;
            firstNameTeacherBox.Visibility = Visibility.Collapsed;
            lastNameTeacherBox.Visibility = Visibility.Collapsed;
            ageTeacherBlock.Visibility = Visibility.Collapsed;
            ageTeacherBox.Visibility = Visibility.Collapsed;
            idTeacherBlock.Visibility = Visibility.Collapsed;
            idTeacherBox.Visibility = Visibility.Collapsed;
            yearsExperienceTeacherBlock.Visibility = Visibility.Collapsed;
            yearsExperienceTeacherBox.Visibility = Visibility.Collapsed;
            titleTeacherBlock.Visibility = Visibility.Collapsed;
            titleTeacherBox.Visibility = Visibility.Collapsed;
            specTeacherBlock.Visibility = Visibility.Collapsed;
            specTeacherBox.Visibility = Visibility.Collapsed;

            firstNameBox.Clear();
            firstNameTeacherBox.Clear();
            lastNameBox.Clear();
            lastNameTeacherBox.Clear();
            ageBox.Clear();
            ageTeacherBox.Clear();
            idBox.Clear();
            idTeacherBox.Clear();
            yearsExperienceTeacherBox.Clear();
            titleTeacherBox.Clear();
            specBox.Clear();
            specTeacherBox.Clear();
            courseBox.Clear();
        }
        // =====================================================Teacher==========================================================================
        private void firstNameTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                fname = firstNameTeacherBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(fname) || !fname.All(char.IsLetter))
                {
                    fname = firstNameTeacherBox.Text;
                }
                else
                {
                    firstNameTeacherBlock.Visibility = Visibility.Collapsed;
                    firstNameTeacherBox.Visibility = Visibility.Collapsed;

                    lastNameTeacherBox.Focus();
                    lastNameTeacherBlock.Text = "Input Teacher's last name:";
                    lastNameTeacherBlock.FontSize = 40;
                    lastNameTeacherBox.Visibility = Visibility.Visible;
                    lastNameTeacherBlock.Visibility = Visibility.Visible;
                }

            }
        }

        private void lastNameTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                lname = lastNameTeacherBox.Text;
                e.Handled = true;
                if (string.IsNullOrEmpty(lname) || !lname.All(char.IsLetter))
                {
                    lname = lastNameTeacherBox.Text;
                }
                else
                {
                    lastNameTeacherBlock.Visibility = Visibility.Collapsed;
                    lastNameTeacherBox.Visibility = Visibility.Collapsed;


                    ageTeacherBlock.FontSize = 40;
                    ageTeacherBox.Focus();
                    ageTeacherBlock.Text = "Input Teacher's year:";
                    ageTeacherBlock.Visibility = Visibility.Visible;
                    ageTeacherBox.Visibility = Visibility.Visible;
                }

            }
        }

        private void ageTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;

                ageString = ageTeacherBox.Text;
                if (int.TryParse(ageString, out ageParsed))
                {

                    ageTeacherBlock.Visibility = Visibility.Collapsed;
                    ageTeacherBox.Visibility = Visibility.Collapsed;

                    idTeacherBlock.FontSize = 40;
                    idTeacherBox.Focus();
                    idTeacherBlock.Text = "Input Teacher's ID:";
                    idTeacherBlock.Visibility = Visibility.Visible;
                    idTeacherBox.Visibility = Visibility.Visible;
                }
                else
                {
                    ageTeacherBlock.Text = "Wrong number,Input Teacher's age:";
                    ageString = ageTeacherBox.Text;
                }
            }
        }

        private void idTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                id = idTeacherBox.Text;

                if (long.TryParse(id, out idParsed) && id.Length == 10)
                {
                    TeacherExists = teachers.Any(person => person.Fname == fname && person.Lname == lname &&
                        person.Age == ageParsed && person.Id == idParsed);
                    if (!TeacherExists)
                    {
                        idTeacherBlock.Visibility = Visibility.Collapsed;
                        idTeacherBox.Visibility = Visibility.Collapsed;

                        yearsExperienceTeacherBlock.FontSize = 40;
                        yearsExperienceTeacherBox.Focus();
                        yearsExperienceTeacherBlock.Text = "Input Teacher's work Experience:";
                        yearsExperienceTeacherBlock.Visibility = Visibility.Visible;
                        yearsExperienceTeacherBox.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        idTeacherBlock.Text = "Teacher already exists";
                        id = idTeacherBox.Text;
                    }

                }


                else
                {
                    idTeacherBlock.Text = "EGN Must be 10 digits,Input Teacher's ID:";
                    id = idTeacherBox.Text;
                }

            }
        }
        private void yearsExperienceTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                experienceString = yearsExperienceTeacherBox.Text;
                if (int.TryParse(experienceString, out yearsExperience))
                {
                    yearsExperienceTeacherBlock.Visibility = Visibility.Collapsed;
                    yearsExperienceTeacherBox.Visibility = Visibility.Collapsed;

                    titleTeacherBlock.FontSize = 40;
                    titleTeacherBox.Focus();
                    titleTeacherBlock.Text = "Input Teacher's title:";
                    titleTeacherBlock.Visibility = Visibility.Visible;
                    titleTeacherBox.Visibility = Visibility.Visible;
                }
                else
                {
                    yearsExperienceTeacherBlock.FontSize = 30;
                    yearsExperienceTeacherBlock.Text = "Wrong number,Input Teacher's work experience:";
                    id = idTeacherBox.Text;
                }
            }
        }

        private void titleTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                e.Handled = true;
                titleTeacher = titleTeacherBox.Text;
                if (string.IsNullOrEmpty(titleTeacher) || !titleTeacher.All(char.IsLetter))
                {
                    titleTeacher = titleTeacherBox.Text;
                }
                else
                {
                    titleTeacherBlock.Visibility = Visibility.Collapsed;
                    titleTeacherBox.Visibility = Visibility.Collapsed;

                    specTeacherBlock.FontSize = 40;
                    specTeacherBox.Focus();
                    specTeacherBlock.Text = "Input Teacher's speciality:";
                    specTeacherBlock.Visibility = Visibility.Visible;
                    specTeacherBox.Visibility = Visibility.Visible;
                }

            }
        }

        private void specTeacherBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                specString = specTeacherBox.Text;
                if (!string.IsNullOrEmpty(specString) && specString.All(char.IsLetter))
                {
                    //TeacherExists = teachers.Any(person => person.Fname == fname && person.Lname == lname &&
                    //    person.Age == ageParsed && person.Id == idParsed && person.YearsExperience == yearsExperience &&
                    //    person.Title == titleTeacher && person.Speciality == specString);
                    //if (TeacherExists)
                    //{
                    //    specTeacherBlock.Text = "Teacher already exists";
                    //    specString = specTeacherBox.Text;
                    //}
                    //else
                    //{
                    specTeacherBlock.Visibility = Visibility.Collapsed;
                    specTeacherBox.Visibility = Visibility.Collapsed;
                    Teacher teacher = new Teacher(fname, lname, ageParsed, idParsed, yearsExperience, titleTeacher, specString);
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
                        CenterShownStudents.Text = es.Message;
                    }
                    finally
                    {
                        specTeacherBlock.Visibility = Visibility.Visible;
                        specTeacherBlock.Text = "Teacher created succesfully";
                    }
                    //}

                }

            }
            else
            {
                specTeacherBlock.Text = "Input Teacher's speciality:";
                specString = specTeacherBox.Text;
            }

        }
    }
}

public class Student
{
    private string fname;

    public string Fname
    {
        get
        {
            return fname;
        }
        set
        {
            fname = value;
        }
    }
    public string Lname { get; set; }
    public int Age { get; set; }
    public long Id { get; set; }
    public string Speciality { get; set; }
    public int Course { get; set; }

    public Student(string fname, string lname, int age, long id, string speciality, int course)
    {
        Fname = fname;
        Lname = lname;
        Age = age;
        Id = id;
        Speciality = speciality;
        Course = course;
    }
}

public class Teacher
{
    public string Fname { get; set; }
    public string Lname { get; set; }
    public int Age { get; set; }
    public long Id { get; set; }
    public int YearsExperience { get; set; }
    public string Title { get; set; }
    public string Speciality { get; set; }

    public Teacher(string fname, string lname, int age, long id, int yearsExperience, string title, string speciality)
    {
        Fname = fname;
        Lname = lname;
        Age = age;
        Id = id;
        YearsExperience = yearsExperience;
        Title = title;
        Speciality = speciality;
>>>>>>> d0ae06a9cb8fd17fad8c791b956f0716bcfa84aa
    }
}

