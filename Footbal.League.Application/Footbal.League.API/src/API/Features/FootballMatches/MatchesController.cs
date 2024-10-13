namespace API.Features.FootballMatches
{
    using Application.BoundedContexts.FootballMatches.Commands;
    using Application.BoundedContexts.FootballMatches.Queries;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Web.Controllers;

    public class MatchesController(ILogger<MatchesController> logger, IConfiguration configfuration)
        : BaseApiController<MatchesController>(logger, configfuration)
    {
        [HttpGet]
        public async Task<IActionResult> List(CancellationToken cancellation)
        {
            var result = await _mediator.Send(new ListFootballMatchesQuery(), cancellation);

            return Ok(result.Data);
        }

        [HttpGet("{matchId}")]
        public async Task<IActionResult> Details([FromRoute] Guid matchId, CancellationToken cancellation)
        {
            var result = await _mediator.Send(new DetailsFootballMatchQuery { MatchId = matchId }, cancellation);

            return Ok(result.Data);
        }

        [HttpPost]
        //[Admin Authorization]
        public async Task<IActionResult> Create([FromBody] CreateFootballMatchCommand request)
        {
            var result = await _mediator.Send(request, CancellationToken.None);

            return Ok(result.Data);
        }
    }
}
