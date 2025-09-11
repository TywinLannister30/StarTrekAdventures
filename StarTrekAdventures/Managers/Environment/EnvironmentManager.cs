using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class EnvironmentManager : IEnvironmentManager
{
    public List<CharacterEnvironment> GetAll()
    {
        return EnvironmentSelector.GetAllEnvironments();
    }

    public List<string> GetAllNames()
    {
        return EnvironmentSelector.GetAllEnvironments().Select(x => x.Name).ToList();
    }

    public CharacterEnvironment Get(string name)
    {
        return EnvironmentSelector.GetEnvironment(name);
    }
}
