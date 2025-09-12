using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class StarshipController : ControllerBase
{
    private readonly IStarshipManager _starshipManager;

    public StarshipController(IStarshipManager starshipManager)
    {
        _starshipManager = starshipManager;
    }

    [HttpPost("generate")]
    public ActionResult<Starship> GenerateStarship(string spaceframe)
    {
        if (!string.IsNullOrEmpty(spaceframe) && SpaceframeSelector.GetSpaceframe(spaceframe) == null)
            return BadRequest($"{spaceframe} is not a valid spaceframe.");

        var starship = _starshipManager.CreateStarship(spaceframe);

        if (!starship.IsValid)
            return UnprocessableEntity(starship);

        return Ok(starship);
    }
}
