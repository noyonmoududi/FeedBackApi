using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandQueries.Comments;
using FeedBack.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateComment(CreateComment.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Comment>>> CommentList(int id)
        {
            return await _mediator.Send(new CommentQuery.Query { BlogId = id} );
        }

    }
}
