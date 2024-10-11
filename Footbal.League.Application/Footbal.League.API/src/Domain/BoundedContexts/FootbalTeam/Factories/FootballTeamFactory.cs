namespace Domain.BoundedContexts.FootballTeam.Factories
{
    using Domain.BoundedContexts.FootballTeam.Entities;
    using Domain.BoundedContexts.FootballTeam.Exceptions;
    using Domain.Common.Services;

    public class FootballTeamFactory(IDateTimeProvider dateTimeProvider): IFootballTeamFactory
    {
        #region Props
        private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

        private Guid createdFrom = default!;
        public string name = default!;
        public string? description = null;

        private bool createdFromSet = false;
        private bool nameIsSet = false;
        private bool descriptionIsSet = false;
        #endregion

        public FootballTeamEntity Build()
        {
            if (!createdFromSet)
            {
                throw new InvalidFootballTeamException($"{nameof(FootballTeamEntity)}, {nameof(createdFromSet)} must have a value.");
            }
            if (!nameIsSet)
            {
                throw new InvalidFootballTeamException($"{nameof(FootballTeamEntity)}, {nameof(nameIsSet)} must have a value.");
            }


            return new FootballTeamEntity(
                createdFrom,
                name,
                description,
                _dateTimeProvider);
        }

        public IFootballTeamFactory WithCreatedFrom(Guid createdFrom)
        {
            this.createdFrom = createdFrom;
            createdFromSet = true;
            return this;
        }

        public IFootballTeamFactory WithName(string name)
        {
            this.name = name;
            nameIsSet = true;
            return this;
        }

        public IFootballTeamFactory WithDescription(string description)
        {
            this.description = description;
            descriptionIsSet = true;  //not required
            return this;
        }
    }
}
