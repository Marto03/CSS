using Microsoft.EntityFrameworkCore;
namespace People.Database
{
    public class PubContext : DbContext
    {
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PubDatabase;Encrypt=False;Integrated Security=SSPI;");
        }
            //optionsBuilder.UseSqlServer("Data Sourse = (localdb)\\MSSQLLocalDB;Initial Catalog = PubDatabase");
            /*"Data Sourse = (localdb)\\MSSQLLocalDB;*/
    }
}
