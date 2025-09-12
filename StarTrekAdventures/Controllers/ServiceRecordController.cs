using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class ServiceRecordController : ControllerBase
{
    private readonly IServiceRecordManager _serviceRecordManager;

    public ServiceRecordController(IServiceRecordManager serviceRecordManager)
    {
        _serviceRecordManager = serviceRecordManager;
    }

    [HttpGet("names")]
    public ActionResult<List<string>> GetAllNames()
    {
        return Ok(_serviceRecordManager.GetAllNames());
    }

    [HttpGet]
    public ActionResult<List<ServiceRecord>> Get()
    {
        return Ok(_serviceRecordManager.GetAll());
    }

    [HttpGet("{name}")]
    public ActionResult<ServiceRecord> GetSingle(string name)
    {
        var serviceRecord = _serviceRecordManager.Get(name);

        if (serviceRecord == null) return NotFound("No service record found.");

        return Ok(serviceRecord);
    }
}
