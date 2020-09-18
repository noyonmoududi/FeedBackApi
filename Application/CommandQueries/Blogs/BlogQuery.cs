using FeedBack.Domain.Models;
using FeedBack.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandQueries.Blogs
{
   public class BlogQuery
    {
        public class Query : IRequest<List<Blog>> { }


        public class Handler : IRequestHandler<Query, List<Blog>>
        {
            private readonly AppDataContext _context;

            public Handler(AppDataContext context)
            {
                _context = context;
            }
            public async Task<List<Blog>> Handle(Query request, CancellationToken cancellationToken)
            {
                var blogs = await _context.Blogs.ToListAsync();

                return blogs;
            }
        }
    }
}
