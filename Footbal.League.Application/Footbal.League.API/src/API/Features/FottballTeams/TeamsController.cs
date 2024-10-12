namespace API.Features.FottballTeams
{

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
            var teams = await _mediator.Send(new ListFootballTeamsQuery(), cancellation);

            return Ok(teams.Data);
        }

        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> Details([FromRoute] Guid teamId, CancellationToken cancellation)
        {
            var teamDetails = await _mediator.Send(new DetailsFootballTeamQuery { TeamId = teamId }, cancellation);

            return Ok(teamDetails.Data);
        }

    }
}
