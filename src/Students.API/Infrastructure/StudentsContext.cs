namespace Students.API.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Students.API.Infrastructure.EntityConfigurations;
    using Students.API.Models;

    public class StudentsContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            builder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        }
    }
}
