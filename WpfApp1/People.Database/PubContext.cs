using Microsoft.EntityFrameworkCore;
using People.Database.Models;
namespace People.Database
{
    public class PubContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PubDatabase;Encrypt=False;Integrated Security=SSPI;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(student => new {student.Id});

            modelBuilder.Entity<Student>().Property(s => s.Fname);
            modelBuilder.Entity<Student>().Property(s => s.Lname);
            modelBuilder.Entity<Student>().Property(s => s.Age);
            modelBuilder.Entity<Student>().Property(s => s.IdS);
            modelBuilder.Entity<Student>().Property(s => s.Speciality);
            modelBuilder.Entity<Student>().Property(s => s.Course);

            modelBuilder.Entity<Teacher>().HasKey(teacher => new {teacher.Id});
            modelBuilder.Entity<Teacher>().Property(s => s.Fname);
            modelBuilder.Entity<Teacher>().Property(s => s.Lname);
            modelBuilder.Entity<Teacher>().Property(s => s.Age);
            modelBuilder.Entity<Teacher>().Property(s => s.IdS);
            modelBuilder.Entity<Teacher>().Property(s => s.YearsExperience);
            modelBuilder.Entity<Teacher>().Property(s => s.Title);
            modelBuilder.Entity<Teacher>().Property(s => s.Speciality);
        }


    }
}
