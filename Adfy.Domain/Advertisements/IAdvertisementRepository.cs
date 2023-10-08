namespace Adfy.Domain.Advertisements;

public interface IAdvertisementRepository
{
    Task<Advertisement?> GetByIdAsync(AdvertisementId advertisementId, CancellationToken cancellationToken = default);

    void Add(Advertisement advertisement);

    void Remove(Advertisement advertisement);
}