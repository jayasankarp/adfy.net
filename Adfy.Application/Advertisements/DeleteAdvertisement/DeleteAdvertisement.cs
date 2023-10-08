using Adfy.Application.Abstractions.Messaging;

namespace Adfy.Application.Advertisements.PublishAdvertisement;

public record DeleteAdvertisement(Guid AdvertisementId) : ICommand;