namespace MapMyJourneyAPI.Domain.Entities
{
    public class LocationPhotoReference
    {
        public Guid Id { get; set; }
        public required string PlaceId { get; set; }
        public required string PhotoReference { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string? Attribution { get; set; }
        public DateTime CreatedAt { get; set; }
        public Location? Location { get; set; }
    }
}