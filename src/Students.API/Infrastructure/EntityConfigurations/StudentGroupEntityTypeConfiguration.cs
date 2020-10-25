using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.API.Models;

namespace Students.API.Infrastructure.EntityConfigurations
{
    public class StudentGroupEntityTypeConfiguration : IEntityTypeConfiguration<StudentGroup>
    {
        public void Configure(EntityTypeBuilder<StudentGroup> builder)
        {
            builder.ToTable("StudentGroups");
            builder.HasKey(x => new { x.StudentId, x.GroupId });
            builder.HasOne(x => x.Student).WithMany(x => x.StudentGroups).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Group).WithMany(x => x.StudentGroups).HasForeignKey(x => x.GroupId);
        }
    }
}
