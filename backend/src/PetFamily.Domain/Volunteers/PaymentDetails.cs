namespace PetFamily.Domain.Volunteers;

public record PaymentDetails
{
    public List<Payment> Payments { get; }
}

public record Payment
{
    public string Name { get; } = default!;
    public string Description { get; } = default!;
}