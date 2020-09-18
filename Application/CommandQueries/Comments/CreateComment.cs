using FeedBack.Domain.Models;
using FeedBack.Persistence;

using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Comments
{
  public  class CreateComment
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public int BlogPostId { get; set; }
            public string Content { get; set; }
        }

        public class CommentHandler : IRequestHandler<Command>
        {
            private readonly AppDataContext _context;

            public CommentHandler(AppDataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var comment = new Comment
                {
                    Id = request.Id,
                    BlogPostId = request.BlogPostId,
                    Content = request.Content,
                    //CommentDate = DateTime.Now
                };


                _context.Comments.Add(comment);
                var result = await _context.SaveChangesAsync() > 0;

                if (result)
                    return Unit.Value;

                throw new Exception();
            }
        }
    }
}
