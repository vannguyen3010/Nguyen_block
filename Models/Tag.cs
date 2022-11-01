using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NghiaVoBlog.Models
{
    public class Tag : BaseEntity
    {
         public String Name { get; set; }

        public ICollection<ArticleTag> ArticleTags { get; set; }
    }

}