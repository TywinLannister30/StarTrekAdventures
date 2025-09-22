using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ReprimandManager : IReprimandManager
{
    private readonly IReprimandSelector _reprimandSelector;

    public ReprimandManager(IReprimandSelector reprimandSelector)
    {
        _reprimandSelector = reprimandSelector;
    }

    public List<Reprimand> GetAll()
    {
        return _reprimandSelector.GetAllReprimands();
    }

    public List<string> GetAllNames()
    {
        return _reprimandSelector.GetAllReprimands().Select(x => x.Name).ToList();
    }

    public Reprimand Get(string name)
    {
        return _reprimandSelector.GetReprimand(name);
    }
}
