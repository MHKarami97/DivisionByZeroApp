using Entities.Common;
using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class UserRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        public IUserRepository<TSelect, TReturn, TKey> GetUser(string address)
        {
            return RestService.For<IUserRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}