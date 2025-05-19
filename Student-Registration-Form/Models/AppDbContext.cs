using Microsoft.EntityFrameworkCore;

namespace Student_Registration_Form.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Incharge> Incharges { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incharge>()
                .HasOne(i => i.Course)
                .WithMany(c => c.Incharges)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Course)
                .WithMany()
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Incharge)
                .WithMany()
                .HasForeignKey(s => s.InchargeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Email = "admin@gmail.com", Password = "admin@123" },
                new Admin
                {
                    Id = 2,
                    Email = "krishna@gmail.com",
                    Password = "krishna123"
                },
               new Admin
               {
                   Id = 3,
                   Email = "superadmin@gmail.com",
                   Password = "super123"
               }
             );
        }
    }
}
