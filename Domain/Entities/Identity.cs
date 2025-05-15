using System.Text.Json.Serialization;

namespace MapMyJourneyAPI.Domain.Entities;

public class Identity
{
    public Guid Id { get; set; }
    public Guid ProfileId { get; set; }
    public required string Connection { get; set; }
    public required string Provider { get; set; }
    public required string Auth0Id { get; set; }
    public required bool IsSocial { get; set; }
    [JsonIgnore]
    public Profile Profile { get; set; }
}