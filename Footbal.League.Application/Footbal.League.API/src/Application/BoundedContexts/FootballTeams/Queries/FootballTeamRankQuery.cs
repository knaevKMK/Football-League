
using Application.BoundedContexts.FootballTeams.Models.Response;
using Application.Common;
using MediatR;

namespace Application.BoundedContexts.FootballTeams.Queries
{
    public class FootballTeamRankQuery : IRequest<Result<DetailTeamRankModel>>
    {
        public Guid TeamId { get; set; }
        public class FootballTeamRankHandler(IFootbalTeamsQueryRepository teamsRepository)
            : IRequestHandler<FootballTeamRankQuery, Result<DetailTeamRankModel>>
        {
            public async Task<Result<DetailTeamRankModel>> Handle(FootballTeamRankQuery request, CancellationToken cancellationToken)
            {
                var result = await teamsRepository.GetTeamRankAsync(request.TeamId, cancellationToken);

                return result;
            }
        }
    }
}
