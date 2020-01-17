using Entities.Common;

namespace Entities
{
    public class PostModel : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string CategoryName { get; set; }
        public string UserFullName { get; set; }
        public string FullTitle { get; set; }
    }
}