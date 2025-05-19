using System.Net;
using MapMyJourneyAPI.Application.Constants.ErrorMessages;
using MapMyJourneyAPI.Application.Exceptions;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Interfaces;
using LocationEntity = MapMyJourneyAPI.Domain.Entities.Location;

namespace MapMyJourneyAPI.Application.Location.Commands;

public class UpdateLocationCommand : IRequest<LocationEntity>
{
    public string PlaceId { get; set; }
    public string Name { get; set; }
    public LocationAddress Address { get; set; }
    public LocationGeometry Geometry { get; set; }
    public LocationPhotoReference[] PhotoReferences { get; set; }


    public UpdateLocationCommand(string placeId, string name, LocationAddress address, LocationGeometry geometry, LocationPhotoReference[] photoReferences)
    {
        PlaceId = placeId;
        Name = name;
        Address = address;
        Geometry = geometry;
        PhotoReferences = photoReferences;
    }
}

public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, LocationEntity>
{
    private readonly ILocationRepository _repository;

    public UpdateLocationCommandHandler(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<LocationEntity> Handle(UpdateLocationCommand request)
    {
        var location = await _repository.GetLocationByPlaceIdAsync(request.PlaceId) ?? throw new HttpResponseException(HttpStatusCode.NotFound, LocationErrorMessages.LocationNotFound);
        location.Name = request.Name;
        location.Address = request.Address;
        location.Geometry = request.Geometry;
        location.PhotoReferences = request.PhotoReferences;
        await _repository.UpdateLocationAsync(location);
        return location;
    }
}
