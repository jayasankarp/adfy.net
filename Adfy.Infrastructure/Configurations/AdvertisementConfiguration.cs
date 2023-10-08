using Adfy.Domain.Advertisements;
using Adfy.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adfy.Infrastructure.Configurations;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder.ToTable("advertisements");

        builder.HasKey(advertisement => advertisement.Id);

        builder.Property(advertisement => advertisement.Id)
            .HasConversion(advertisement => advertisement.Value, value => new AdvertisementId(value));

        builder.Property(advertisement => advertisement.Title)
            .HasMaxLength(512)
            .HasConversion(firstName => firstName.Value, value => new Title(value));

        builder.Property(advertisement => advertisement.Description)
            .HasMaxLength(4000)
            .HasConversion(firstName => firstName.Value, value => new Description(value));
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(advertisement => advertisement.UserId);

        builder.Property(advertisement => advertisement.IsPublished);

        builder.Property(advertisement => advertisement.IsArchived);
        
        builder.Property(advertisement => advertisement.CreatedOn);
        
        builder.Property(advertisement => advertisement.UpdatedOn);
    }
}