using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WpfApp1.Model.Context
{
    public class PubContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Sourse = (localdb)\\MSSQLLocalDB;Initial Catalog = PubDatabase");
            /*"Data Sourse = (localdb)\\MSSQLLocalDB;*/
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PubDatabase;Encrypt=False;Integrated Security=SSPI;");
        }
    }
}
