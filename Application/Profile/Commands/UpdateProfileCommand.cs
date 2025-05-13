using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Commands;

public class UpdateProfileCommand : IRequest<ProfileEntity>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public UpdateProfileCommand(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, ProfileEntity>
{
    private readonly IProfileRepository _repository;

    public UpdateProfileCommandHandler(IProfileRepository repository)
    {
        _repository = repository;
    }

    public async Task<ProfileEntity> Handle(UpdateProfileCommand request)
    {
        var profile = await _repository.GetByIdAsync(request.Id);
        if (profile == null)
        {
            throw new KeyNotFoundException("Profile not found.");
        }

        profile.FirstName = request.FirstName;
        profile.LastName = request.LastName;
        profile.Email = request.Email;

        await _repository.UpdateAsync(profile);
        return profile;
    }
}
