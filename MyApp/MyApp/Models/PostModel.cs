namespace MyApp.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string PostAuthor { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortContent { get; set; }
        public int Visit { get; set; }
        public int Comment { get; set; }
        public int Like { get; set; }
        public int CategoryId { get; set; }
        public string Image { get; set; }
        public bool CommentStatus { get; set; }
        public int LanguageId { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
        public string Tags { get; set; }
    }
}