using Entities.Common;

namespace Entities
{
    public class BannerModel : BaseEntity
    {
        //public int Id { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
    }
}