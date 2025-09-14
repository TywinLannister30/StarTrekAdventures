using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class SmallCraftController : ControllerBase
{
    private readonly ISmallCraftManager _smallCraftManager;

    public SmallCraftController(ISmallCraftManager smallCraftManager)
    {
        _smallCraftManager = smallCraftManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_smallCraftManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<SmallCraft>> Get()
    {
        return Ok(_smallCraftManager.GetAll());
    }

    [HttpGet("trait/{trait}")]
    public ActionResult<List<SmallCraft>> GetAllByTrait(string trait)
    {
        return Ok(_smallCraftManager.GetAllByTrait(trait));
    }

    [HttpGet("{name}")]
    public ActionResult<SmallCraft> GetSingle(string name)
    {
        var smallCraft = _smallCraftManager.Get(name);

        if (smallCraft == null) return NotFound("No small craft found.");

        return Ok(smallCraft);
    }
}
