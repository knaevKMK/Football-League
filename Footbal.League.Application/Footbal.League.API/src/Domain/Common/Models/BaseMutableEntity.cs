namespace Domain.Common.Models
{

    using Domain.Common.Services;

    public abstract class BaseMutableEntity<TId, TException> : BaseEntity<TId, TException>, IMutable
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseMutableEntity()
           : base()
        {
        }
        protected BaseMutableEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider)
            : base(createdFrom, dateTimeProvider)
        {
        }

        public Guid? ModifiedFrom { get; private set; }
        public DateTime? ModifiedOn { get; private set; }

        public void UpdateModifiedFrom(Guid modifiedFrom)
        {
            this.ModifiedFrom = modifiedFrom;
            this.ModifiedOn = base.DateTimeProvider?.UtcNow ?? DateTime.UtcNow;
        }
    }
}
