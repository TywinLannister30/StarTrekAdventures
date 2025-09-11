using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class CareerPathController : ControllerBase
{
    private readonly ICareerPathManager _careerPathManager;

    public CareerPathController(ICareerPathManager careerPathManager)
    {
        _careerPathManager = careerPathManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_careerPathManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<CareerPath>> Get()
    {
        return Ok(_careerPathManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<CareerPath> GetSingle(string name)
    {
        var careerPath = _careerPathManager.Get(name);

        if (careerPath == null) return NotFound("No career path found.");

        return Ok(careerPath);
    }
}
