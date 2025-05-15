using MapMyJourneyAPI.Domain.Entities;

namespace MapMyJourneyAPI.API.DTO;

public class UserSyncModel
{
    public required string Auth0Id { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastLogin { get; set; }
    public Identity[] Identities { get; set; } = [];
    public required string Picture { get; set; }

}