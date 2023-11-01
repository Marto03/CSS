using System.Text.Json;

class Program
{

    public static void ShowStudents(List<Student> student)
    {
        if (student.Count == 0)
        {
            Console.WriteLine("No students");
            return;
        }
        foreach (var i in student)
        {
            Console.WriteLine($"{i.Fname}, {i.Lname}, {i.Age}, {i.Id}, {i.Speciality}, {i.Course}");
        }


    }
    public static void ShowTeachers(List<Teacher> teacher)
    {
        if (teacher.Count == 0) Console.WriteLine("No teachers");
        foreach (var i in teacher)
        {
            Console.WriteLine($"{i.Fname}, {i.Lname}, {i.Age}, {i.Id}, {i.YearsExperience}, {i.Title} , {i.Speciality}");
        }
    }


    public static void ShowAllPeople(List<object> bothList)
    {

        if (bothList.Count == 0) { Console.WriteLine("No people"); }
        foreach (var i in bothList)
        {
            if (i is Student)
            {
                var student = (Student)i;
                Console.WriteLine("Student:");
                Console.WriteLine($"{student.Fname}, {student.Lname}, {student.Age}, {student.Id}, {student.Speciality}, {student.Course}");
                //sr.WriteLine($"{student.Fname}, {student.Lname}, {student.Age}, {student.Id}, {student.Speciality}, {student.Course}");
            }
            else if (i is Teacher)
            {
                var teacher = (Teacher)i;
                Console.WriteLine("Teacher:");
                Console.WriteLine($"{teacher.Fname}, {teacher.Lname}, {teacher.Age}, {teacher.Id}, {teacher.YearsExperience}, {teacher.Title} , {teacher.Speciality}");
                //sr.WriteLine($"{teacher.Fname}, {teacher.Lname}, {teacher.Age}, {teacher.Id}, {teacher.YearsExperience}, {teacher.Title} , {teacher.Speciality}");
            }
        }
    }
    private static void Main(string[] args)
    {

        int choice;
        bool flagStop = false;
        bool shownAllPeople = false;
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<object> bothList = new List<object>();
        var path = "D:\\C#\\Random file creating\\people.json";
        var path1 = "C:\\Users\\Microinvest\\Desktop\\Example\\people.json";
        var path2 = "C:\\Users\\Microinvest\\Desktop\\Example\\people.txt";
        //StreamWriter sr = new StreamWriter(path);
        //StreamWriter sr = null;
        do
        {

            Console.WriteLine("(1)Add Student or (2)Add Teacher or (3)To Show all students\n(4)To show all teachers (5)To show all people (6)To exit:");
            string inp = Console.ReadLine();

            if (int.TryParse(inp, out choice))
            {
                if (choice == 1)
                {
                    flagStop = false;
                    Console.Write("Input Student's first name:");
                    string fname = Console.ReadLine();

                    Console.Write("Input Student's last name:");
                    string lname = Console.ReadLine();

                    Console.Write("Input Student's year:");
                    string yearString = Console.ReadLine();
                    int year, course;
                    long id;
                    while (!int.TryParse(yearString, out year))
                    {
                        Console.WriteLine("Wrong input");
                        Console.Write("Input Student's year:");
                        yearString = Console.ReadLine();
                        //flag = false;
                        //continue;
                    }
                    Console.Write("Input Student's id:");
                    string idString = Console.ReadLine();
                    while (!long.TryParse(idString, out id) || idString.Length != 10)
                    {
                        Console.WriteLine("Wrong input");
                        Console.Write("Input Student's id:");
                        idString = Console.ReadLine();
                    }

                    Console.Write("Input Student's speciality:");
                    string speciality = Console.ReadLine();

                    Console.Write("Input Student's course:");
                    string courseString = Console.ReadLine();
                    while (!int.TryParse(courseString, out course))
                    {
                        Console.WriteLine("Wrong input");
                        Console.Write("Input Student's course:");
                        courseString = Console.ReadLine();

                    }
                    Student student = new Student(fname, lname, year, id, speciality, course);
                    students.Add(student);
                }
                else if (choice == 2)
                {
                    flagStop = false;
                    Console.Write("Input Teacher's first name:");
                    string fname = Console.ReadLine();

                    Console.Write("Input Teacher's last name:");
                    string lname = Console.ReadLine();

                    Console.Write("Input Teacher's year:");
                    string yearString = Console.ReadLine();
                    int year, workExperience;
                    long id;
                    while (!int.TryParse(yearString, out year))
                    {
                        Console.WriteLine("Wrong input");
                        Console.Write("Input Teacher's year:");
                        yearString = Console.ReadLine();
                        //flag = false;
                        //continue;
                    }
                    Console.Write("Input Teacher's id:");
                    string idString = Console.ReadLine();
                    while (!long.TryParse(idString, out id) || idString.Length != 10)
                    {
                        Console.WriteLine("Wrong input");
                        Console.Write("Input Teacher's id:");
                        idString = Console.ReadLine();
                    }
                    //string idS = id.ToString();
                    //int idN = idS.Length;
                    //while (idN != 10)
                    //{
                    //    Console.WriteLine("Wrong input");
                    //    Console.Write("Input Student's Id:");
                    //    idString = Console.ReadLine();
                    //    idS = id.ToString();
                    //    idN = idS.Length;
                    //}
                    Console.Write("Input Teacher's workExperience:");
                    string workExperienceString = Console.ReadLine();
                    while (!int.TryParse(workExperienceString, out workExperience))
                    {
                        Console.WriteLine("Wrong input");
                        Console.Write("Input Teacher's workExperience:");
                        workExperienceString = Console.ReadLine();
                    }

                    Console.Write("Input Teacher's title:");
                    string title = Console.ReadLine();

                    Console.Write("Input Teacher's speciality:");
                    string speciality = Console.ReadLine();

                    Teacher teacher = new Teacher(fname, lname, year, id, workExperience, title, speciality);
                    teachers.Add(teacher);

                    //string joinedStudent = string.Join(", ", students);
                    //Console.WriteLine(students);

                }
                else if (choice == 3)
                {
                    ShowStudents(students);
                }
                else if (choice == 4)
                {
                    ShowTeachers(teachers);
                }
                else if (choice == 5)
                {
                    if (shownAllPeople == false)
                    {

                        bothList.AddRange(students);
                        bothList.AddRange(teachers);
                        shownAllPeople = true;
                    }

                    ShowAllPeople(bothList);

                }
                else if (choice == 6)
                {
                    flagStop = true;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice");
                flagStop = false;
                continue;
            }

        } while (!flagStop);
        if (shownAllPeople == false)
        {
            bothList.AddRange(students);
            bothList.AddRange(teachers);
        }
        try
        {
            var json = JsonSerializer.Serialize(bothList);
            json = json.Replace(Environment.NewLine, " ");
            File.AppendAllText(path, json);

            //sr = File.AppendText(path);
            //foreach(var i in bothList)
            //{
            //    if (i is Student)
            //    {
            //        var student = (Student)i;
            //        sr.WriteLine($"{student.Fname}, {student.Lname}, {student.Age}, {student.Id}, {student.Speciality}, {student.Course}");
            //    }
            //    else if (i is Teacher)
            //    {
            //        var teacher = (Teacher)i;
            //        sr.WriteLine($"{teacher.Fname}, {teacher.Lname}, {teacher.Age}, {teacher.Id}, {teacher.YearsExperience}, {teacher.Title} , {teacher.Speciality}");
            //    }
            //}



            //string readJson = File.ReadAllText(path);
            //List<object> readList = JsonSerializer.Deserialize<List<object>>(readJson);
            //foreach (var i in readList)
            //{
            //    if (i is Student)
            //    {
            //        var student = (Student)i;
            //        Console.WriteLine($"{student.Fname}, {student.Lname}, {student.Age}, {student.Id}, {student.Speciality}, {student.Course}");

            //    }
            //    else if (i is Teacher)
            //    {
            //        var teacher = (Teacher)i;
            //        Console.WriteLine($"{teacher.Fname}, {teacher.Lname}, {teacher.Age}, {teacher.Id}, {teacher.YearsExperience}, {teacher.Title} , {teacher.Speciality}");
            //    }
            //}

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //try
        //{
        //    sr = File.AppendText(path);
        //    foreach (var i in bothList)
        //    {
        //        if (i is Student)
        //        {
        //            var student = (Student)i;
        //            Console.WriteLine($"{student.Fname}, {student.Lname}, {student.Age}, {student.Id}, {student.Speciality}, {student.Course}");
        //            sr.WriteLine($"{student.Fname}, {student.Lname}, {student.Age}, {student.Id}, {student.Speciality}, {student.Course}");
        //        }
        //        else if (i is Teacher)
        //        {
        //            var teacher = (Teacher)i;
        //            Console.WriteLine($"{teacher.Fname}, {teacher.Lname}, {teacher.Age}, {teacher.Id}, {teacher.YearsExperience}, {teacher.Title} , {teacher.Speciality}");
        //            sr.WriteLine($"{teacher.Fname}, {teacher.Lname}, {teacher.Age}, {teacher.Id}, {teacher.YearsExperience}, {teacher.Title} , {teacher.Speciality}");
        //        }
        //    }
        //}
        //catch(Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
        //finally
        //{
        //    if(sr != null)
        //    {
        //        sr.Close();
        //    }
        //}
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
    }
}