namespace Application.BoundedContexts.FootballTeams.Queries
{

    using MediatR;
    using Application.Common;
    using Application.BoundedContexts.FootballTeams.Models.Response;
    using System.Threading.Tasks;
    using System.Threading;

    public class DetailsFootballTeamQuery : IRequest<Result<DetailFootbalTeamModel>>
    {
        public Guid TeamId { get; set; }

        public class DetailsFootballTeamHandler(IFootbalTeamsQueryRepository repository)
            : IRequestHandler<DetailsFootballTeamQuery, Result<DetailFootbalTeamModel>>
        {
            public async Task<Result<DetailFootbalTeamModel>> Handle(DetailsFootballTeamQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
