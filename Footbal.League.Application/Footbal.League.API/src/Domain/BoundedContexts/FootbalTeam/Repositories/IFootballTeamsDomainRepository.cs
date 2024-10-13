namespace Domain.BoundedContexts.FootbalTeam.Repositories
{

    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.Common;
    using System.Threading;

    public interface IFootballTeamsDomainRepository : IDomainRepository<FootballTeamEntity>
    {
        Task<Guid> CreateTeamAsync(FootballTeamEntity entity);
        Task<FootballTeamEntity> FindTeamByIdAsync(Guid teamId, CancellationToken none);
        Task UpdataTeamAsync(FootballTeamEntity entity);
        Task UpdateRankAsync(Guid matchId, Guid homeTeamId, byte homeTeamGoals, Guid guestTeamId, byte guestTeamGoals);
    }
}
