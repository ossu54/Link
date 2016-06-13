namespace Zelda.Models
{
    public class WebSiteInfo
    {
        public int ID { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public string Category { get; set; }
        public int Points { get; set; }
    }
}
