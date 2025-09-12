using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class TalentController : ControllerBase
{
    private readonly ITalentManager _talentManager;

    public TalentController(ITalentManager talentManager)
    {
        _talentManager = talentManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_talentManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Talent>> Get()
    {
        return Ok(_talentManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Talent> GetSingle(string name)
    {
        var talent = _talentManager.Get(name);

        if (talent == null) return NotFound("No talent found.");

        return Ok(talent);
    }
}
