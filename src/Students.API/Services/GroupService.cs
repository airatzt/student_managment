using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccess.EF;
using Students.API.Infrastructure;
using Students.API.Models;

namespace Students.API.Services
{
    public class GroupService : EfRepository<Group, StudentsContext>, IGroupService
    {
        public GroupService(StudentsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Group>> GetGroupsByFilterAsync(string name, int? skipCount, int? takeCount, bool isOrderByDescending)
        {
            return await ListAsync(predicate: CreatePredicateByName(name),
                orderBy: x => x.Name,
                isOrderByDescending: isOrderByDescending,
                skipCount: skipCount,
                takeCount: takeCount,
                (gr) => gr.StudentGroups);
        }

        public async Task<int> GetGroupsCountByFilterAsync(string name)
        {
            return await CountAsync(CreatePredicateByName(name));
        }

        private Expression<Func<Group, bool>> CreatePredicateByName(string name)
        {
            Expression<Func<Group, bool>> predicate = null;
            if (!string.IsNullOrEmpty(name))
            {
                predicate = x => x.Name.ToLower().Contains(name.Trim().ToLower());
            }
            return predicate;
        }


        //public ListViewModel<Group> GetGroupsByFilterAsync(string name, int? skipCount, int? takeCount, bool isOrderByDescending)
        //{
        //    Expression<Func<Group, bool>> predicate = null;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        predicate = x => x.Name.ToLower().Contains(name.Trim().ToLower());
        //    }
        //    var countTask = CountAsync(predicate);
        //    var groupsTask = ListAsync(predicate: predicate,
        //        orderBy: x => x.Name,
        //        isOrderByDescending: isOrderByDescending,
        //        skipCount: skipCount,
        //        takeCount: takeCount,
        //        (gr) => gr.StudentGroups);

        //    Task.WhenAll(new List<Task>() { countTask, groupsTask });
        //    return new ListViewModel<Group>(skipCount, takeCount, countTask.Result, groupsTask.Result);

        //}
    }
}
