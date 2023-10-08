using Adfy.Application.Abstractions.Messaging;

namespace Adfy.Application.Advertisements.PublishAdvertisement;

public record PublishAdvertisement(Guid AdvertisementId) : ICommand;