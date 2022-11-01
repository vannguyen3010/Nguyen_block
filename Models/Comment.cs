using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NghiaVoBlog.Models
{
    public class Comment : BaseEntity
    {
        public String Content { get; set; }
        
        public User Author { get; set; }
        public Guid AuthorID  { get; set; }

        public Guid ArticleID  { get; set; }
        public Article Article  { get; set; }
    }

}