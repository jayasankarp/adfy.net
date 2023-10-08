using Adfy.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Adfy.Infrastructure;

using Application.Abstractions.Date;
using Application.Exceptions;

using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public sealed class ApplicationDbContext(DbContextOptions options,
        IDateTimeProvider dateTimeProvider)
    : IdentityDbContext<User>(options), IUnitOfWork
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };

    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }
}