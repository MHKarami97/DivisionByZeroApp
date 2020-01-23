using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.Rest.Entities.Common;
using MyApp.Rest.Repositories.Custom;

namespace MyApp.Rest.Api.Custom
{
    public abstract class CommentApi<TSelect, TReturn, TKey> : Api<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
        where TKey : struct
    {
        private readonly CommentRepository<TSelect, TReturn, TKey> _repository;

        protected CommentApi(string witch, string authorization = null)
            : base(witch, authorization)
        {
            _repository = new CommentRepository<TSelect, TReturn, TKey>();
        }

        public async Task<ApiResult<List<TReturn>>> GetAllByPostId(TKey id)
        {
            ApiResult<List<TReturn>> results = null;

            var apiService = _repository.GetPost(Address + "/" + nameof(GetAllByPostId));

            await apiService.GetAllByPostId(id)
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

    public class CommentApi<TSelect, TKey> : CommentApi<TSelect, TSelect, TKey>
        where TSelect : class
        where TKey : struct
    {
        public CommentApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }

    public class CommentApi<TSelect> : CommentApi<TSelect, TSelect, int>
        where TSelect : class
    {
        public CommentApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }
}