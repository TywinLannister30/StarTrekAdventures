using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class RankController : ControllerBase
{
    private readonly IRankManager _rankManager;

    public RankController(IRankManager rankManager)
    {
        _rankManager = rankManager;
    }

    [HttpGet]
    public ActionResult<List<string>> Get()
    {
        return Ok(_rankManager.GetAll());
    }
}
