namespace PetFamily.Domain.Volunteer;

public class PaymentDetails
{
    public Guid Id { get; private set; }
    public string CardNumber { get; private set; } = default!;
    public string CardHolderName { get; private set; } = default!;
}