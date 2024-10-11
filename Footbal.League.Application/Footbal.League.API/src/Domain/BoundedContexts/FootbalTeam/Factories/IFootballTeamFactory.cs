namespace Domain.BoundedContexts.FootbalTeam.Factories
{

    using Domain.BoundedContexts.FootbalTeam.Entities;

    public interface IFootballTeamFactory
    {
        FootbalTeamEntity Build();
        IFootballTeamFactory WithCreatedFrom(Guid createdFrom);
        IFootballTeamFactory WithName(string name);
        IFootballTeamFactory WithDescription(string description);
    }
}
