namespace Adfy.Domain.Advertisements;

public record AdvertisementId(Guid Value)
{
    public static AdvertisementId New() => new(Guid.NewGuid());
}