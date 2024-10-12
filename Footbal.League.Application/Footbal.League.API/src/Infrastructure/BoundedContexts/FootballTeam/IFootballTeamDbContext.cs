namespace Infrastructure.BoundedContexts.FootballTeam
{

    using Domain.BoundedContexts.FootballTeam.Entities;
    using Infrastructure.Common.Persistence;
    using Microsoft.EntityFrameworkCore;

    internal interface IFootballTeamDbContext : IDbContext
    {
        public DbSet<FootballTeamEntity> FootballTeams { get; set; }
    }
}
