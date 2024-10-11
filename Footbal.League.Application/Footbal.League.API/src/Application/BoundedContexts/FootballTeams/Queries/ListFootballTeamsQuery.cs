namespace Application.BoundedContexts.FootballTeams.Queries
{

    using Application.BoundedContexts.FootballTeams.Models.Response;
    using Application.Common;
    using MediatR;

    public class ListFootballTeamsQuery : IRequest<Result<FootballTeamsListModel>>
    {
        public class ListFootballTeamsHandler : IRequestHandler<ListFootballTeamsQuery, Result<FootballTeamsListModel>>
        {
            public Task<Result<FootballTeamsListModel>> Handle(ListFootballTeamsQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
