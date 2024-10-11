namespace Application.BoundedContexts.FootballTeams.Queries
{

    using Application.BoundedContexts.FootballTeams.Models.Response;
    using Application.Common;
    using MediatR;

    public class ListFootballTeamsQuery : IRequest<Result<FootballTeamsListModel>>
    {
        //Add pagination 

        public class ListFootballTeamsHandler (IFootbalTeamsQueryRepository repository)
            : IRequestHandler<ListFootballTeamsQuery, Result<FootballTeamsListModel>>
        {
            public async Task<Result<FootballTeamsListModel>> Handle(ListFootballTeamsQuery request, CancellationToken cancellationToken)
            {
                return await repository.ListTeamsAsync( cancellationToken);
            }
        }
    }
}
