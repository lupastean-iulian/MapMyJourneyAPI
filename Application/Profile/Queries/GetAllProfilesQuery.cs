using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Queries;

public class GetAllProfilesQuery : IRequest<List<ProfileEntity>>
{
}

public class GetAllProfilesQueryHandler : IRequestHandler<GetAllProfilesQuery, List<ProfileEntity>>
{
    private readonly IProfileRepository _repository;

    public GetAllProfilesQueryHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProfileEntity>> Handle(GetAllProfilesQuery request)
    {
        return await _repository.GetAllAsync();
    }
}
