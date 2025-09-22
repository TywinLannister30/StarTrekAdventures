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
    private readonly ISpaceframeSelector _spaceframeSelector;

    public StarshipController(IStarshipManager starshipManager, ISpaceframeSelector spaceframeSelector)
    {
        _starshipManager = starshipManager;
        _spaceframeSelector = spaceframeSelector;
    }

    [HttpPost("generate")]
    public ActionResult<Starship> GenerateStarship(string spaceframe)
    {
        if (!string.IsNullOrEmpty(spaceframe) && _spaceframeSelector.GetSpaceframe(spaceframe) == null)
            return BadRequest($"{spaceframe} is not a valid spaceframe.");

        var starship = _starshipManager.CreateStarship(spaceframe);

        if (!starship.IsValid)
            return UnprocessableEntity(starship);

        return Ok(starship);
    }
}
