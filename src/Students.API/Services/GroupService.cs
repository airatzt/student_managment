using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.EF;
using Students.API.Infrastructure.Repositories;
using Students.API.Models;
using Students.API.ViewModels;

namespace Students.API.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupsRepository _repository;
        public GroupService(IGroupsRepository groupsRepository)
        {
            _repository = groupsRepository;
        }

        public async Task<GroupViewModel> CreateGroupAsync(CreateGroupViewModel createGroupViewModel)
        {
            var createdGroup = await _repository.Add(new Group
            {
                Name = createGroupViewModel.Name
            });

            return MapGroupToGroupViewModel(createdGroup);
        }

        public async Task<GroupViewModel> DeleteGroupAsync(int id)
        {
            var group = await _repository.Delete(id);
            return MapGroupToGroupViewModel(group);
        }

        public async Task<GroupViewModel> GetGroupByIdAsync(int id)
        {
            var group = await _repository.Get(id);
            return MapGroupToGroupViewModel(group);
        }

        public async Task<ListViewModel<GroupViewModel>> GetGroupsByFilterAsync(string name, int? skipCount, int? takeCount, bool isOrderByDescending)
        {
            Expression<Func<Group, bool>> predicate = null;
            if (!string.IsNullOrEmpty(name))
            {
                predicate = x => x.Name.ToLower().Contains(name.Trim().ToLower());
            }
            var groupsCount = await _repository.CountAsync(predicate);
            var groupsList = await _repository.ListAsync(predicate: predicate,
                orderBy: x => x.Name,
                isOrderByDescending: isOrderByDescending,
                skipCount: skipCount,
                takeCount: takeCount,
                (gr) => gr.StudentGroups);
            var groupViewList = groupsList.Select(x => new GroupViewModel(x.Id, x.Name, x.StudentGroups.Count));
            return new ListViewModel<GroupViewModel>(skipCount, takeCount, groupsCount, groupViewList);

        }

        //public async Task<int> IsGroupsNotExistsByIds(IList<int> ids)
        //{
        //    Expression<Func<Group, bool>> predicate = x => ids.Contains(x.Id);
        //    var groups = await _repository.ListAsync(predicate);
        //    var notExistIds = 
        //}

        private GroupViewModel MapGroupToGroupViewModel(Group group)
        {
            if (group != null)
            {
                return new GroupViewModel(group.Id, group.Name, group.StudentGroups != null ? group.StudentGroups.Count : 0);
            }

            return null;
        }
    }
}
