namespace Application.BoundedContexts.FootballMatches.Queries
{

    using Application.BoundedContexts.FootballMatches.Models.Response;
    using Application.Common;
    using MediatR;

    public class DetailsFootballMatchQuery : IRequest<Result<DetailMatchTeamModel>>
    {
        public Guid MatchId { get; set; }
        public class DetailsFootballMatchHandler(IFootbalMatchesQueryRepository matchRepository)
            : IRequestHandler<DetailsFootballMatchQuery, Result<DetailMatchTeamModel>>
        {
            public async Task<Result<DetailMatchTeamModel>> Handle(DetailsFootballMatchQuery request, CancellationToken cancellationToken)
            {
                var result = await matchRepository.DetailsMatchAsync(request.MatchId, cancellationToken);

                return result;
            }
        }
    }
}
