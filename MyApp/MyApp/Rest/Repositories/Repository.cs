using MyApp.Rest.Interfaces;
using Refit;

namespace MyApp.Rest.Repositories
{
    public class Repository<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
    {
        private const string BaseUrl = "http://95.216.12.8:82/api/v1/";

        public IRepository<TSelect, TReturn, TKey> Get(string address)
        {
            return RestService.For<IRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}