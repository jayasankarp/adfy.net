using Adfy.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Adfy.Infrastructure.Repositories;

internal abstract class Repository<TEntity, TEntityId>
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    private readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(
        TEntityId id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<TEntity>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public void Add(TEntity entity)
    {
        DbContext.Add(entity);
    }
    
    public void Remove(TEntity entity)
    {
        DbContext.Remove(entity);
    }
}