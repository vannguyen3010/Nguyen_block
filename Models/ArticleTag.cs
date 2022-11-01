namespace NghiaVoBlog.Models
{
    public class ArticleTag
    {
        public Guid ArticleID {get;set;}
        public Article Article {get;set;}
        public Guid TagID {get;set;}
        public Tag Tag {get;set;}

    }
}