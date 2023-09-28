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
using WpfApp1.Models;

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
        string pathStudents = "D:\\C#\\RandomFileCreating\\WpfStudents.json";
        string pathTeachers = "D:\\C#\\RandomFileCreating\\WpfTeachers.json";
        //string pathPeople = "D:\\C#\\Random file creating\\WpfallPeople.json";
        private GridLength originalHeightRow0;
        private GridLength originalHeightRow1;
        private GridLength originalHeightRow2;
        private GridLength originalHeightRow3;
        private GridLength originalHeightRow4;
        public MainWindow()
        {

            InitializeComponent();
        }

        private void addStudents_Click(object sender, RoutedEventArgs e)
        {

            WindowStudent student = new WindowStudent();
            student.InitializeComponent();
            student.firstNameBox.Focus();
            student.Show();
            student.firstNameBox.Focus();
            Close();


        }

        private void addTeachers_Click(object sender, RoutedEventArgs e)
        {

            WindowTeacher windowTeacher = new WindowTeacher();
            windowTeacher.InitializeComponent();
            windowTeacher.firstNameBox.Focus();
            windowTeacher.Show();
            Close();
        }

        private void showStudents_Click(object sender, RoutedEventArgs e)
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

        private void showTeachers_Click(object sender, RoutedEventArgs e)
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

        private void showAllPeople_Click(object sender, RoutedEventArgs e)
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


        private void backToMenu_Click(object sender, RoutedEventArgs e)
        {

            WindowStudent windowStudent = new WindowStudent();
            windowStudent.Visibility = Visibility.Collapsed;
            windowStudent.Close();

            WindowTeacher windowTeacher = new WindowTeacher();
            windowTeacher.Visibility = Visibility.Collapsed;
            windowTeacher.Close();

            MainWindow mainWindow = new MainWindow();
            mainWindow.InitializeComponent();
            mainWindow.Show();
            Close();

        }

    }
}


