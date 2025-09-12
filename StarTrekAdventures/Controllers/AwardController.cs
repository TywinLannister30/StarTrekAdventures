using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class AwardController : ControllerBase
{
    private readonly IAwardManager _awardManager;

    public AwardController(IAwardManager awardManager)
    {
        _awardManager = awardManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_awardManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Award>> Get()
    {
        return Ok(_awardManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Award> GetSingle(string name)
    {
        var upbringing = _awardManager.Get(name);

        if (upbringing == null) return NotFound("No award found.");

        return Ok(upbringing);
    }
}
