using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Infrastructure.Configurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PetId.Create(value));
        
        builder.Property(x => x.Nickname)
            .IsRequired()
            .HasMaxLength(Constants.MAX_NAME_LENGTH);

        builder.Property(x => x.SpeciesId)
            .HasConversion(
                id => id.Value,                         // to db
                value => SpeciesId.Create(value)); // from db
            
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(Constants.MAX_TEXT_LENGTH);

        builder.Property(x => x.BreedId)
            .HasConversion(
                id => id.Value,                          // to db
                value => BreedId.Create(value));    // from db
        
        builder.Property(x => x.Colour)
            .HasMaxLength(Constants.MAX_TEXT_LENGTH);

        builder.Property(x => x.HealthInformation)
            .HasMaxLength(Constants.MAX_TEXT_LENGTH);

        builder.Property(x => x.Address)
            .HasMaxLength(Constants.MAX_ADRESS_LENGTH);

        builder.Property(x => x.Weight)
            .IsRequired();
        
        builder.Property(x => x.Height)
            .IsRequired();

        builder.Property(x => x.PhoneNumber);
        
        builder.Property(x => x.Sterilized)
            .IsRequired();
        
        builder.Property(x => x.BirthDate)
            .IsRequired();
        
        builder.Property(x => x.Vaccinated)
            .IsRequired();
        
        builder.Property(x => x.PetStatus)
            .IsRequired();
        
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
        
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");
    }
}