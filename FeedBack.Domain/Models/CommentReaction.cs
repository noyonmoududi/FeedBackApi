using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class CommentReaction
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Like { get; set; }
        public string DisLike { get; set; }
    }
}
