using Application.Common.Mapping;
using Domain.BoundedContexts.FootballTeam.Entities;

namespace Application.BoundedContexts.FootballTeams.Models.Response
{
    public class DetailFootbalTeamModel : IMapFrom<FootballTeamEntity>
    {
        public string TeamId { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
    }
}
