using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure.Configurations;

public class BreedConfiguration : IEntityTypeConfiguration<Breed>
{
    public void Configure(EntityTypeBuilder<Breed> builder)
    {
        builder.ToTable("breeds");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => BreedId.Create(value));
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_NAME_LENGTH);
    }
}