using System;
using Entities.Common;

namespace Entities
{
    public class CommentModel:BaseEntity
    {
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string UserFullName { get; set; }
        public double Star { get; set; }
        public int Like { get; set; }
    }
}