using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Controllers;

[Route("api/v2/[controller]")]
[ApiController]
public class CharacterController : ControllerBase
{
    private readonly ICharacterManager _characterManager;

    public CharacterController(ICharacterManager characterManager)
    {
        _characterManager = characterManager;
    }

    [HttpPost("generate")]
    public ActionResult<Character> GenerateCharacter(string species)
    {
        if (!string.IsNullOrEmpty(species) && SpeciesSelector.GetSpecies(species) == null)
            return BadRequest($"{species} is not a valid species.");

        var character = _characterManager.CreateCharacter(species);

        if (!character.IsValid)
            return UnprocessableEntity(character);

        return Ok(character);
    }
}
