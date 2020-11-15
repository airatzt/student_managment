using System.Collections.Generic;
using System.Threading.Tasks;
using Students.API.ViewModels;

namespace Students.API.Services
{
    public interface IGroupService
    {
        Task<ListViewModel<GroupViewModel>> GetGroupsByFilterAsync(string name, int? skipCount, int? takeCount, bool isOrderByDescending);
        Task<GroupViewModel> CreateGroupAsync(CreateGroupViewModel createGroupViewModel);
        Task<GroupViewModel> DeleteGroupAsync(int id);
        Task<GroupViewModel> GetGroupByIdAsync(int id);
        //Task<int> IsGroupsNotExistsByIds(IList<int> ids);
    }
}
