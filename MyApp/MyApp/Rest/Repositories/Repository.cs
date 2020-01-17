using MyApp.Rest.Interfaces;
using Refit;

namespace MyApp.Rest.Repositories
{
    public class Repository<T, TKey> where T : class
    {
        private const string BaseUrl = "https://localhost:44339/api/v1/";

        public IRepository<T, TKey> Get(string address)
        {
            return RestService.For<IRepository<T, TKey>>(BaseUrl + address);
        }
    }
}