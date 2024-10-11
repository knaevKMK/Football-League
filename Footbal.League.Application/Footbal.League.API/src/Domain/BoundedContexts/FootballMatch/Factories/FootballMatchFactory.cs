namespace Domain.BoundedContexts.FootballTeam.Factories
{
    using Domain.BoundedContexts.FootballMatch.Entities;
    using Domain.BoundedContexts.FootballMatch.Exceptions;
    using Domain.Common.Services;

    public class FootballMatchFactory(IDateTimeProvider dateTimeProvider) : IFootballMatchFactory
    {
        #region Props
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        private Guid createdFrom = default!;
        public Guid homeTeamId = default!;
        public byte homeGoals = default;
        public Guid guestTeamId = default!;
        public byte guestGoals = default;

        private bool createdFromSet = false;
        private bool homeTeamIdIsSet = false;
        private bool homeGoalsIsSet = false;
        private bool guestTeamIdIsSet = false;
        private bool guestGoalsIsSet = false;
        #endregion

        public FootballMatchEntity Build()
        {
            if (!createdFromSet)
            {
                throw new InvalidFootballMatchException($"{nameof(FootballMatchFactory)}, {nameof(createdFromSet)} must have a value.");
            }
            if (!homeTeamIdIsSet)
            {
                throw new InvalidFootballMatchException($"{nameof(FootballMatchFactory)}, {nameof(homeTeamIdIsSet)} must have a value.");
            }
            if (!homeGoalsIsSet)
            {
                throw new InvalidFootballMatchException($"{nameof(FootballMatchFactory)}, {nameof(homeGoalsIsSet)} must have a value.");
            }
            if (!guestTeamIdIsSet)
            {
                throw new InvalidFootballMatchException($"{nameof(FootballMatchFactory)}, {nameof(guestTeamIdIsSet)} must have a value.");
            }
            if (!guestGoalsIsSet)
            {
                throw new InvalidFootballMatchException($"{nameof(FootballMatchFactory)}, {nameof(guestGoalsIsSet)} must have a value.");
            }

            return new FootballMatchEntity(
                   createdFrom,
                   homeTeamId,
                   homeGoals,
                   guestTeamId,
                   guestGoals,
                   _dateTimeProvider);
        }

        public IFootballMatchFactory WithCreatedFrom(Guid createdFrom)
        {
            this.createdFrom = createdFrom;
            createdFromSet = true;
            return this;
        }

        public IFootballMatchFactory WithHomeTeam(Guid homeTeamId)
        {
            this.homeTeamId = homeTeamId;
            homeTeamIdIsSet = true;
            return this;
        }

        public IFootballMatchFactory WithHomeTeamGoals(byte homeGoals)
        {
            this.homeGoals = homeGoals;
            homeGoalsIsSet = true;
            return this;
        }
        public IFootballMatchFactory WithGuestTeam(Guid guestTeamId)
        {
            this.guestTeamId = guestTeamId;
            homeTeamIdIsSet = true;
            return this;
        }
        public IFootballMatchFactory WithGuestTeamGoals(byte guestGoals)
        {
            this.guestGoals = guestGoals;
            homeGoalsIsSet = true;
            return this;
        }
    }
}
