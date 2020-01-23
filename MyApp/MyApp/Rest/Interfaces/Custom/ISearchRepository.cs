using System.Collections.Generic;
using MyApp.Rest.Entities.Common;
using System.Threading.Tasks;
using Entities.Common;
using Refit;

namespace MyApp.Rest.Interfaces.Custom
{
    public interface ISearchRepository<in TSelect, TReturn, in TKey> 
        : IRepository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        [Get("/{str}")]
        Task<ApiResult<List<TReturn>>> Search(TKey str);
    }
}