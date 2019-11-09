namespace Entities
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }
        public string Author { get; set; }
        public string AuthorImage { get; set; }
        public double Star { get; set; }
        public int Like { get; set; }
    }
}