using System.Threading.Tasks;
using Students.API.Models;
using Students.API.ViewModels;

namespace Students.API.Services
{
    public interface IGroupService
    {
        Task<ListViewModel<GroupViewModel>> GetGroupsByFilterAsync(string name, int? skipCount, int? takeCount, bool isOrderByDescending);
    }
}
