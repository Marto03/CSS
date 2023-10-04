using System.Collections.Generic;
using System.Text.Json;
using System;
using System.Windows;
using System.IO;
using WpfApp1.Models;
 //                                 Must add MVVM model-view-viewmodel
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private string pathStudents = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfStudents.json";
        private string pathTeachers = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfTeachers.json";
        private string pathPeople = "C:\\Users\\Microinvest\\source\\repos\\FileCreating\\WpfallPeople.json";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addStudents_Click(object sender, RoutedEventArgs e)
        {
            if(!File.Exists(pathStudents))
            {
                File.Create(pathStudents);
            }
            WindowStudent student = new WindowStudent();
            student.InitializeComponent();
            student.firstNameBox.Focus();
            student.Show();
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

            if (!File.Exists(pathStudents))
            {
                File.Create(pathStudents);
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);

            }

            string fileContent = File.ReadAllText(pathStudents);
            if (string.IsNullOrWhiteSpace(fileContent))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);

            }
            else if (File.Exists(pathStudents))
            {
                try
                {
                    
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
                    MessageBox.Show($"Error: {ex.Message}");
                }
                studentListView.ItemsSource = studentsList;
            }
            else
            {
                studentListView.Visibility = Visibility.Collapsed;
                CenterShownStudents.Text = "No such file";
            }
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
            //                                                  Must fix that
            //if (!File.Exists(pathTeachers))
            //{
            //    File.Create(pathTeachers);
            //    string defaultFile = "[]";
            //    File.WriteAllText(pathTeachers, defaultFile);
            //}
            //else if (File.ReadAllText(pathTeachers).Equals(null))
            //{
            //    string defaultFile = "[]";
            //    File.WriteAllText(pathTeachers, defaultFile);

            //}
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
            showStudentsChoice.Visibility = Visibility.Visible;
            showStudentsChoice.FontSize = 50;
            showTeachersCh.FontSize = 50;
            backToMenu.Visibility = Visibility.Visible;
            PeopleListView.Visibility = Visibility.Visible;
            studentsChoiceColor.Visibility = Visibility.Visible;
            row0.Height = new GridLength(50);
            row2.Height = new GridLength(50);
            row4.Height = new GridLength(50);

            List<BothPeople> bothPeople = new List<BothPeople>();
            if (File.Exists(pathPeople))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathPeople);
                    if (string.IsNullOrWhiteSpace(fileContent))
                    {
                        TeacherListView.Visibility = Visibility.Collapsed;
                        ShownTeachersText.Visibility = Visibility.Visible;
                        ShownTeachersText.Text = "File is empty";
                    }
                    List<BothPeople> peoples = JsonSerializer.Deserialize<List<BothPeople>>(fileContent);
                    bothPeople.AddRange(peoples);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
                PeopleListView.ItemsSource = bothPeople;
            }
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