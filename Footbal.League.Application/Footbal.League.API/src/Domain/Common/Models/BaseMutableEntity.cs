using Domain.Common.Services;

namespace Domain.Common.Models
{
    public abstract class BaseMutableEntity<TId, TException> : BaseEntity<TId, TException>
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseMutableEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider)
            : base(createdFrom, dateTimeProvider)
        {
        }

        public Guid? ModifiedFrom { get; private set; }
        public DateTime? ModifiedOn { get; private set; }

        protected void UpdateModifiedFrom(Guid modifiedFrom)
        {
            this.ModifiedFrom = modifiedFrom;
            this.ModifiedOn = base.DateTimeProvider?.UtcNow ?? DateTime.UtcNow;
        }
    }
}
