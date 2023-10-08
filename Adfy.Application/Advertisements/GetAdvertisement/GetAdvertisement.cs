

using Adfy.Application.Abstractions.Messaging;
using Adfy.Application.Advertisements.FindAdvertisements;
using Adfy.Application.Advertisements.Shared;

namespace Adfy.Application.Advertisements.GetAdvertisement;


public sealed record GetAdvertisementQuery(Guid AdvertisementId) : IQuery<AdvertisementResponse>;