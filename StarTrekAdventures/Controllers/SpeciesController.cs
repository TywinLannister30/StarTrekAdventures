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
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_speciesManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Species>> Get()
    {
        return Ok(_speciesManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Species> GetSingle(string name)
    {
        var species = _speciesManager.Get(name);

        if (species == null) return NotFound("No species found.");

        return Ok(species);
    }
}
