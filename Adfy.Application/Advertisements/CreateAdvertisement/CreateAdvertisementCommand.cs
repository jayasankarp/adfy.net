using Adfy.Application.Abstractions.Messaging;

namespace Adfy.Application.Advertisements.CreateAdvertisement;

public record CreateAdvertisementCommand(
    string UserId,
    string Title,
    string Description) : ICommand<Guid>;