namespace Domain.Common.Services
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; set; }
    }
}
