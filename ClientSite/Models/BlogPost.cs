namespace ClientSite.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public string LongDescription { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
