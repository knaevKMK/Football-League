namespace Domain.Common.Models
{
    public interface IMutable
    {
        void UpdateModifiedFrom(Guid modifiedFrom);
    }
}
