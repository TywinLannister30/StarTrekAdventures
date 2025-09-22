using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface INpcSelector
{
    NonPlayerCharacter GetNonPlayerCharacter(string name);

    List<NonPlayerCharacter> GetAllNonPlayerCharacters();
}
