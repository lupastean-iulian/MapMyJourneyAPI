using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Commands;

public class DeleteProfileCommand : IRequest<Unit>
{
    public Guid Id { get; set; }

    public DeleteProfileCommand(Guid id)
    {
        Id = id;
    }
}

public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, Unit>
{
    private readonly IProfileRepository _repository;

    public DeleteProfileCommandHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProfileCommand request)
    {
        await _repository.DeleteAsync(request.Id);
        return Unit.Value;
    }
}
