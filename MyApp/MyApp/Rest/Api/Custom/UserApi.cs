using System.Threading.Tasks;
using Entities.Common;
using MyApp.Rest.Entities.Common;
using MyApp.Rest.Repositories.Custom;

namespace MyApp.Rest.Api.Custom
{
    public class UserApi<TSelect, TReturn, TKey> : Api<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
    {
        private readonly UserRepository<TSelect, TReturn, TKey> _repository;

        public UserApi(string witch, string authorization = null)
            : base(witch, authorization)
        {
            _repository = new UserRepository<TSelect, TReturn, TKey>();
        }

        public async Task<ApiResult<TReturn>> Token(string username, string password, string grant_type = "password")
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.GetUser(Address + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            await apiService.Token(username, password, grant_type)
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

    public class UserApi<TSelect, TKey> : UserApi<TSelect, TSelect, TKey>
        where TSelect : BaseEntity<TKey>, new()
    {
        public UserApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }

    public class UserApi<TSelect> : UserApi<TSelect, TSelect, int>
        where TSelect : BaseEntity<int>, new()
    {
        public UserApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }
}