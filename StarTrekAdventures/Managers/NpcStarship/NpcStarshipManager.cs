using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class NpcStarshipManager : INpcStarshipManager
{
    private readonly INpcStarshipSelector _npcStarshipSelector;

    public NpcStarshipManager(INpcStarshipSelector npcStarshipSelector)
    {
        _npcStarshipSelector = npcStarshipSelector;
    }

    public List<NpcStarship> GetAll()
    {
        return _npcStarshipSelector.GetAllNpcStarships();
    }

    public List<string> GetAllNames()
    {
        return _npcStarshipSelector.GetAllNpcStarships().Select(x => x.Name).ToList();
    }

    public NpcStarship Get(string name)
    {
        return _npcStarshipSelector.GetNpcStarship(name);
    }

    public List<NpcStarship> GetAllByTrait(string trait)
    {
        return _npcStarshipSelector.GetAllNpcStarships().Where(x => x.Traits.Any(t => t.Equals(trait, StringComparison.OrdinalIgnoreCase))).ToList();
    }
}
