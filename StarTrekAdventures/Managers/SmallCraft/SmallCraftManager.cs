using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SmallCraftManager : ISmallCraftManager
{
    private readonly ISmallCraftSelector _smallCraftSelector;

    public SmallCraftManager(ISmallCraftSelector smallCraftSelector)
    {
        _smallCraftSelector = smallCraftSelector;
    }

    public List<SmallCraft> GetAll()
    {
        return _smallCraftSelector.GetAllSmallCraft();
    }

    public List<string> GetAllNames()
    {
        return _smallCraftSelector.GetAllSmallCraft().Select(x => x.Name).ToList();
    }

    public SmallCraft Get(string name)
    {
        return _smallCraftSelector.GetSmallCraft(name);
    }

    public List<SmallCraft> GetAllByTrait(string trait)
    {
        return _smallCraftSelector.GetAllSmallCraft().Where(x => x.Traits.Any(t => t.Equals(trait, StringComparison.OrdinalIgnoreCase))).ToList();
    }
}
