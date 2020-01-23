using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class PostRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
        where TKey : struct
    {
        public IPostRepository<TSelect, TReturn, TKey> GetPost(string address)
        {
            return RestService.For<IPostRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}