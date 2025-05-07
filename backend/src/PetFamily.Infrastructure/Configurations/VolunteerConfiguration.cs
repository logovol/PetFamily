using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");
        builder.HasKey(v => v.Id);
        builder.Property(v => v.Id)
            .HasConversion(
                id => id.Value,
                value => VolunteerId.Create(value));
        builder.Property(v => v.FullName)
            .IsRequired()
            .HasMaxLength(Constants.MAX_NAME_LENGTH);

        builder.Property(v => v.Email);
        
        builder.Property(v => v.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TEXT_LENGTH);

        builder.Property(v => v.Experience);

        builder.Property(v => v.PhoneNumber)
            .HasMaxLength(Constants.PHONE_NUMBER_LENGTH);
        
        builder.OwnsOne(v => v.SocialMediaDetails, d =>
        {
            d.ToJson();
            d.OwnsMany(n => n.SocialMedias, sd =>
                sd.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_NAME_LENGTH));
        });
        
        builder.OwnsOne(v => v.PaymentDetails, d =>
        {
            d.ToJson();
            d.OwnsMany(p => p.Payments, pb =>
            {
                pb.Property(p =>p.Name)
                    .IsRequired()
                    .HasMaxLength(Constants.MAX_NAME_LENGTH);
                pb.Property(p => p.Description)
                    .HasMaxLength(Constants.MAX_TEXT_LENGTH);
            });
        });
        
        builder.HasMany(v => v.Pets)
            .WithOne()
            .HasForeignKey("volunteer_id");
    }
}