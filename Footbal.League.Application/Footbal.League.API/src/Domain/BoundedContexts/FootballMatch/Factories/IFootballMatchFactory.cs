using Domain.BoundedContexts.FootballMatch.Entities;
using Domain.Common;

namespace Domain.BoundedContexts.FootballTeam.Factories
{
    public interface IFootballMatchFactory : IFactory<FootballMatchEntity>
    {
        FootballMatchEntity Build();
        IFootballMatchFactory WithCreatedFrom(Guid createdFrom);
        IFootballMatchFactory WithGuestTeam(Guid guestTeamId);
        IFootballMatchFactory WithGuestTeamGoals(byte guestGoals);
        IFootballMatchFactory WithHomeTeam(Guid homeTeamId);
        IFootballMatchFactory WithHomeTeamGoals(byte homeGoals);
    }
}