using Entities.Common;
using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class SearchRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        public ISearchRepository<TSelect, TReturn, TKey> GetPost(string address)
        {
            return RestService.For<ISearchRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}