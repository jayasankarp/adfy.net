namespace Adfy.Domain.Abstractions;

public abstract class Entity<TEntityId> : IEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(TEntityId id)
    {
        Id = id;
    }

    /*protected Entity()
    {
    }*/

    public TEntityId Id { get; init; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}

public abstract class AuditableEntity<TEntityId> : Entity<TEntityId>
{
    protected AuditableEntity(TEntityId id) : base(id)
    {
        Id = id;
    }

    /*protected AuditableEntity()
    {
    }*/
    
    public DateTime CreatedOn { get; private set;  } = DateTime.Now;
    
    public DateTime? UpdatedOn { get; set;  }
}