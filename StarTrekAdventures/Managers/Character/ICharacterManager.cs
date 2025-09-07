using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers
{
    public interface ICharacterManager
    {
        Character CreateCharacter(string species);
        //ActionResult<CharacterSummary> CreateCharacterSummary(string species);
    }
}
