namespace API.Features.FottballTeams
{

    using Application.BoundedContexts.FootballTeams.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Web.Controllers;

    internal class TeamsController(ILogger<TeamsController> logger, IConfiguration configfuration)
        : BaseApiController<TeamsController>(logger, configfuration)
    {

        [HttpGet]
        // Authorise to admin
        public async Task<IActionResult> ListFootballTeams(CancellationToken cancellation)
        {
            var teams = await _mediator.Send(new ListFootballTeamsQuery(), cancellation);

            return Ok(teams);
        }

    }
}
