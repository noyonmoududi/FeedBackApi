using FeedBack.Domain.Models;
using FeedBack.Persistence;

using MediatR;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Blogs
{
  public  class BlogQueryById
    {
        public class Query : IRequest<Blog>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Blog>
        {
            private readonly AppDataContext _context;

            public Handler(AppDataContext context)
            {
                _context = context;
            }
            public async Task<Blog> Handle(Query request, CancellationToken cancellationToken)
            {
                var blog = await _context.Blogs.FindAsync(request.Id);

                return blog;
            }
        }
    }
}
