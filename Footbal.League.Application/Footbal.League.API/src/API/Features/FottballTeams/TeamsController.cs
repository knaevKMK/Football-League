namespace API.Features.FottballTeams
{
    using Application.BoundedContexts.FootballTeams.Commands;
    using Application.BoundedContexts.FootballTeams.Commands.Create;
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

        [HttpGet("{teamId}")]
        public async Task<IActionResult> Details([FromRoute] Guid teamId, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DetailsFootballTeamQuery { TeamId = teamId }, cancellation);

            return Ok(result.Data);
        }


        [HttpPost]
        //[Admin Authorization]
        public async Task<IActionResult> Create([FromBody] CreateFootballTeamCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);

            return Ok(result.Data);
        }

        [HttpPut("{teamId}")]
        //[Admin Authorization]
        public async Task<IActionResult> Update([FromRoute] Guid teamId, [FromBody] UpdateFootballTeamCommand request)
        {
            request.TeamId = teamId;
            var result = await _mediator.Send(request, CancellationToken.None);

            return Ok(result.Data);
        }

        [HttpDelete("{teamId}")]
        //[Admin Authorization]
        public async Task<IActionResult> Delete([FromRoute] Guid teamId)
        {
            var result = await _mediator.Send(new DeleteFootballTeamCommand { TeamId = teamId }, CancellationToken.None);

            return Ok(result.Data);
        }

        [HttpDelete("{teamId}")]
        //[Admin Authorization]
        public async Task<IActionResult> Restore([FromRoute] Guid teamId)
        {
            var result = await _mediator.Send(new RestoreFootballTeamCommand { TeamId = teamId }, CancellationToken.None);

            return Ok(result.Data);
        }
    }
}
