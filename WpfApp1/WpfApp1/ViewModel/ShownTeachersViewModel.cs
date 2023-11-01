using System.Collections.Generic;
using People.Database.Models;
using People.Database.Services;

namespace WpfApp1.ViewModel
{
    public class ShownTeachersViewModel : MainWindowViewModel
    {
        List<Teacher> teachers = new List<Teacher>();
        public ShownTeachersViewModel()
        {
            Service s = new();
            teachers = s.GetTeachersService();
        }
        public List<Teacher> Teachers
        {
            get { return teachers; }
        }
    }
}
