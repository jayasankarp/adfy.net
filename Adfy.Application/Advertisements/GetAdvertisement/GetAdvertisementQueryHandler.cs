using Adfy.Application.Abstractions.Data;
using Adfy.Application.Abstractions.Messaging;
using Adfy.Application.Advertisements.Shared;
using Adfy.Domain.Abstractions;
using Dapper;

namespace Adfy.Application.Advertisements.GetAdvertisement;

internal sealed class GetAdvertisementQueryHandler(ISqlConnectionFactory sqlConnectionFactory) 
    : IQueryHandler<GetAdvertisementQuery, AdvertisementResponse>
{
    public async Task<Result<AdvertisementResponse>> Handle(GetAdvertisementQuery request, CancellationToken cancellationToken)
    {
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
                           SELECT
                               a.id AS Id,
                               a.title AS Title,
                               a.description AS Description
                           FROM advertisements AS a
                           WHERE id = @AdvertisementId
                           """;

        var booking = await connection.QueryFirstOrDefaultAsync<AdvertisementResponse>(
            sql,
            new
            {
                AdvertisementId = request.AdvertisementId.ToString().ToUpper()
            });

        return booking;
    }
}   
