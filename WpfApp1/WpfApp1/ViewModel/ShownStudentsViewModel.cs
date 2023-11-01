using System.Collections.Generic;
using People.Database.Models;
using People.Database.Services;

namespace WpfApp1.ViewModel
{
    public class ShownStudentsViewModel : MainWindowViewModel
    {
        List<Student> students = new List<Student>();
        public ShownStudentsViewModel()
        {
            Service s = new();
            students = s.GetStudentsService();
        }
        public List<Student> Students
        {
            get { return students; }
        }
    }
}
