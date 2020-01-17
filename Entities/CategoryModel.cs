using Entities.Common;

namespace Entities
{
    public class CategoryModel : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public string ParentCategoryName { get; set; }
    }
}