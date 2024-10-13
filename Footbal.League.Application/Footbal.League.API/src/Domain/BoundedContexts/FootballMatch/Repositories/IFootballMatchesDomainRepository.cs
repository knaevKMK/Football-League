namespace Domain.BoundedContexts.FootballMatch.Repositories
{

    using Domain.BoundedContexts.FootballMatch.Entities;
    using Domain.Common;

    public interface IFootballMatchesDomainRepository : IDomainRepository<FootballMatchEntity>
    {
        Task<Guid> CreateAsync(FootballMatchEntity entity);
    }
}
