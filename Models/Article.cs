using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace NghiaVoBlog.Models
{
    public class Article : BaseEntity
    {
         public String Title { get; set; }
        public String Content { get; set; }
        public String ViewCount { get; set; }
        public String DateOfBirth { get; set; }
        [ForeignKey("Author")]
        public Guid AuthorID { get; set; }
        public User Author { get; set; }

        public Guid CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
        
        public ICollection<ArticleLiker> ArticleLikers { get; set; }
    }

}