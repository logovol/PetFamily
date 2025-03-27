namespace PetFamily.Domain.Species;

public class Species
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = default!;
    public List<Breed> Breeds { get; private set; } = [];
}