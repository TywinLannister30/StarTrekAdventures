using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers.Version1;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors.Version1;

namespace StarTrekAdventures.Controllers.Version1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterManager _characterManager;

        public CharacterController(ICharacterManager characterManager)
        {
            _characterManager = characterManager;
        }

        [HttpGet]
        public ActionResult<Character> Character(string species)
        {
            if (!string.IsNullOrEmpty(species) && SpeciesSelector.GetSpecies(species) == null)
                return BadRequest($"{species} is not a valid species.");

            return _characterManager.CreateCharacter(species);
        }

        [HttpGet("summary")]
        public ActionResult<CharacterSummary> CharacterSummary(string species)
        {
            if (!string.IsNullOrEmpty(species) && SpeciesSelector.GetSpecies(species) == null)
                return BadRequest($"{species} is not a valid species.");

            return _characterManager.CreateCharacterSummary(species);
        }
    }
}
