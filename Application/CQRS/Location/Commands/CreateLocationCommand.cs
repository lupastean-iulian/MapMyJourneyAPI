using System.Net;
using MapMyJourneyAPI.Application.Constants.ErrorMessages;
using MapMyJourneyAPI.Application.Exceptions;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Interfaces;
using LocationEntity = MapMyJourneyAPI.Domain.Entities.Location;

namespace Application.CQRS.Location.Commands
{
    public class CreateLocationCommand : IRequest<LocationEntity>
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public LocationAddress Address { get; set; }
        public LocationGeometry Geometry { get; set; }
        public LocationPhotoReference[] PhotoReferences { get; set; }

        public CreateLocationCommand(string placeId, string name, LocationAddress address, LocationGeometry geometry, LocationPhotoReference[] photoReferences)
        {
            PlaceId = placeId;
            Name = name;
            Address = address;
            Geometry = geometry;
            PhotoReferences = photoReferences;
        }
    }

    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, LocationEntity>
    {
        private readonly ILocationRepository _locationRepository;

        public CreateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationEntity> Handle(CreateLocationCommand request)
        {
            var location = new LocationEntity
            {
                PlaceId = request.PlaceId,
                Name = request.Name,
                Address = request.Address,
                Geometry = request.Geometry,
                PhotoReferences = request.PhotoReferences
            };
            return await _locationRepository.AddLocationAsync(location);
        }
    }
}