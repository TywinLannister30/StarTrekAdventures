using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class UpbringingController : ControllerBase
{
    private readonly IUpbringingManager _upbringingManager;

    public UpbringingController(IUpbringingManager upbringingManager)
    {
        _upbringingManager = upbringingManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_upbringingManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Upbringing>> Get()
    {
        return Ok(_upbringingManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Upbringing> GetSingle(string name)
    {
        var upbringing = _upbringingManager.Get(name);

        if (upbringing == null) return NotFound("No upbringing found.");

        return Ok(upbringing);
    }
}
