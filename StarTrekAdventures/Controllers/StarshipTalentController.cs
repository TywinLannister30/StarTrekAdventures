using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class StarshipTalentController : ControllerBase
{
    private readonly IStarshipTalentManager _talentManager;

    public StarshipTalentController(IStarshipTalentManager talentManager)
    {
        _talentManager = talentManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_talentManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<StarshipTalent>> Get()
    {
        return Ok(_talentManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<StarshipTalent> GetSingle(string name)
    {
        var talent = _talentManager.Get(name);

        if (talent == null) return NotFound("No starship talent found.");

        return Ok(talent);
    }
}
