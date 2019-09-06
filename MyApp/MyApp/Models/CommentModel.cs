using System;

namespace MyApp.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
        public string Author { get; set; }
        public string AuthorImage { get; set; }
        public int Star { get; set; }
        public int Like { get; set; }
    }
}