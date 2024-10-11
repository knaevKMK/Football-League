namespace Domain.Common.Models
{
    public interface IDeletable
    {
        void Delete(Guid deletedFrom);
    }
}
