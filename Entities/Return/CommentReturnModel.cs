using Entities.Common;

namespace Entities.Return
{
    public class CommentReturnModel : BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public double Star { get; set; }
    }
}