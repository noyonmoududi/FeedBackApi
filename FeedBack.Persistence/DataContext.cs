using Domain.Models;
using FeedBack.Domain.Models;

using Microsoft.EntityFrameworkCore;
using System;

namespace FeedBack.Persistence
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
    }
}
