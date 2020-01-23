﻿using System.Threading.Tasks;
using MyApp.Rest.Repositories;
using System.Collections.Generic;
using MyApp.Rest.Entities.Common;

namespace MyApp.Rest.Api
{
    public class Api<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
        where TKey : struct
    {
        protected readonly string Address;
        protected readonly string Authorization;
        private readonly Repository<TSelect, TReturn, TKey> _repository;

        public Api(string witch, string authorization = null)
        {
            Address = witch;
            Authorization = authorization;
            _repository = new Repository<TSelect, TReturn, TKey>();
        }

        public virtual async Task<ApiResult<List<TReturn>>> GetAll()
        {
            ApiResult<List<TReturn>> results = null;

            var apiService = _repository.Get(Address + "/" + "Get");

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

        public virtual async Task<ApiResult<TReturn>> Get(TKey id)
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.Get(Address + "/" + nameof(Get));

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

        public virtual async Task<ApiResult<TReturn>> Create(TSelect input)
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.Get(Address + "/" + nameof(Create));

            await apiService.Create(input, Authorization)
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

        public virtual async Task<ApiResult<TReturn>> Update(TKey id, TSelect input)
        {
            ApiResult<TReturn> results = null;

            var apiService = _repository.Get(Address + "/" + nameof(Update));

            await apiService.Update(id, input, Authorization)
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

        public virtual async Task<ApiNullResult> Delete(TKey id)
        {
            ApiNullResult results = null;

            var apiService = _repository.Get(Address + "/" + nameof(Delete));

            await apiService.Delete(id, Authorization)
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

    public class Api<TSelect, TKey> : Api<TSelect, TSelect, TKey>
        where TSelect : class
        where TKey : struct
    {
        public Api(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }

    public class Api<TSelect> : Api<TSelect, TSelect, int>
        where TSelect : class
    {
        public Api(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }
}