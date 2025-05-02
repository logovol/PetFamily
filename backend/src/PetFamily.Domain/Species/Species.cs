using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Species : Shared.Entity<SpeciesId>
{
    private readonly List<Breed> _breeds = [];
    private Species(SpeciesId id) : base(id)
    {
    }

    private Species(SpeciesId speciesId, string name) : base(speciesId)
    {
       Id = speciesId;
       Name = name;
    }
    
    public SpeciesId Id { get; private set; }
    public string Name { get; private set; } = default!;
    //public List<Breed> Breeds { get; private set; } = [];
    public IReadOnlyList<Breed> Breeds => _breeds;
    
    public static Result<Species> Create(SpeciesId speciesId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return $"'{nameof(name)}' cannot be null or empty.";
        }
        
        var species = new Species(speciesId, name);
        
        return species;
    }
}

public record SpeciesId
{
    private SpeciesId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    public static SpeciesId NewSpeciesId() => new(Guid.NewGuid());
    public static SpeciesId Empty() => new(Guid.Empty);
    public static SpeciesId Create(Guid id) => new(id);
}