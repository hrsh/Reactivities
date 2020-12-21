using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.ActivityItems.Commands;
using Application.ActivityItems.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> List(CancellationToken ct) =>
            await _mediator.Send(new GetList(), ct);

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> Get(System.Guid id, CancellationToken ct)
        {
            var t = await _mediator.Send(new Application.ActivityItems.Queries.GetById
            {
                Id = id
            }, ct);

            return t;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Add(AddCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Edit(EditCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}