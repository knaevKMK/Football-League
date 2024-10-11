namespace Domain.Common.Models
{

    using Domain.Common.Services;

    public abstract class BaseDeletableEntity<TId, TException> : BaseEntity<TId, TException>, IDeletable
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseDeletableEntity()
           : base()
        {
        }

        protected BaseDeletableEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider)
            : base(createdFrom, dateTimeProvider)
        {
        }

        public bool IsDeleted { get; private set; }
        public Guid? DeletedFrom { get; private set; }
        public DateTime? DeletedOn { get; private set; }

        public void Delete(Guid deletedFrom)
        {
            this.IsDeleted = true;
            this.DeletedFrom = deletedFrom;
            this.DeletedOn = this.DateTimeProvider?.UtcNow ?? DateTime.UtcNow;
        }
    }
}
