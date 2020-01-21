using Entities.Common;

namespace Entities
{
    public class CommentModel:BaseEntity
    {
        public string Text { get; set; }
        public string Time { get; set; }
        public string UserFullName { get; set; }
        public string UserImage { get; set; }
        public double Star { get; set; }
        public int Like { get; set; }
    }
}