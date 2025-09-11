using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IEnvironmentManager
{
    List<CharacterEnvironment> GetAll();

    List<string> GetAllNames();

    CharacterEnvironment Get(string name);
}
