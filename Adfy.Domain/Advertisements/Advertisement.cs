using Adfy.Domain.Abstractions;
using Adfy.Domain.Users;

namespace Adfy.Domain.Advertisements;

public sealed class Advertisement : AuditableEntity<AdvertisementId>
{
    public Advertisement(AdvertisementId id, Title title, Description description, string userId)
        : base(id)
    {
        Title = title;
        Description = description;
        UserId = userId;
    }

    /*private Advertisement()
    {
        
    }*/
    
    public Title Title { get; private set; }
    
    public Description Description { get; private set; }
    
    public string UserId { get; private set; }

    public bool IsPublished { get; private set; }
    
    public bool IsArchived { get; private set; }
    
    public void Publish()
    {
        IsPublished = true;
    }
    
    public void Archive()
    {
        IsArchived = true;
    }
    
    public static Advertisement Create(Title title, Description description, string userId)
    {
        var advertisement = new Advertisement(AdvertisementId.New(), title, description, userId);
        
        return advertisement;
    }
}