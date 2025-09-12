using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class ReprimandController : ControllerBase
{
    private readonly IReprimandManager _reprimandManager;

    public ReprimandController(IReprimandManager reprimandManager)
    {
        _reprimandManager = reprimandManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_reprimandManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Award>> Get()
    {
        return Ok(_reprimandManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Award> GetSingle(string name)
    {
        var reprimand = _reprimandManager.Get(name);

        if (reprimand == null) return NotFound("No reprimand found.");

        return Ok(reprimand);
    }
}
