namespace API.Features.FottballTeams
{
    using Application.BoundedContexts.FootballTeams.Commands;
    using Application.BoundedContexts.FootballTeams.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Web.Controllers;

    public class TeamsController(ILogger<TeamsController> logger, IConfiguration configfuration)
        : BaseApiController<TeamsController>(logger, configfuration)
    {

        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellation)
        {
            var result = await _mediator.Send(new ListFootballTeamsQuery(), cancellation);

            return Ok(result.Data);
        }

        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> Details([FromRoute] Guid teamId, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DetailsFootballTeamQuery { TeamId = teamId }, cancellation);

            return Ok(result.Data);
        }


        [HttpPost]
        //[Admin Authorization]
        public async Task<IActionResult> Create([FromBody] CreateFootballCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result.Data);
        }

        [HttpPut]
        //[Admin Authorization]
        public async Task<IActionResult> Update([FromBody] UpdateFootballCommand request)
        {
            var result = await _mediator.Send(request);

            return Ok(result.Data);
        }
    }
}
