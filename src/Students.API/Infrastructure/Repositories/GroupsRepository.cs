using System.Collections.Generic;
using System.Linq;
using DataAccess.EF;
using Students.API.Models;

namespace Students.API.Infrastructure.Repositories
{
    public class GroupsRepository : EfRepository<Group, StudentsContext>, IGroupsRepository
    {
        public GroupsRepository(StudentsContext context) : base(context) 
        {
        }

        public IList<int> IsGroupsNotExistsByIds(IList<int> ids)
        {
           return ids.Where(x => !QueryableEntities.Any(z => z.Id == x)).ToList();
        }
    }
}
