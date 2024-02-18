using Application.Interfaces;

namespace Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUTC => DateTime.UtcNow;
    }
}
