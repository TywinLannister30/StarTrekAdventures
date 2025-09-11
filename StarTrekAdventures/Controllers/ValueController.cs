using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class ValueController : ControllerBase
{
    private readonly IValueManager _valueManager;

    public ValueController(IValueManager valueManager)
    {
        _valueManager = valueManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_valueManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Value>> Get()
    {
        return Ok(_valueManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Value> GetSingle(string name)
    {
        var role = _valueManager.Get(name);

        if (role == null) return NotFound("No role found.");

        return Ok(role);
    }

    [HttpGet("species/{species}")]
    public ActionResult<List<Value>> GetBySpecies(string species)
    {
        return Ok(_valueManager.GetAllBySpecies(species));
    }

    [HttpGet("species/{species}/name")]
    public ActionResult<List<Value>> GetNamesBySpecies(string species)
    {
        return Ok(_valueManager.GetAllNamesBySpecies(species));
    }
}
