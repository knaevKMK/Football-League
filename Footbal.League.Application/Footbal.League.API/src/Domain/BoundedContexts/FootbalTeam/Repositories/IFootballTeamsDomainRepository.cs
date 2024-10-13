namespace Domain.BoundedContexts.FootbalTeam.Repositories
{

    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.Common;

    public interface IFootballTeamsDomainRepository : IDomainRepository<FootballTeamEntity>
    {
        Task<Guid> CreateTeamAsync(FootballTeamEntity entity);
    }
}
