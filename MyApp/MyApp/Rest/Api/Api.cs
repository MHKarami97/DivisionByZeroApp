using System.Threading.Tasks;
using MyApp.Rest.Repositories;
using System.Collections.Generic;
using MyApp.Rest.Entities.Common;

namespace MyApp.Rest.Api
{
    public class Api<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
    {
        private readonly string _address;
        private readonly string _authorization;
        private static Repository<TSelect, TReturn, TKey> _repository;

        public Api(string witch, string authorization = null)
        {
            _address = witch;
            _authorization = authorization;
            _repository = new Repository<TSelect, TReturn, TKey>();
        }

        public async Task<ApiResult<List<TReturn>>> GetAll()
        {
            ApiResult<List<TReturn>> results = null;

            var apiService = _repository.Get(_address + "/" + "Get");

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
                        if (result.Exception != null) throw result.Exception;
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext())
                .ConfigureAwait(true);

            return results;
        }

        public async Task<ApiResult<TReturn>> Get(TKey id)
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.Get(_address + "/" + "Get");

            await apiService.Get(id)
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

        public async Task<ApiResult<TReturn>> Create(TSelect input)
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.Get(_address + "/" + "Create");

            await apiService.Create(input, _authorization)
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

        public async Task<ApiResult<TReturn>> Update(TKey id, TSelect input)
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.Get(_address + "/" + "Create");

            await apiService.Update(id, input, _authorization)
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

        public async Task<ApiNullResult> Delete(TKey id)
        {
            ApiNullResult results = null;

            var apiService = _repository.Get(_address + "/" + "Get");

            await apiService.Delete(id, _authorization)
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
}