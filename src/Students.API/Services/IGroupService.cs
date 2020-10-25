using System.Collections.Generic;
using System.Threading.Tasks;
using Students.API.Models;

namespace Students.API.Services
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetGroupsByFilterAsync(string name, int? skipCount, int? takeCount, bool isOrderByDescending);
        Task<int> GetGroupsCountByFilterAsync(string name);
    }
}
