using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class NpcStarshipController : ControllerBase
{
    private readonly INpcStarshipManager _npcManager;

    public NpcStarshipController(INpcStarshipManager npcManager)
    {
        _npcManager = npcManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_npcManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<NonPlayerCharacter>> Get()
    {
        return Ok(_npcManager.GetAll());
    }

    [HttpGet("trait/{trait}")]
    public ActionResult<List<NpcStarship>> GetAllByTrait(string trait)
    {
        return Ok(_npcManager.GetAllByTrait(trait));
    }

    [HttpGet("{name}")]
    public ActionResult<NpcStarship> GetSingle(string name)
    {
        var npc = _npcManager.Get(name);

        if (npc == null) return NotFound("No npc starship found.");

        return Ok(npc);
    }
}
