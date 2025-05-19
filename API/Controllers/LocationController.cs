using Application.CQRS.Location.Commands;
using Application.CQRS.Location.Queries;
using MapMyJourneyAPI.Application.Location.Commands;
using MapMyJourneyAPI.Application.Mediator;
using MapMyJourneyAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MapMyJourneyAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{placeId}")]
    [Authorize]
    public async Task<ActionResult<Location>> GetLocationById(string placeId)
    {
        var result = await _mediator.Send<GetLocationByPlaceIdQuery, Location>(new GetLocationByPlaceIdQuery(placeId));
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Location>> CreateLocation([FromBody] CreateLocationCommand command)
    {
        var result = await _mediator.Send<CreateLocationCommand, Location>(command);
        return CreatedAtAction(nameof(GetLocationById), new { placeId = result.PlaceId }, result);
    }

    [HttpPut("{placeId}")]
    [Authorize]
    public async Task<ActionResult<Location>> UpdateLocation(string placeId, [FromBody] UpdateLocationCommand command)
    {
        if (placeId != command.PlaceId)
        {
            return BadRequest("Place ID mismatch.");
        }

        var result = await _mediator.Send<UpdateLocationCommand, Location>(command);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("{placeId}")]
    [Authorize]
    public async Task<IActionResult> DeleteLocation(string placeId)
    {
        await _mediator.Send<DeleteLocationCommand, Unit>(new DeleteLocationCommand(placeId));
        return NoContent();
    }

}