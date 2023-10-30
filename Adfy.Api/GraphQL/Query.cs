using Adfy.Application.Advertisements.FindAdvertisements;
using Adfy.Application.Advertisements.Shared;
using MediatR;

namespace Adfy.Api.GraphQL;

public class Query
{
    public async Task<IReadOnlyList<AdvertisementResponse>> GetAdvertisements([Service] ISender sender)
    {
        var query = new FindAdvertisementsQuery();

        var result = await sender.Send(query);

        return result.Value;
    }
}