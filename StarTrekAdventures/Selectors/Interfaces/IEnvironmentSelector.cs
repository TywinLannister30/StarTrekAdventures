using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IEnvironmentSelector
{
    CharacterEnvironment ChooseEnvironment();

    CharacterEnvironment GetEnvironment(string name);

    List<CharacterEnvironment> GetAllEnvironments();
}
