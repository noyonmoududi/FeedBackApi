using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FeedBack.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BlogPostId { get; set; }
        public DateTime CommentDate { get; }
    }
}
