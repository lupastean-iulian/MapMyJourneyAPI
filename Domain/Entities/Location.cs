namespace MapMyJourneyAPI.Domain.Entities
{
    public class Location
    {
        // Location unique identifier is google maps place id
        public required string PlaceId { get; set; }

        public required string Name { get; set; } = string.Empty;

        // Latitude longitude coordinates
        public LocationGeometry? Geometry { get; set; }

        // Location details (e.g., address, city, state, country)
        public LocationAddress? Address { get; set; }

        // Images or photos associated with the location
        public LocationPhotoReference[]? PhotoReferences { get; set; } = [];

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}