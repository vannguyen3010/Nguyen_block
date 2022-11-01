using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NghiaVoBlog.Models
{
    public class BaseEntity
    {
        public Guid ID { get; set;} = Guid.NewGuid();
        public DateTime CreateAt { get; set;} = DateTime.UtcNow;
        public DateTime UpdateAt { get; set;}
    }

}