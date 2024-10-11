﻿namespace Domain.BoundedContexts.FootballTeam.Factories
{

    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.Common;

    public interface IFootballTeamFactory: IFactory<FootballTeamEntity>
    {
        FootballTeamEntity Build();
        IFootballTeamFactory WithCreatedFrom(Guid createdFrom);
        IFootballTeamFactory WithName(string name);
        IFootballTeamFactory WithDescription(string description);
    }
}
