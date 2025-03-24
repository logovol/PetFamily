using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer;

public class Pet
{
    // ef core
    private Pet()
    {
    }
    
    private Pet(Status status, Guid volunteerId, string nickname)
    {
        PetStatus = status;
        VolunteerId = volunteerId;
        Nickname = nickname;
    }
    
    public Guid Id { get; private set; }
    public Guid VolunteerId { get; private set; }
    public string Nickname { get; private set; } = default!;
    public Species Species { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Breed Breed { get; private set; } = default!;
    public string Colour { get; private set; } = default!;
    public string HealthInformation { get; private set; } = default!;
    public string Address { get; private set; } = default!;
    public double Weight { get; private set; }
    public double Height { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public bool Sterilized  { get; private set; }
    public DateTime BirthDate { get; private set; } = default!;
    public bool Vaccinated { get; private set; }

    public enum Status
    {
        Available,
        Unavailable,
        InTreatment
    }
    
    public Status PetStatus { get; private set; }
    public PaymentDetails PaymentDetails { get; private set; } = default!;
    public DateTime CreatedAt { get; private set; } = default!;
    
    public static Result<Pet> Create(Status status, Guid volunteerId, string nickname)
    {
        if (string.IsNullOrWhiteSpace(nickname))
        {
            return Result.Failure<Pet>($"'{nameof(nickname)}' cannot be null or empty.");
        }

        if (Guid.Empty == volunteerId)
        {
            return Result.Failure<Pet>($"'{nameof(volunteerId)}' cannot be empty.");
        }
        
        // Check to prevent the default value.
        if (!Enum.IsDefined(typeof(Status), status))
        {
            return Result.Failure<Pet>($"'{nameof(status)}' is not a valid status.");
        }
        
        var pet = new Pet(status, volunteerId, nickname);

        return Result.Success(pet);
    }
}