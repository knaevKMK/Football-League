namespace Domain.Common.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow
        {
            get => DateTime.UtcNow;
            set { UtcNow = DateTime.UtcNow; }
        }
    }
}
