using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteers;

public record SocialMediaDetails
{
    public List<SocialMedia> SocialMedias { get; }
}

public record SocialMedia
{
    public string Name { get; }
    public string Url { get; }
    
    private SocialMedia(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public static Result<SocialMedia> Create(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name))
            return "Social media Name is required";
        
        if(string.IsNullOrWhiteSpace(url))
            return "Social media URL is required";
        
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            return "Url must be a valid absolute URI.";
        
        var socialMedia = new SocialMedia(name, url);

        return socialMedia;
    }
}