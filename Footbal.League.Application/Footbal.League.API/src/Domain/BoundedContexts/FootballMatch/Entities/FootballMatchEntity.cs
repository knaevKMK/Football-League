namespace Domain.BoundedContexts.FootballMatch.Entities
{

    using Domain.BoundedContexts.FootbalTeam.Exceptions;
    using Domain.Common.Models;
    using Domain.Common;
    using Domain.BoundedContexts.FootballMatch.Exceptions; 
    //  using Domain.BoundedContexts.FootbalTeam.Entities;

    public class FootballMatchEntity : BaseDeletableEntity<Guid, InvalidFootbalTeamException>, IAggregateRoot
    {
        #region Ctors
        private FootballMatchEntity() { }

        internal FootballMatchEntity(
              Guid createdFrom,
              Guid homeTeamId,
              byte homeGoals,
              Guid guestTeamId,
              byte guestGoals
              )
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
        //   public FootbalTeamEntity HomeTeam { get; private set; } = default!;
        public byte HomeGoals { get; private set; } = 0;

        public Guid GuestTeamId { get; private set; } = default!;
        //   public FootbalTeamEntity GuestTeam { get; private set; } = default!;
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
