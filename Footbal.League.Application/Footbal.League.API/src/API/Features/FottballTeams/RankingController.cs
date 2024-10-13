namespace API.Features.FottballTeams
{
    using Application.BoundedContexts.FootballTeams.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Web.Controllers;

    public class RankingController(ILogger<RankingController> logger, IConfiguration configfuration)
        : BaseApiController<RankingController>(logger, configfuration)
    {

        [HttpGet("{teamId}")]
        public async Task<IActionResult> Team([FromRoute] Guid teamId, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new FootballTeamRankQuery { TeamId = teamId }, cancellation);

            return Ok(result.Data);
        }
    }
}
