namespace Domain.Common.Models
{

    using Domain.Common.Services;

    public abstract class BaseDeletableMutableEntity<TId, TException> : BaseMutableEntity<TId, TException>, IDeletable, IMutable
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseDeletableMutableEntity()
            : base()
        {
        }
        protected BaseDeletableMutableEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider = null)
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

        public void Restore(Guid modifiedFrom)
        {
            this.IsDeleted = false;
            this.UpdateModifiedFrom(modifiedFrom);
        }
    }
}
