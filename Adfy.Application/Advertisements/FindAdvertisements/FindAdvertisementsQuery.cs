using Adfy.Application.Abstractions.Messaging;
using Adfy.Application.Advertisements.Shared;

namespace Adfy.Application.Advertisements.FindAdvertisements;

public sealed record FindAdvertisementsQuery() : IQuery<IReadOnlyList<AdvertisementResponse>>;