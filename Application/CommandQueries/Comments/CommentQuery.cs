using FeedBack.Domain.Models;
using FeedBack.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Comments
{
    public class CommentQuery
    {
        public class Query : IRequest<List<Comment>> {
            public int BlogId { get; set; }
        }


        public class Handler : IRequestHandler<Query, List<Comment>>
        {
            private readonly AppDataContext _context;

            public Handler(AppDataContext context)
            {
                _context = context;
            }
            public async Task<List<Comment>> Handle(Query request, CancellationToken cancellationToken)
            {
                var blogs = await _context.Comments.Where(p=>p.BlogPostId == request.BlogId).ToListAsync();

                return blogs;
            }
        }
    }
}
