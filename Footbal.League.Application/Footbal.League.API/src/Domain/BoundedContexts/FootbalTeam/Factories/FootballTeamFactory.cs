namespace Domain.BoundedContexts.FootbalTeam.Factories
{
    using Domain.BoundedContexts.FootbalTeam.Entities;
    using Domain.BoundedContexts.FootbalTeam.Exceptions;
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

        public FootbalTeamEntity Build()
        {
            if (!createdFromSet)
            {
                throw new InvalidFootbalTeamException($"{nameof(FootbalTeamEntity)}, {nameof(createdFromSet)} must have a value.");
            }
            if (!nameIsSet)
            {
                throw new InvalidFootbalTeamException($"{nameof(InvalidFootbalTeamException)}, {nameof(nameIsSet)} must have a value.");
            }


            return new FootbalTeamEntity(
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
