using System.Collections.Generic;

namespace Students.API.ViewModels
{
    public class ListViewModel<TEntity> where TEntity : class
    {
        public int SkipCount { get; private set; }

        public int TakeCount { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<TEntity> Data { get; private set; }

        public ListViewModel(int? skipCount, int? takeCount, long count, IEnumerable<TEntity> data)
        {
            this.SkipCount = skipCount.HasValue ? skipCount.Value : 0;
            this.TakeCount = takeCount.HasValue ? takeCount.Value : 0;
            this.Count = count;
            this.Data = data;
        }
    }
}
