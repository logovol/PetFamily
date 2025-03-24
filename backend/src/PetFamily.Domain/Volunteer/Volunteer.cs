using CSharpFunctionalExtensions;

namespace PetFamily.Domain.Volunteer;

public class Volunteer
{
    private readonly List<Pet> _pets = [];
    
    // ef core
    private Volunteer()
    {
    }
    
    private Volunteer(string fullName, string description)
    {
        FullName = fullName;
        Description = description;
    }
    
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public byte Experience { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public SocialMedia SocialMedia { get; private set; } = default!;
    public PaymentDetails PaymentDetails { get; private set; } = default!;
    public IReadOnlyList<Pet> Pets => _pets;

    public List<Pet> NotAvailable => _pets.FindAll(x => x.PetStatus == Pet.Status.Unavailable);
    public List<Pet> Available => _pets.FindAll(x => x.PetStatus == Pet.Status.Available);
    public List<Pet> InTreatment => _pets.FindAll(x => x.PetStatus == Pet.Status.InTreatment);
    
    public static Result<Volunteer> Create(string fullName, string description)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return Result.Failure<Volunteer>("Volunteer is required.");
        }
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Volunteer>("Description is required.");
        
        var volunteer = new Volunteer(fullName, description);
        return Result.Success(volunteer);
    }
}