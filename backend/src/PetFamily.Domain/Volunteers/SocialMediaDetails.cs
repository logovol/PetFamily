namespace PetFamily.Domain.Volunteers;

public record SocialMediaDetails
{
    public List<SocialMedia> SocialMedias { get; }
}

public record SocialMedia
{
    public string Name { get; } = default!;
}