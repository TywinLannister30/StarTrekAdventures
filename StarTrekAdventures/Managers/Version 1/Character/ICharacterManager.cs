using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Models.Version1;

namespace StarTrekAdventures.Managers.Version1
{
    public interface ICharacterManager
    {
        ActionResult<Character> CreateCharacter(string species);
        ActionResult<CharacterSummary> CreateCharacterSummary(string species);
    }
}
