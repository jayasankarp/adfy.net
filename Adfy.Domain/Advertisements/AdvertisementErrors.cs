using Adfy.Domain.Abstractions;

namespace Adfy.Domain.Advertisements;

public static class AdvertisementErrors
{
    public static readonly Error NotFound = new(
        "Advertisement.NotFound",
        "The advertisement with the specified identifier was not found");
}