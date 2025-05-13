using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Application.Profile.Commands;
using MapMyJourneyAPI.Application.Profile.Queries;
using MapMyJourneyAPI.Domain.Entities;
using MapMyJourneyAPI.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace MapMyJourneyAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfileController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Profile>> GetProfileById(Guid id)
    {
        var result = await _mediator.Send<GetProfileByIdQuery, Profile>(new GetProfileByIdQuery(id));
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<Profile>>> GetAllProfiles()
    {
        var result = await _mediator.Send<GetAllProfilesQuery, List<Profile>>( new GetAllProfilesQuery());
        return Ok(result);
    }

    [HttpGet("paginated")]
    public async Task<ActionResult> GetPaginatedProfiles([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = await _mediator.Send<GetPaginatedProfilesQuery, PaginatedResponse<Profile>>(new GetPaginatedProfilesQuery(page, pageSize));
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Profile>> CreateProfile([FromBody] CreateProfileCommand command)
    {
        var result = await _mediator.Send<CreateProfileCommand, Profile>(command);
        return CreatedAtAction(nameof(GetProfileById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Profile>> UpdateProfile(Guid id, [FromBody] UpdateProfileCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID mismatch.");
        }
        var result = await _mediator.Send<UpdateProfileCommand, Profile>(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProfile(Guid id)
    {
        await _mediator.Send<DeleteProfileCommand, Unit>(new DeleteProfileCommand(id));
        return NoContent();
    }
}
