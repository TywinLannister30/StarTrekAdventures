using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleManager _roleManager;

    public RoleController(IRoleManager roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_roleManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Role>> Get()
    {
        return Ok(_roleManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Role> GetSingle(string name)
    {
        var role = _roleManager.Get(name);

        if (role == null) return NotFound("No role found.");

        return Ok(role);
    }
}
