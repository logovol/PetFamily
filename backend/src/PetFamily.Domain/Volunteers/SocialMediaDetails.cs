namespace PetFamily.Domain.Volunteers;

public record SocialMediaDetails
{
    public List<SocialMedia> SocialMedias { get; private set; }
}

public record SocialMedia
{
    public string Name { get; private set; } = default!;
}