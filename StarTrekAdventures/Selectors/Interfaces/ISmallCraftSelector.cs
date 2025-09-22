using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ISmallCraftSelector
{
    SmallCraft GetSmallCraft(string name);

    List<SmallCraft> GetAllSmallCraft();
}
