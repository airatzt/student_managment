using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.API.Models;

namespace Students.API.Infrastructure.EntityConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Patronymic).HasMaxLength(60);
            builder.Property(x => x.Slug).HasMaxLength(16);
        }
    }
}
