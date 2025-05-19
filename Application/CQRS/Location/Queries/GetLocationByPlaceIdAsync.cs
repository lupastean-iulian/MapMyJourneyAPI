using System.Net;
using MapMyJourneyAPI.Application.Constants.ErrorMessages;
using MapMyJourneyAPI.Application.Exceptions;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Interfaces;
using LocationEntity = MapMyJourneyAPI.Domain.Entities.Location;

namespace Application.CQRS.Location.Queries
{
    public class GetLocationByPlaceIdQuery : IRequest<LocationEntity>
    {
        public string PlaceId { get; set; }

        public GetLocationByPlaceIdQuery(string placeId)
        {
            PlaceId = placeId;
        }
    }

    public class GetLocationByPlaceIdQueryHandler : IRequestHandler<GetLocationByPlaceIdQuery, LocationEntity>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByPlaceIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<LocationEntity> Handle(GetLocationByPlaceIdQuery request)
        {
            return await _locationRepository.GetLocationByPlaceIdAsync(request.PlaceId) ?? throw new HttpResponseException(HttpStatusCode.NotFound, LocationErrorMessages.LocationNotFound);
        }
    }
}