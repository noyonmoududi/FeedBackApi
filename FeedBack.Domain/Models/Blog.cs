using System;
using System.Collections.Generic;

namespace FeedBack.Domain.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; }
    }
}
