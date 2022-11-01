namespace NghiaVoBlog.Models
{
    public class ArticleLiker
    {
        
        public Guid UserID { get; set; }
        public User User { get; set; }
        public Guid ArticleID { get; set; }
        public Article Article { get; set; }
    }
}