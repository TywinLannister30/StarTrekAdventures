using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class EnvironmentManager : IEnvironmentManager
{
    private readonly IEnvironmentSelector _environmentSelector;

    public EnvironmentManager(IEnvironmentSelector environmentSelector)
    {
        _environmentSelector = environmentSelector;
    }

    public List<CharacterEnvironment> GetAll()
    {
        return _environmentSelector.GetAllEnvironments();
    }

    public List<string> GetAllNames()
    {
        return _environmentSelector.GetAllEnvironments().Select(x => x.Name).ToList();
    }

    public CharacterEnvironment Get(string name)
    {
        return _environmentSelector.GetEnvironment(name);
    }
}
