using Adfy.Application.Abstractions.Messaging;
using Adfy.Domain.Abstractions;
using Adfy.Domain.Advertisements;

namespace Adfy.Application.Advertisements.PublishAdvertisement;

public class DeleteAdvertisementCommandHandler(IAdvertisementRepository advertisementRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAdvertisement>
{
    public async Task<Result> Handle(DeleteAdvertisement request, CancellationToken cancellationToken)
    {
        var advertisement = await advertisementRepository.GetByIdAsync(new AdvertisementId(request.AdvertisementId), 
            cancellationToken);
        
        if (advertisement == null)
        {
            return Result.Failure(AdvertisementErrors.NotFound);
        }
        
        advertisementRepository.Remove(advertisement);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}