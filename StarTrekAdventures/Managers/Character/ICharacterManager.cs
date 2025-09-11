using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ICharacterManager
{
    Character CreateCharacter(string species);
}
