namespace Domain.BoundedContexts.FootbalTeam.Entities
{

    using Domain.BoundedContexts.FootballTeam.Exceptions;
    using Domain.Common.Models;
    using Domain.Common;
    using Domain.BoundedContexts.FootballTeam.Entities;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FootballRankingEntity : BaseMutableEntity<Guid, InvalidFootballTeamException>, IAggregateRoot
    {
        private FootballRankingEntity() : base() { }

        public FootballRankingEntity(Guid teamId, Guid createFrom, Common.Services.IDateTimeProvider dateTimeProvider) : base(createFrom, dateTimeProvider)
        {
            TeamId = teamId;
        }
        public Guid TeamId { get; set; } = default!;
        public virtual FootballTeamEntity Team { get; set; } = default!;
        public int Wins { get; set; } = 0;
        public int Draws { get; set; } = 0;
        public int Losses { get; set; } = 0;

        [NotMapped]
        public int Points => Wins * 3 + Draws;
    }
}
