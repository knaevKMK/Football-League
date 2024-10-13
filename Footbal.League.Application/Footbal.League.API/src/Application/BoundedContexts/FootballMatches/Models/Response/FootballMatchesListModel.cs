namespace Application.BoundedContexts.FootballMatches.Models.Response
{

    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.BoundedContexts.FootballMatch.Entities;

    public class FootballMatchesListModel
    {
        public ICollection<FootballMatchesShortModel> FootballMatches { get; set; } = new List<FootballMatchesShortModel>();
    }

    public class FootballMatchesShortModel : IMapFrom<FootballMatchEntity>
    {
        public Guid MatchId { get; set; }
        public string HomeTeamName { get; set; } = default!;
        public string GuestTeamName { get; set; } = default!;
        public string MatchResult { get; set; } = default!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FootballMatchEntity, FootballMatchesShortModel>()
                .ForMember(dest => dest.MatchId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.Name))
                .ForMember(dest => dest.GuestTeamName, opt => opt.MapFrom(src => src.GuestTeam.Name))
                .ForMember(dest => dest.MatchResult, opt => opt.MapFrom(src => $"{src.HomeGoals} : {src.GuestGoals}"))
                ;
        }
    }
}
