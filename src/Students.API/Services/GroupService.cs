using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.EF;
using Students.API.Models;
using Students.API.ViewModels;

namespace Students.API.Services
{
    public class GroupService : IGroupService
    {
        private readonly IEfRepository<Group> _repository;
        public GroupService(IEfRepository<Group> efRepository)
        {
            _repository = efRepository;
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
    }
}
