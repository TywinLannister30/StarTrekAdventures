using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class MissionProfileController : ControllerBase
{
    private readonly IMissionProfileManager _missionProfileManager;

    public MissionProfileController(IMissionProfileManager missionProfileManager)
    {
        _missionProfileManager = missionProfileManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_missionProfileManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<MissionProfile>> Get()
    {
        return Ok(_missionProfileManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<MissionProfile> GetSingle(string name)
    {
        var missionProfile = _missionProfileManager.Get(name);

        if (missionProfile == null) return NotFound("No mission profile found.");

        return Ok(missionProfile);
    }
}
