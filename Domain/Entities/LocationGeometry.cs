using System;

namespace MapMyJourneyAPI.Domain.Entities
{
    // Represents the geometry of a location (e.g., point, line, polygon)
    public class LocationGeometry
    {
        public Guid Id { get; set; }

        // Location unique identifier is google maps place id
        public required string PlaceId { get; set; }

        public required long Latitude { get; set; }

        public required long Longitude { get; set; }


        // Example: GeoJSON or WKT representation of geometry
        public string? GeometryData { get; set; }

        // Optional: Type of geometry (e.g., Point, LineString, Polygon)
        public string? GeometryType { get; set; }

        // Optional: Timestamp for auditing
        public DateTime CreatedAt { get; set; }

        public Location? Location { get; set; }
    }
}