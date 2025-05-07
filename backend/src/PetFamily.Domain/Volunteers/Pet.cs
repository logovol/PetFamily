using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Volunteers;

public class Pet : Entity<PetId>
{
    // ef core
    private Pet(PetId id) : base(id)
    {
    }
    
    private Pet(PetId petId, Status status, string nickname)
        : base(petId)
    {
        Id = petId;
        PetStatus = status;
        Nickname = nickname;
    }
    
    public PetId Id { get; private set; }
    public string Nickname { get; private set; } = default!;
    public SpeciesId SpeciesId { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public BreedId BreedId { get; private set; } = default!;
    public string Colour { get; private set; } = default!;
    public string HealthInformation { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public bool Sterilized  { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Vaccinated { get; private set; }

    public enum Status
    {
        Available,
        Unavailable,
        InTreatment
    }
    
    public Status PetStatus { get; private set; }
    public PaymentDetails? PaymentDetails { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public static Result<Pet> Create(PetId petId, Status status, string nickname)
    {
        if (string.IsNullOrWhiteSpace(nickname))
        {
            return $"'{nameof(nickname)}' cannot be null or empty.";
        }
        
        // Check to prevent the default value.
        if (!Enum.IsDefined(typeof(Status), status))
        {
            return $"'{nameof(status)}' is not a valid status.";
        }
        
        var pet = new Pet(petId, status, nickname);

        //return Result<Pet>.Success(pet);
        return pet;
    }
}