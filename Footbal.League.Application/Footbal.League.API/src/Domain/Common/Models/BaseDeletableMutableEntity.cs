using Domain.Common.Services;

namespace Domain.Common.Models
{
    public abstract class BaseDeletableMutableEntity<TId, TException> : BaseMutableEntity<TId, TException>
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseDeletableMutableEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider = null)
            : base(createdFrom, dateTimeProvider)
        {
        }

        public bool IsDeleted { get; private set; }

        public void Delete(Guid modifiedFrom)
        {
            this.IsDeleted = true;
            this.UpdateModifiedFrom(modifiedFrom);
        }
    }
}
