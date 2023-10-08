using Adfy.Application.Abstractions.Date;

namespace Adfy.Infrastructure.Date;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}