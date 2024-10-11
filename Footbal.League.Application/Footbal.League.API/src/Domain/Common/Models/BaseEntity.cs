namespace Domain.Common.Models
{
    using Domain.Common.Services;

    public abstract class BaseEntity<TId, TException> : Entity<TId>
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseEntity()
        {
        }

        protected BaseEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider)
        {
            this.DateTimeProvider = dateTimeProvider;

            //ValidateCreatedFrom(createdFrom); // todo fix this !!!

            this.CreatedFrom = createdFrom;
            this.CreatedOn = dateTimeProvider?.UtcNow ?? DateTime.UtcNow;
        }

        protected IDateTimeProvider? DateTimeProvider { get; }
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
