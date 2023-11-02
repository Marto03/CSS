using Microsoft.EntityFrameworkCore;
using People.Database;
using System.Windows;

namespace WpfApp1
{
    public partial class App : Application
    {
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
