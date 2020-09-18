using FeedBack.Domain.Models;
using FeedBack.Persistence;

using Domain.Models;

using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.CommentReactions
{
   public class CreateCommentReaction
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public int CommentId { get; set; }
            public string Like { get; set; }
            public string DisLike { get; set; }
        }

        public class CommentReactionHandler : IRequestHandler<Command>
        {
            private readonly AppDataContext _context;
            private Comment comment;

            public CommentReactionHandler(AppDataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var commentReaction = new CommentReaction
                {
                    Id = request.Id,
                    CommentId = request.CommentId,
                    Like = request.Like,
                    DisLike = request.DisLike
                };


                _context.CommentReactions.Add(commentReaction);
                var result = await _context.SaveChangesAsync() > 0;

                if (result)
                    return Unit.Value;

                throw new Exception();
            }
        }
    }
}
