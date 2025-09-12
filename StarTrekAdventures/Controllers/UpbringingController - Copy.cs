using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class SpaceframeController : ControllerBase
{
    private readonly ISpaceframeManager _spaceframeManager;

    public SpaceframeController(ISpaceframeManager spaceframeManager)
    {
        _spaceframeManager = spaceframeManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_spaceframeManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Spaceframe>> Get()
    {
        return Ok(_spaceframeManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Spaceframe> GetSingle(string name)
    {
        var spaceframe = _spaceframeManager.Get(name);

        if (spaceframe == null) return NotFound("No spaceframe found.");

        return Ok(spaceframe);
    }
}
