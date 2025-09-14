using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SmallCraftManager : ISmallCraftManager
{
    public List<SmallCraft> GetAll()
    {
        return SmallCraftSelector.GetAllSmallCraft();
    }

    public List<string> GetAllNames()
    {
        return SmallCraftSelector.GetAllSmallCraft().Select(x => x.Name).ToList();
    }

    public SmallCraft Get(string name)
    {
        return SmallCraftSelector.GetSmallCraft(name);
    }

    public List<SmallCraft> GetAllByTrait(string trait)
    {
        return SmallCraftSelector.GetAllSmallCraft().Where(x => x.Traits.Any(t => t.Equals(trait, StringComparison.OrdinalIgnoreCase))).ToList();
    }
}
