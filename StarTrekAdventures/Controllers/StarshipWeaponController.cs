using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class StarshipWeaponController : ControllerBase
{
    private readonly IStarshipWeaponManager _starshipWeaponManager;

    public StarshipWeaponController(IStarshipWeaponManager talentManager)
    {
        _starshipWeaponManager = talentManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_starshipWeaponManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<StarshipWeapon>> Get()
    {
        return Ok(_starshipWeaponManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<StarshipWeapon> GetSingle(string name)
    {
        var weapon = _starshipWeaponManager.Get(name);

        if (weapon == null) return NotFound("No starship weapon found.");

        return Ok(weapon);
    }
}
