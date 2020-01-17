using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Rest.Entities.Common;
using Refit;

namespace MyApp.Rest.Interfaces
{
    public interface IRepository<T, in TKey> where T : class
    {
        [Get("/{id}")]
        Task<ApiResult<T>> Get(TKey id);

        [Get("")]
        Task<List<ApiResult<T>>> GetAll();

        [Post("")]
        Task<ApiResult<T>> Create([Body] T input,[Header("Authorization")] string authorization);

        [Put("/{id}")]
        Task<ApiResult<T>> Update(TKey id, [Body]T input,[Header("Authorization")] string authorization);

        [Delete("/{id}")]
        Task<ApiNullResult> Delete(TKey id,[Header("Authorization")] string authorization);
    }
}