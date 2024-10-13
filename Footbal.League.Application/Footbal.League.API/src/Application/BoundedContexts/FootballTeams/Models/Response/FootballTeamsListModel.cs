using Application.Common.Mapping;
using AutoMapper;
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FootballTeamEntity, FootballTeamsShortModel>()
                .ForMember(dest => dest.TeamId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
