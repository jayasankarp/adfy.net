using Adfy.Application.Abstractions.Messaging;
using Adfy.Domain.Abstractions;
using Adfy.Domain.Advertisements;
using Adfy.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Adfy.Application.Advertisements.CreateAdvertisement;

public class CreateAdvertisementCommandHandler(
        UserManager<User> userManager,
        IAdvertisementRepository advertisementRepository,
        IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAdvertisementCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }

        var advertisement =
            Advertisement.Create(new Title(request.Title), new Description(request.Description), user.Id);

        advertisementRepository.Add(advertisement);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return advertisement.Id.Value;
    }
}