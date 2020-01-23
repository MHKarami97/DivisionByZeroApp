using Entities.Common;
using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class PostRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
        where TKey : struct
    {
        public IPostRepository<TSelect, TReturn, TKey> GetPost(string address)
        {
            return RestService.For<IPostRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}