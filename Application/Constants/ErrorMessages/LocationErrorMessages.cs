namespace MapMyJourneyAPI.Application.Constants.ErrorMessages
{
    public static class LocationErrorMessages
    {
        public const string LocationNotFound = "Location not found.";
        public const string LocationAlreadyExists = "Location already exists.";
        public const string InvalidPlaceId = "Invalid place ID.";
        public const string LocationGeometryIsInvalid = "Location geometry is invalid.";
        public const string LocationAddressIsInvalid = "Location address is invalid.";
        public const string LocationPhotoReferenceIsInvalid = "Location photo reference is invalid.";
        public const string LocationTypeNotSupported = "Location type is not supported.";
        public const string LocationCreationFailed = "Location creation failed.";
    }
}