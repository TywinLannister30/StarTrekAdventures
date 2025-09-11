using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class EnvironmentController : ControllerBase
{
    private readonly IEnvironmentManager _environmentManager;

    public EnvironmentController(IEnvironmentManager environmentManager)
    {
        _environmentManager = environmentManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_environmentManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<CharacterEnvironment>> Get()
    {
        return Ok(_environmentManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<CharacterEnvironment> GetSingle(string name)
    {
        var environment = _environmentManager.Get(name);

        if (environment == null) return NotFound("No environment found.");

        return Ok(environment);
    }
}
