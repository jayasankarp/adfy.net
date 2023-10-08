using Adfy.Domain.Advertisements;

namespace Adfy.Infrastructure.Repositories;

internal sealed class AdvertisementRepository : Repository<Advertisement, AdvertisementId>, IAdvertisementRepository
{
    public AdvertisementRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}