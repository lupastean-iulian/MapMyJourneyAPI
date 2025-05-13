using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Commands;

public class CreateProfileCommand : IRequest<ProfileEntity>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public CreateProfileCommand(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}

public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, ProfileEntity>
{
    private readonly IProfileRepository _repository;

    public CreateProfileCommandHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProfileEntity> Handle(CreateProfileCommand request)
    {
        var profile = new ProfileEntity
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Address = string.Empty // Default value for Address
        };

        await _repository.AddAsync(profile);
        return profile;
    }
}
