namespace Application.BoundedContexts.FootballMatches
{

    using Application.BoundedContexts.FootballMatches.Models.Response;
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootballMatch.Entities; 

    public interface IFootbalMatchesQueryRepository : IQueryRepository<FootballMatchEntity>
    {
        Task<FootballMatchesListModel> ListMatchesAsync(CancellationToken cancellationToken);
        Task<DetailMatchTeamModel> DetailsMatchAsync(Guid teamId, CancellationToken cancellationToken);
    }
}
