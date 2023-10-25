using System.Linq;
using System.Windows;
using WpfApp1.Model;
using WpfApp1.Model.Context;

namespace WpfApp1
{
    public partial class App : Application
    {
        /*
         * Service must be added to WpfApp1 project, 
         * repositories of student and teacher must be in People.Database
         * maybe interfaces as well there ,
         * Context must be there as well
         */
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            using (var context = new PubContext())
            {
                context.Database.EnsureCreated();
            }

            //AddStudent();

            //void AddStudent()
            //{
            //    using var context = new PubContext();
            //    var students = context.Students.ToList();
            //}
        }
    }
}
