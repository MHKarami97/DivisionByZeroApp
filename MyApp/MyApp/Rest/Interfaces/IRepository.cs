using System.Collections.Generic;
using MyApp.Rest.Entities.Common;
using System.Threading.Tasks;
using Entities.Common;
using Refit;

namespace MyApp.Rest.Interfaces
{
    public interface IRepository<in TSelect, TReturn, in TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        [Get("/{id}")]
        Task<ApiResult<TReturn>> Get(TKey id);

        [Get("")]
        Task<ApiResult<List<TReturn>>> GetAll();

        [Post("")]
        Task<ApiResult<TReturn>> Create([Body] TSelect input, [Header("Authorization")] string authorization);

        [Put("/{id}")]
        Task<ApiResult<TReturn>> Update(TKey id, [Body]TSelect input, [Header("Authorization")] string authorization);

        [Delete("/{id}")]
        Task<ApiNullResult> Delete(TKey id, [Header("Authorization")] string authorization);
    }
}