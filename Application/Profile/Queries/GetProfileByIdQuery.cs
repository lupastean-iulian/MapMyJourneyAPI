using System.Net;
using MapMyJourneyAPI.Application.Constants.ErrorMessages;
using MapMyJourneyAPI.Application.Exceptions;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Queries;

public class GetProfileByIdQuery : IRequest<ProfileEntity?>
{
    public Guid Id { get; set; }

    public GetProfileByIdQuery(Guid id)
    {
        Id = id;
    }
}

public class GetProfileByIdQueryHandler : IRequestHandler<GetProfileByIdQuery, ProfileEntity>
{
    private readonly IProfileRepository _repository;

    public GetProfileByIdQueryHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProfileEntity> Handle(GetProfileByIdQuery request)
    {
        var response = await _repository.GetByIdAsync(request.Id) ?? throw new HttpResponseException(HttpStatusCode.NotFound, ProfileErrorMessages.ProfileNotFound);
        return response;
    }
}
