using FeedBack.Domain.Models;
using FeedBack.Persistence;
using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace FeedBack.Application.CommandQueries.Blogs
{
   public class CreateBlog 
    {
       public class Command: IRequest
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }

       public class BlogHandler : IRequestHandler<Command>
        {
            private readonly AppDataContext _context;

            public BlogHandler(AppDataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var blog = new Blog
                {
                    Id = request.Id,
                    Title = request.Title,
                    Content = request.Content,
                    //PostDate = DateTime.Now
                };


                _context.Blogs.Add(blog);
               var result = await _context.SaveChangesAsync() > 0 ;

                if(result)
                return Unit.Value;

                throw new  Exception();
            }
        }
    }
}
