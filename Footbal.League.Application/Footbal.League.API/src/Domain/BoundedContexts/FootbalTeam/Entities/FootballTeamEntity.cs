namespace Domain.BoundedContexts.FootballTeam.Entities
{
    using Domain.BoundedContexts.FootballMatch.Entities;
    using Domain.BoundedContexts.FootballTeam.Exceptions;
    using Domain.BoundedContexts.FootbalTeam.Entities;
    using Domain.Common;
    using Domain.Common.Models;
    using Domain.Common.Services;

    public class FootballTeamEntity : BaseDeletableMutableEntity<Guid, InvalidFootballTeamException>, IAggregateRoot
    {
        #region Ctor
        private FootballTeamEntity() : base() { }

        internal FootballTeamEntity(
                Guid createdFrom,
                string name,
                string? description,
                IDateTimeProvider dateTimeProvider
    ) : base(createdFrom, dateTimeProvider)
        {
            Validation(createdFrom, name);
            Name = name;
            Description = description;

            Rank = new(this.Id, createdFrom, dateTimeProvider);
        }
        #endregion

        #region Props
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }

        public Guid RankId { get; private set; } = default!;

        public virtual FootballRankingEntity Rank { get; private set; }  

        public virtual ICollection<FootballMatchEntity> HomeMatches { get; private set; } = new List<FootballMatchEntity>();
        public virtual ICollection<FootballMatchEntity> GuestMatches { get; private set; } = new List<FootballMatchEntity>();

        #endregion

        #region Validation
        private void Validation(Guid createdFrom, string name)
        {
            ValidateCreatedFrom(createdFrom);
            ValidateContent(name, nameof(this.Name));
        }

        private void ValidateCreatedFrom(Guid createdFrom)
        {
            if (createdFrom == Guid.Empty)
            {
                throw new InvalidFootballTeamException("Created from is required.");
            }
        }

        private void ValidateContent(string? name, string propName)
           => Guard.AgainstEmptyString<InvalidFootballTeamException>(name ?? nameof(string.Empty), propName);


        public FootballTeamEntity Update(Guid modifyFrom, string? name, string? description)
        {
            this.UpdateModifiedFrom(modifyFrom);
            if (!string.IsNullOrWhiteSpace(name))
            {
                this.Name = name;
            }
            if (!string.IsNullOrWhiteSpace(description))
            {
                this.Description = description;
            }
            return this;
        }
        #endregion


    }
}
