using Microsoft.AspNetCore.Mvc;
using MapMyJourneyAPI.API.DTO;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Application.Profile.Commands;
using MapMyJourneyAPI.Domain.Entities;
namespace MapMyJourneyAPI.API.Controllers;

[ApiController]
[Route("api/auth0")]
public class AuthController : ControllerBase
{
    private readonly string _apiKey;
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _apiKey = configuration["Auth0:APIKey"] ?? throw new ArgumentNullException("Auth0:APIKey configuration is missing.");
    }

    [HttpPost("sync-user")]
    public async Task<IActionResult> SyncUser([FromBody] UserSyncModel user, [FromHeader(Name = "x-api-key")] string apiKey)
    {
        var now = DateTime.UtcNow;
        if (apiKey != _apiKey)
        {
            return Unauthorized(new { message = "Invalid API key." });
        }
        DateTime? dob = null;
        if (!string.IsNullOrWhiteSpace(user.Dob) && DateTime.TryParse(user.Dob, out var parsedDob))
        {
            dob = parsedDob;
        }
        var command = new CreateProfileCommand(
            user.Name,
            user.Auth0Id,
            user.Email,
            now,
            now,
            now,
            user.Picture,
            user.Identities,
            user.PhoneNumber,
            dob,
            user.Address
        );

        var result = await _mediator.Send<CreateProfileCommand, Profile>(command);
        return Ok(result);
    }
}

