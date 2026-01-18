using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IEnvironmentSelector
{
    CharacterEnvironment ChooseEnvironment(string species);

    CharacterEnvironment GetEnvironment(string name);

    List<CharacterEnvironment> GetAllEnvironments();
}
