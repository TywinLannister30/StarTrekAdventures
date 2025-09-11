using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class ExperienceController : ControllerBase
{
    private readonly IExperienceManager _experienceManager;

    public ExperienceController(IExperienceManager experienceManager)
    {
        _experienceManager = experienceManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_experienceManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<Experience>> Get()
    {
        return Ok(_experienceManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<Experience> GetSingle(string name)
    {
        var experience = _experienceManager.Get(name);

        if (experience == null) return NotFound("No experience found.");

        return Ok(experience);
    }
}
