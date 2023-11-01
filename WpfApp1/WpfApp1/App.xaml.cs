using Microsoft.EntityFrameworkCore;
using People.Database;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
        /*
         * Service must be added to WpfApp1 project, 
         * repositories of student and teacher must be in Peoples.Database
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
        }
    }
}
