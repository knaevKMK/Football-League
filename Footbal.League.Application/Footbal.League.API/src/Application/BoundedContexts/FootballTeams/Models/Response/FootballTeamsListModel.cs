using Application.Common.Mapping;
using Domain.BoundedContexts.FootballTeam.Entities;

namespace Application.BoundedContexts.FootballTeams.Models.Response
{
    public class FootballTeamsListModel
    {
        public ICollection<FootballTeamsShortModel> FootballTeams { get; set; } = new List<FootballTeamsShortModel>();
    }

    public class FootballTeamsShortModel : IMapFrom<FootballTeamEntity>
    {
        public string TeamId { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
