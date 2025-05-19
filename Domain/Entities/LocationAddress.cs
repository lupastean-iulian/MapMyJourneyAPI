using System;

namespace MapMyJourneyAPI.Domain.Entities
{
    public class LocationAddress
    {
        public Guid Id { get; set; }
        // Location unique identifier is google maps place id
        public required string PlaceId { get; set; }
        public required string FormattedAddress { get; set; }
        public required string CountryName { get; set; }
        public required string CountryCode { get; set; }
        //  A first-order civil entity below the country level. Within the United States, these administrative levels are states.
        public required string AdminAreaLevel1 { get; set; }
        // A second-order civil entity below the country level. Within the United States, these administrative levels are counties.
        public string? AdminAreaLevel2 { get; set; }
        // City, town, or other community entity within the administrative level.
        public string? Locality { get; set; }
        public string? StreetNumber { get; set; }
        public string? PostalCode { get; set; }
        public string[] AddressTypes { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public Location? Location { get; set; }
    }
}