using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandQueries.Blogs;
using FeedBack.Application.CommandQueries.Blogs;
using FeedBack.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<Unit>> CreateBlog(CreateBlog.Command command)
        {
            return await _mediator.Send(command) ;
        }

        [HttpGet]
        public async Task<ActionResult<List<Blog>>> BlogList()
        {
            return await _mediator.Send(new BlogQuery.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> BlogbyId(int id)
        {
            return await _mediator.Send(new BlogQueryById.Query{ Id = id});
        }

    }
}
