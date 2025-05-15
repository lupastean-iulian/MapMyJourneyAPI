namespace MapMyJourneyAPI.Domain.Entities;

public class Profile
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Auth0Id { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastLogin { get; set; }
    public ICollection<Identity> Identities { get; set; } = [];
}
