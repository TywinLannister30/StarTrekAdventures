using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class SpeciesController : ControllerBase
{
    private readonly ISpeciesManager _speciesManager;

    public SpeciesController(ISpeciesManager speciesManager)
    {
        _speciesManager = speciesManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> AllSpeciesNames()
    {
        return Ok(_speciesManager.GetAllSpeciesNames());
    }

    [HttpGet]
    public ActionResult<List<Species>> Species()
    {
        return Ok(_speciesManager.GetAllSpecies());
    }

    [HttpGet("{name}")]
    public ActionResult<Species> Species(string name)
    {
        var species = _speciesManager.GetSpecies(name);

        if (species == null) return NotFound("No species found.");

        return Ok(species);
    }
}
