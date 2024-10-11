using System.Data;

namespace Domain.Common.Services
{
    public class FakeDateTimeProviderFakes : IDateTimeProvider, IDisposable
    {
        public FakeDateTimeProviderFakes()
        {
            UtcNow = DateTime.UtcNow;
        }

        public DateTime UtcNow { get; set; }

        public void UpdateUtcNow(DateTime utcNow)
        {
            UtcNow = utcNow;
        }

        public void Dispose()
        {
        }
    }
}
