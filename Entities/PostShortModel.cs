using System;
using Entities.Common;

namespace Entities
{
    public class PostShortModel : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string ShortDescription { get; set; }
        public string CategoryName { get; set; }
        public string UserFullName { get; set; }
        public string FullTitle { get; set; }
        public int Like { get; set; }
        public int Visit { get; set; }
        public string Date { get; set; }
    }
}