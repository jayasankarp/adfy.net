using Adfy.Application.Abstractions.Data;
using Adfy.Application.Abstractions.Messaging;
using Adfy.Application.Advertisements.Shared;
using Adfy.Domain.Abstractions;
using Dapper;

namespace Adfy.Application.Advertisements.FindAdvertisements;

internal sealed class FindAdvertisementsQueryHandler(ISqlConnectionFactory sqlConnectionFactory) 
    : IQueryHandler<FindAdvertisementsQuery, IReadOnlyList<AdvertisementResponse>>
{
    public async Task<Result<IReadOnlyList<AdvertisementResponse>>> Handle(FindAdvertisementsQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();
        
        const string sql = """
                           SELECT
                               a.id AS Id,
                               a.title AS Title,
                               a.description AS Description
                           FROM advertisements AS a
                           """;

        var apartments = await connection
            .QueryAsync<AdvertisementResponse>(
                sql
            );

        return apartments.ToList();
    }
}   
