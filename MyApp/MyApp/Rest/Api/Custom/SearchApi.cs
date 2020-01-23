using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Common;
using MyApp.Rest.Entities.Common;
using MyApp.Rest.Repositories.Custom;

namespace MyApp.Rest.Api.Custom
{
    public class SearchApi<TSelect, TReturn, TKey> : Api<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        private readonly SearchRepository<TSelect, TReturn, TKey> _repository;

        public SearchApi(string witch, string authorization = null)
            : base(witch, authorization)
        {
            _repository = new SearchRepository<TSelect, TReturn, TKey>();
        }

        public async Task<ApiResult<List<TReturn>>> Search(TKey str)
        {
            ApiResult<List<TReturn>> results = null;

            var apiService = _repository.GetPost(Address + "/" + nameof(Search));

            await apiService.Search(str)
                .ContinueWith(result =>
                {
                    if (result.IsCompleted && result.Status == TaskStatus.RanToCompletion)
                    {
                        results = result.Result;
                    }
                    else if (result.IsFaulted)
                    {
                        if (result.Exception != null) throw result.Exception;
                    }
                    else if (result.IsCanceled)
                    {
                        if (result.Exception != null) throw result.Exception;
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext())
                .ConfigureAwait(true);

            return results;
        }
    }

    public class SearchApi<TSelect, TKey> : SearchApi<TSelect, TSelect, TKey>
        where TSelect : BaseEntity<TKey>, new()
    {
        public SearchApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }

    public class SearchApi<TSelect> : SearchApi<TSelect, TSelect, int>
        where TSelect : BaseEntity<int>, new()
    {
        public SearchApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }
}