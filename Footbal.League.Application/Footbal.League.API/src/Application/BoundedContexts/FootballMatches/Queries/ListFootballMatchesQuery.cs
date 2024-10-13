namespace Application.BoundedContexts.FootballMatches.Queries
{

    using Application.BoundedContexts.FootballMatches.Models.Response;
    using Application.Common;
    using MediatR;

    public class ListFootballMatchesQuery : IRequest<Result<FootballMatchesListModel>>
    {
        public class ListFootballMatchesHandler(IFootbalMatchesQueryRepository matchRepository)
            : IRequestHandler<ListFootballMatchesQuery, Result<FootballMatchesListModel>>
        {
            public async Task<Result<FootballMatchesListModel>> Handle(ListFootballMatchesQuery request, CancellationToken cancellationToken)
            {
                return await matchRepository.ListMatchesAsync(cancellationToken);
            }
        }
    }
}
