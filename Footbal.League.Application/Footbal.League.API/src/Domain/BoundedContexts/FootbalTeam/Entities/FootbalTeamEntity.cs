namespace Domain.BoundedContexts.FootbalTeam.Entities
{
    using Domain.BoundedContexts.FootbalTeam.Exceptions;
    using Domain.Common;
    using Domain.Common.Models;
    using Domain.Common.Services;

    internal class FootbalTeamEntity : BaseDeletableMutableEntity<Guid, InvalidFootbalTeamException>, IAggregateRoot
    {
        #region Ctor
        private FootbalTeamEntity() : base()
        {
            Name = string.Empty;
        }

        internal FootbalTeamEntity(
                Guid createdFrom,
                string name,
                string? description,
                IDateTimeProvider dateTimeProvider
    ) : base(createdFrom, dateTimeProvider)
        {
            Validation(createdFrom, name);
            Name = name;
            Description = description;
        }
        #endregion

        #region Props
        public string Name { get; private set; } = default!;
        public string? Description { get; private set; }
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
                throw new InvalidFootbalTeamException("Created from is required.");
            }
        }

        private void ValidateContent(string? name, string propName)
           => Guard.AgainstEmptyString<InvalidFootbalTeamException>(name ?? nameof(string.Empty), propName);


        public FootbalTeamEntity Update(Guid modifyFrom, string name, string? description)
        {
            this.UpdateModifiedFrom(modifyFrom);
            Name = name;
            if (!string.IsNullOrWhiteSpace(description))
            {
                this.Description = description;
            }
            return this;
        }
        #endregion
    }
}
