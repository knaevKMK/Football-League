using  Domain.Common.Services;

namespace Domain.Common.Models
{
    public abstract class BaseDeletableEntity<TId, TException> : BaseEntity<TId, TException>
        where TId : struct
        where TException : BaseDomainException, new()
    {
        protected BaseDeletableEntity(Guid createdFrom, IDateTimeProvider dateTimeProvider)
            : base(createdFrom, dateTimeProvider)
        {
        }
    }
}
