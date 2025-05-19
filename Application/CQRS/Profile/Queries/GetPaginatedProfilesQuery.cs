using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain;
using MapMyJourneyAPI.Domain.Interfaces;
using MapMyJourneyAPI.Domain.Pagination;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Queries;

public class GetPaginatedProfilesQuery : IRequest<PaginatedResponse<ProfileEntity>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }

    public GetPaginatedProfilesQuery(int page, int pageSize)
    {
        Page = page;
        PageSize = pageSize;
    }
}
public class GetPaginatedProfilesQueryHandler : IRequestHandler<GetPaginatedProfilesQuery, PaginatedResponse<ProfileEntity>>
{
    private readonly IProfileRepository _repository;

    public GetPaginatedProfilesQueryHandler(IProfileRepository repository)
    {
        _repository = repository;
    }


    public async Task<PaginatedResponse<ProfileEntity>> Handle(GetPaginatedProfilesQuery request)
    {
        return await _repository.GetPaginatedAsync(request.Page, request.PageSize);
    }
}
