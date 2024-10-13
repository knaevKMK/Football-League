namespace Application.BoundedContexts.FootballTeams.Models.Response
{

    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.BoundedContexts.FootbalTeam.Entities;

    public class DetailTeamRankModel : IMapFrom<FootballRankingEntity>
    {
        public Guid RankId { get; set; } = default!;
        public Guid TeamId { get; set; } = default!;
        public string TeamName { get; set; } = default!;
        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Losses { get; set; } = 0;

        public int Points => Wins * 3 + Draws;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FootballRankingEntity, DetailTeamRankModel>()
                .ForMember(src => src.RankId, opt => opt.MapFrom(src => src.Id))
                .ForMember(src => src.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                ;
        }
    }
}
