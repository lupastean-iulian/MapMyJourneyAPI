using System.Net;
using MapMyJourneyAPI.Application.Constants.ErrorMessages;
using MapMyJourneyAPI.Application.Exceptions;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Interfaces;
using ProfileEntity = MapMyJourneyAPI.Domain.Entities.Profile;

namespace MapMyJourneyAPI.Application.Profile.Commands;

public class UpdateProfileCommand : IRequest<ProfileEntity>
{
    public Guid ProfileId { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Address { get; set; }

    public UpdateProfileCommand(Guid id, string phoneNumber, DateTime? dateOfBirth, string address)
    {
        ProfileId = id;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Address = address;
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
        var profile = await _repository.GetByIdAsync(request.ProfileId) ?? throw new HttpResponseException(HttpStatusCode.NotFound, ProfileErrorMessages.ProfileNotFound);
        await _repository.UpdateAsync(profile);
        return profile;
    }
}
