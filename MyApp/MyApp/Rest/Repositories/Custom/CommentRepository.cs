﻿using Entities.Common;
using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class CommentRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : BaseEntity<TKey>, new()
        where TReturn : BaseEntity<TKey>, new()
        where TKey : struct
    {
        public ICommentRepository<TSelect, TReturn, TKey> GetPost(string address)
        {
            return RestService.For<ICommentRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}