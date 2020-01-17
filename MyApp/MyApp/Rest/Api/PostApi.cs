using System.Threading.Tasks;
using System.Collections.Generic;
using MyApp.Rest.Entities.Common;
using MyApp.Rest.Entities.Post;
using MyApp.Rest.Repositories;

namespace MyApp.Rest.Api
{
    public class PostApi
    {
        private const string Address = "posts";
        private static Repository<Post, int> _repository;

        public PostApi(Repository<Post, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<ApiResult<Post>>> Get()
        {
            List<ApiResult<Post>> results = null;

            var apiService = _repository.Get(Address);

            await apiService.GetAll()
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
                        results = null;
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext())
                .ConfigureAwait(true);

            return results;
        }
    }
}