using DataAccess.EF;
using Students.API.Models;
namespace Students.API.Infrastructure.Repositories
{
    public class StudentsRepository : EfRepository<Student, StudentsContext>
    {
        public StudentsRepository(StudentsContext context) : base(context)
        {
        }
    }
}
