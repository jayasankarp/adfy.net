using Adfy.Application.Abstractions.Messaging;
using Adfy.Domain.Abstractions;
using Adfy.Domain.Advertisements;

namespace Adfy.Application.Advertisements.PublishAdvertisement;

public class PublishAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository,
        IUnitOfWork unitOfWork)
    : ICommandHandler<PublishAdvertisement>
{
    public async Task<Result> Handle(PublishAdvertisement request, CancellationToken cancellationToken)
    {
        var advertisement = await advertisementRepository.GetByIdAsync(new AdvertisementId(request.AdvertisementId), 
            cancellationToken);
        
        if (advertisement == null)
        {
            return Result.Failure(AdvertisementErrors.NotFound);
        }
        
        advertisement.Publish();
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}