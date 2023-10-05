using System.Collections.Generic;
using System.Text.Json;
using System;
using System.Windows;
using System.IO;
using WpfApp1.Model;
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
            if (!File.Exists(pathStudents))
            {
                File.Create(pathStudents);
            }
            if (!File.Exists(pathTeachers))
            {
                File.Create(pathTeachers);
            }
        }
        private void AddStudents_Click(object sender, RoutedEventArgs e)
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
            WindowStudent student = new WindowStudent();
            student.InitializeComponent();
            student.firstNameBox.Focus();
            student.Show();
            Close();
        }
        private void AddTeachers_Click(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(pathTeachers))
            {
                File.Create(pathTeachers);
                string defaultFile = "[]";
                File.WriteAllText(pathTeachers, defaultFile);
            }
            if (string.IsNullOrWhiteSpace(File.ReadAllText(pathTeachers)))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathTeachers, defaultFile);

            }
            WindowTeacher windowTeacher = new WindowTeacher();
            windowTeacher.InitializeComponent();
            windowTeacher.firstNameBox.Focus();
            windowTeacher.Show();
            Close();
        }

        private void ShowStudents_Click(object sender, RoutedEventArgs e)
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

            if (string.IsNullOrWhiteSpace(File.ReadAllText(pathStudents)))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathStudents, defaultFile);

            }
            else if (File.Exists(pathStudents))
            {
                try
                {

                    string fileContent = File.ReadAllText(pathStudents);
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
        private void ShowTeachers_Click(object sender, RoutedEventArgs e)
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
            if (!File.Exists(pathTeachers))
            {
                File.Create(pathTeachers);
                string defaultFile = "[]";
                File.WriteAllText(pathTeachers, defaultFile);
            }
            if (string.IsNullOrWhiteSpace(File.ReadAllText(pathTeachers)))
            {
                string defaultFile = "[]";
                File.WriteAllText(pathTeachers, defaultFile);

            }
            else if (File.Exists(pathTeachers))
            {
                try
                {
                    string fileContent = File.ReadAllText(pathTeachers);
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
        private void ShowAllPeople_Click(object sender, RoutedEventArgs e)
        {
            showStudentsChoice.Visibility = Visibility.Visible;
            showStudentsChoice.FontSize = 50;
            showStudentsChoice.Text = "All created people";
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
        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.InitializeComponent();
            mainWindow.Show();
            Close();
        }
    }
}