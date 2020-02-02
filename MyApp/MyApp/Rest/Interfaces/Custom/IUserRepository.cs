using MyApp.Rest.Entities.Common;
using System.Threading.Tasks;
using Entities.Common;
using Refit;

namespace MyApp.Rest.Interfaces.Custom
{
    public interface IUserRepository<in TSelect, TReturn, in TKey>
        : IRepository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        [Post("")]
        Task<ApiResult<TReturn>> Token(string username, string password, string grant_type);

        [Post("")]
        Task<ApiResult<TReturn>> Create([Body] TSelect input);

    }
}