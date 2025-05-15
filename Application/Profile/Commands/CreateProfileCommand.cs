using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Commands;

public class CreateProfileCommand : IRequest<ProfileEntity>
{
    public string Name { get; set; }
    public string Auth0Id { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime LastLogin { get; set; }
    public string ProfilePictureUrl { get; set; }
    public Identity[] Identities { get; set; }


    public CreateProfileCommand(string name, string auth0Id, string email, DateTime createdAt, DateTime updatedAt, DateTime lastLogin, string profilePictureUrl, Identity[] identities)
    {
        Name = name;
        Auth0Id = auth0Id;
        Email = email;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        LastLogin = lastLogin;
        ProfilePictureUrl = profilePictureUrl;
        Identities = identities;
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
        var profileId = Guid.NewGuid();
        var profile = new ProfileEntity
        {
            Id = profileId,
            Name = request.Name,
            Auth0Id = request.Auth0Id,
            Email = request.Email,
            CreatedAt = request.CreatedAt,
            UpdatedAt = request.UpdatedAt,
            LastLogin = request.LastLogin,
            ProfilePictureUrl = request.ProfilePictureUrl,
        };

        await _repository.AddAsync(profile, request.Identities);
        return profile;
    }
}
