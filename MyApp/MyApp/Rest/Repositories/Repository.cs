using Entities.Common;
using MyApp.Rest.Interfaces;
using Refit;

namespace MyApp.Rest.Repositories
{
    public class Repository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        protected const string BaseUrl = "http://95.216.12.8:82/api/v1/";

        public virtual IRepository<TSelect, TReturn, TKey> Get(string address)
        {
            return RestService.For<IRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}