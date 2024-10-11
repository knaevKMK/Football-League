namespace Domain.Common.Models
{
    using Domain.Common.Services;

    public abstract class BaseEntity<TId, TException> : Entity<TId>
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider)
        {
            this.DateTimeProvider = dateTimeProvider;

            ValidateCreatedFrom(createdFrom);

            this.CreatedFrom = createdFrom;
            this.CreatedOn = dateTimeProvider?.UtcNow ?? DateTime.UtcNow;
        }

        public IDateTimeProvider? DateTimeProvider { get; }
        public Guid CreatedFrom { get; private set; }
        public DateTime CreatedOn { get; private set; }

        #region private Methods
        private void ValidateCreatedFrom(Guid createdFrom)
        {
            if (createdFrom == Guid.Empty)
            {
                throw new TException() { Error = "Created from is required." };
            }
        }
        #endregion
    }
}
