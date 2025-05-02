using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species;

public class Breed : Shared.Entity<BreedId>
{
    private Breed(BreedId id) : base(id)
    {
    }
    
    private Breed(BreedId breedId, string name)
        : base(breedId)
    {
        Id = breedId;
        Name = name;
    }
    
    public BreedId Id { get; private set; }
    public string Name { get; private set; } = default!;
    
    public static Result<Breed> Create(BreedId breedId, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return $"'{nameof(name)}' cannot be null or empty.";
        }
        
        var breed = new Breed(breedId, name);

        return breed;
    }
}

public record BreedId
{
    private BreedId(Guid value)
    {
        Value = value;
    }
    public Guid Value { get; }
    
    public static BreedId NewBreedId() => new(Guid.NewGuid());
    public static BreedId Empty() => new(Guid.Empty);
    public static BreedId Create(Guid id) => new(id);
}