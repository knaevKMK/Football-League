namespace Application.BoundedContexts.FootballTeams
{

    using Application.BoundedContexts.FootballTeams.Models.Response;
    using Application.Common.Contracts;
    using Domain.BoundedContexts.FootballTeam.Entities;

    public interface IFootbalTeamsQueryRepository : IQueryRepository<FootballTeamEntity>
    {
        Task<FootballTeamsListModel> ListTeamsAsync(CancellationToken cancellationToken);
        Task<DetailFootbalTeamModel> DetailsTeamAsync(Guid teamId, CancellationToken cancellationToken);
    }
}
