using System.ComponentModel.DataAnnotations.Schema;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public sealed class Volunteer : Shared.Entity<VolunteerId>
{
    private readonly List<Pet> _pets = [];
    
    // ef core
    private Volunteer(VolunteerId id) : base(id)
    {
    }
    
    private Volunteer(VolunteerId volunteerId, string fullName, string description)
        : base(volunteerId)
    {
        Id = volunteerId;
        FullName = fullName;
        Description = description;
    }

    public VolunteerId Id { get; private set; }
    public string FullName { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public byte Experience { get; private set; }
    public string PhoneNumber { get; private set; } = default!;
    public SocialMediaDetails? SocialMediaDetails { get; private set; }
    public PaymentDetails? PaymentDetails { get; private set; }
    public IReadOnlyList<Pet> Pets => _pets;
    
    public List<Pet> NotAvailable()
    { 
        return _pets.FindAll(x => x.PetStatus == Pet.Status.Unavailable);
    }
    
    public List<Pet> Available()
    {
        return _pets.FindAll(x => x.PetStatus == Pet.Status.Available);    
    }
    
    public List<Pet> InTreatment()
    {
        return _pets.FindAll(x => x.PetStatus == Pet.Status.InTreatment);
    }

    public static Result<Volunteer> Create(VolunteerId volunteerId, string fullName, string description)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            //return Result<Volunteer>.Failure("Volunteer is required.");
            return "Volunteer is required.";
        }
        
        if (string.IsNullOrWhiteSpace(description))
            return "Description is required.";
        
        var volunteer = new Volunteer(volunteerId, fullName, description);
        
        //return Result<Volunteer>.Success(volunteer);
        return volunteer;
    }
}