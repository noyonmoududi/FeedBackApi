using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CommandQueries.CommentReactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FeedBack.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentReactionController : ControllerBase
    {
        IMediator _mediator;

        public CommentReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateCommentReaction(CreateCommentReaction.Command command)
        {
            return await _mediator.Send(command);
        }

       
    }
}
