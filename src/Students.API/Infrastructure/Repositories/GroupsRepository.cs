using DataAccess.EF;
using Students.API.Models;

namespace Students.API.Infrastructure.Repositories
{
    public class GroupsRepository : EfRepository<Group, StudentsContext>
    {
        public GroupsRepository(StudentsContext context) : base(context) 
        {
        }
    }
}
