using Microsoft.EntityFrameworkCore;
using Pschool.API.Models;

namespace Pschool.API.Data
{
    public class PschoolDbContext : DbContext
    {
        public PschoolDbContext(DbContextOptions<PschoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ParentId);
        }

        public static void SeedData(PschoolDbContext context)
        {
            // Add some sample parents and students
            var parent1 = new Parent { FirstName = "Omer", LastName = "Mohammed" };
            var parent2 = new Parent { FirstName = "Khalid", LastName = "Ali" };

            var student1 = new Student { FirstName = "Fatima", LastName = "Sultan", Parent = parent1 };
            var student2 = new Student { FirstName = "Ahmed", LastName = "Salim", Parent = parent2 };

            context.Parents.AddRange(parent1, parent2);
            context.Students.AddRange(student1, student2);

            context.SaveChanges();
        }


    }
}
