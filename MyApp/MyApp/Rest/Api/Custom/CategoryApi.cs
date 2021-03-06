﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Common;
using MyApp.Rest.Entities.Common;
using MyApp.Rest.Repositories.Custom;

namespace MyApp.Rest.Api.Custom
{
    public abstract class CategoryApi<TSelect, TReturn, TKey> : Api<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
        where TKey : struct
    {
        private readonly CategoryRepository<TSelect, TReturn, TKey> _repository;

        protected CategoryApi(string witch, string authorization = null)
            : base(witch, authorization)
        {
            _repository = new CategoryRepository<TSelect, TReturn, TKey>();
        }

        public async Task<ApiResult<List<TReturn>>> GetAllByCatId(TKey id)
        {
            ApiResult<List<TReturn>> results = null;

            var apiService = _repository.GetPost(Address + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            await apiService.GetAllByCatId(id)
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

        public async Task<ApiResult<List<TReturn>>> GetAllMainCat()
        {
            ApiResult<List<TReturn>> results = null;

            var apiService = _repository.GetPost(Address + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            await apiService.GetAllMainCat()
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

    public class CategoryApi<TSelect, TKey> : CategoryApi<TSelect, TSelect, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TKey : struct
    {
        public CategoryApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }

    public class CategoryApi<TSelect> : CategoryApi<TSelect, TSelect, int>
        where TSelect : BaseEntity<int>, new()
    {
        public CategoryApi(string witch, string authorization = null)
            : base(witch, authorization)
        {

        }
    }
}