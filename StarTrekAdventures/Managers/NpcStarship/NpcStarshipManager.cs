using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class NpcStarshipManager : INpcStarshipManager
{
    public List<NpcStarship> GetAll()
    {
        return NpcStarshipSelector.GetAllNpcStarships();
    }

    public List<string> GetAllNames()
    {
        return NpcStarshipSelector.GetAllNpcStarships().Select(x => x.Name).ToList();
    }

    public NpcStarship Get(string name)
    {
        return NpcStarshipSelector.GetNpcStarship(name);
    }

    public List<NpcStarship> GetAllByTrait(string trait)
    {
        return NpcStarshipSelector.GetAllNpcStarships().Where(x => x.Traits.Any(t => t.Equals(trait, StringComparison.OrdinalIgnoreCase))).ToList();
    }
}
