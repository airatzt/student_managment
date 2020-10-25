namespace Students.API.Infrastructure.Repositories
{
    using DataAccess.EF;
    using Students.API.Infrastructure;
    using Students.API.Models;

    public class StudentsRepository : EfRepository<Student, StudentsContext>
    {
        public StudentsRepository(StudentsContext context) : base(context)
        {
        }
    }
}
