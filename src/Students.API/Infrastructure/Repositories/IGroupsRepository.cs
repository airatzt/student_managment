using System.Collections.Generic;
using DataAccess.EF;
using Students.API.Models;

namespace Students.API.Infrastructure.Repositories
{
    public interface IGroupsRepository: IEfRepository<Group>
    {
        IList<int> IsGroupsNotExistsByIds(IList<int> ids);
    }
}
