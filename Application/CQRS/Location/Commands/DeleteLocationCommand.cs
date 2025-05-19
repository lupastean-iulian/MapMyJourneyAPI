using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Interfaces;

namespace MapMyJourneyAPI.Application.Location.Commands;

public class DeleteLocationCommand : IRequest<Unit>
{
    public string PlaceId { get; set; }

    public DeleteLocationCommand(string placeId)
    {
        PlaceId = placeId;
    }
}

public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
{
    private readonly ILocationRepository _repository;

    public DeleteLocationCommandHandler(ILocationRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteLocationCommand request)
    {
        await _repository.DeleteLocationAsync(request.PlaceId);
        return Unit.Value;
    }
}
