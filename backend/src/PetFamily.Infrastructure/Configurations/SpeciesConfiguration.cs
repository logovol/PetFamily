using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Infrastructure.Configurations;

public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
{
    public void Configure(EntityTypeBuilder<Species> builder)
    {
        builder.ToTable("species");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => SpeciesId.Create(value));
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Constants.MAX_NAME_LENGTH);
        
        builder.HasMany(p => p.Breeds)
            .WithOne()
            .HasForeignKey("species_id");
    }
}