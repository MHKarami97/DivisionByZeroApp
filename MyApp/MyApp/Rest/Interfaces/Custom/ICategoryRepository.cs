﻿using System.Collections.Generic;
using MyApp.Rest.Entities.Common;
using System.Threading.Tasks;
using Entities.Common;
using Refit;

namespace MyApp.Rest.Interfaces.Custom
{
    public interface ICategoryRepository<in TSelect, TReturn, in TKey> 
        : IRepository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
        where TKey : struct
    {
        [Get("/{id}")]
        Task<ApiResult<List<TReturn>>> GetAllByCatId(TKey id);

        [Get("")]
        Task<ApiResult<List<TReturn>>> GetAllMainCat();
    }
}