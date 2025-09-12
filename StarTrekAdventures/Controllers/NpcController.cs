using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class NpcController : ControllerBase
{
    private readonly INpcManager _npcManager;

    public NpcController(INpcManager npcManager)
    {
        _npcManager = npcManager;
    }

    [HttpPost("{name}/generate/")]
    public ActionResult<List<string>> GenerateNpc(string name)
    {
        return Ok(_npcManager.GenerateNpc(name));
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
    public ActionResult<List<NonPlayerCharacter>> GetAllByTrait(string trait)
    {
        return Ok(_npcManager.GetAllByTrait(trait));
    }

    [HttpGet("{name}")]
    public ActionResult<NonPlayerCharacter> GetSingle(string name)
    {
        var npc = _npcManager.Get(name);

        if (npc == null) return NotFound("No npc found.");

        return Ok(npc);
    }
}
