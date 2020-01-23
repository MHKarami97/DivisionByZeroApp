using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class CategoryRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
        where TKey : struct
    {
        public ICategoryRepository<TSelect, TReturn, TKey> GetPost(string address)
        {
            return RestService.For<ICategoryRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}