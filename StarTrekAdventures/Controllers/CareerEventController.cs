using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class CareerEventController : ControllerBase
{
    private readonly ICareerEventManager _careerEventManager;

    public CareerEventController(ICareerEventManager careerEventManager)
    {
        _careerEventManager = careerEventManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_careerEventManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<CareerEvent>> Get()
    {
        return Ok(_careerEventManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<CareerEvent> GetSingle(string name)
    {
        var careerEvent = _careerEventManager.Get(name);

        if (careerEvent == null) return NotFound("No career event found.");

        return Ok(careerEvent);
    }
}
