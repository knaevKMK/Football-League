namespace Application.BoundedContexts.FootballMatches.Models.Response
{

    using Application.BoundedContexts.FootballTeams.Models.Response;
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.BoundedContexts.FootballMatch.Entities; 

    public class DetailMatchTeamModel : IMapFrom<FootballMatchEntity>
    {
        public Guid MatchId { get; set; }
        public FootballTeamsShortModel HomeTeam { get; set; } = default!;
        public int HomeTeamGoals { get; set; }
        public FootballTeamsShortModel GuestTeam { get; set; } = default!;
        public int GuestTeamGoals { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FootballMatchEntity, DetailMatchTeamModel>()
                .ForMember(dest => dest.MatchId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
