using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Models
{
    public class PostModel
    {
        [Key]
        public Guid PostId { get; set; }
        public string PostName { get; set; }
        public string PostBody { get; set; }

    }
}
