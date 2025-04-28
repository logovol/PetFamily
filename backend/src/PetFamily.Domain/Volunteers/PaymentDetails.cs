namespace PetFamily.Domain.Volunteers;

public record PaymentDetails
{
    public List<Payment> Payments { get; set; }
}

public record Payment
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
}