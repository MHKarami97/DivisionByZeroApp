using MyApp.Rest.Interfaces.Custom;
using Refit;

namespace MyApp.Rest.Repositories.Custom
{
    public class CommentRepository<TSelect, TReturn, TKey>
        : Repository<TSelect, TReturn, TKey>
        where TSelect : class
        where TReturn : class
        where TKey : struct
    {
        public ICommentRepository<TSelect, TReturn, TKey> GetPost(string address)
        {
            return RestService.For<ICommentRepository<TSelect, TReturn, TKey>>(BaseUrl + address);
        }
    }
}