namespace Domain.BoundedContexts.FootballMatch.Entities
{

    using Domain.BoundedContexts.FootballTeam.Exceptions;
    using Domain.Common.Models;
    using Domain.Common;
    using Domain.BoundedContexts.FootballMatch.Exceptions;
    using Domain.Common.Services;
    using Domain.BoundedContexts.FootballTeam.Entities;

    public class FootballMatchEntity : BaseDeletableEntity<Guid, InvalidFootballTeamException>, IAggregateRoot
    {
        #region Ctors
        private FootballMatchEntity() : base() { }

        internal FootballMatchEntity(
              Guid createdFrom,
              Guid homeTeamId,
              byte homeGoals,
              Guid guestTeamId,
              byte guestGoals,
                IDateTimeProvider dateTimeProvider) : base(createdFrom, dateTimeProvider)
        {
            Validation(createdFrom, homeTeamId, homeGoals, guestTeamId, guestGoals);
            HomeTeamId = homeTeamId;
            HomeGoals = homeGoals;
            GuestTeamId = guestTeamId;
            GuestGoals = guestGoals;
        }
        #endregion

        #region Props
        public Guid HomeTeamId { get; private set; } = default!;
        public virtual FootballTeamEntity HomeTeam { get; private set; } = default!;
        public byte HomeGoals { get; private set; } = 0;

        public Guid GuestTeamId { get; private set; } = default!;
        public virtual FootballTeamEntity GuestTeam { get; private set; } = default!;
        public byte GuestGoals { get; private set; } = 0;
        #endregion

        #region Validation 
        private void Validation(Guid createdFrom, Guid homeTeamId, byte homeGoals, Guid guestTeamId, byte guestGoals)
        {
            ValidateCreatedFrom(createdFrom);

            ValidateTeam(homeTeamId, nameof(this.HomeTeamId));
            ValidateGoals(homeGoals, nameof(this.HomeGoals));

            ValidateTeam(guestTeamId, nameof(this.GuestTeamId));
            ValidateGoals(guestGoals, nameof(this.GuestGoals));
        }

        private void ValidateCreatedFrom(Guid createdFrom)
        {
            if (createdFrom == Guid.Empty)
            {
                throw new InvalidFootballMatchException("Created from is required.");
            }
        }

        private void ValidateTeam(Guid teamId, string nameOfTeamPlaingPosition)
        {
            if (teamId == Guid.Empty)// todo also validate via parse guid
            {
                throw new InvalidFootballMatchException($"{nameOfTeamPlaingPosition} from is required.");
            }
        }

        private void ValidateGoals(byte goals, string nameOfTeamPlaingPosition)
        {
            if (goals < 0)
            {
                throw new InvalidFootballMatchException($"Invalid {nameOfTeamPlaingPosition} goal value.");
            }
        }
        #endregion
    }
}
