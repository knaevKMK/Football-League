namespace Infrastructure.BoundedContexts.FootballMatch
{

    using Domain.BoundedContexts.FootballMatch.Entities;
    using Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal interface IFootballMatchDbContext : IDbContext
    {
        public DbSet<FootballMatchEntity> FootballMatches { get; set; }
    }
}
