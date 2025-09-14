using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ISmallCraftManager
{
    List<SmallCraft> GetAll();

    List<string> GetAllNames();

    SmallCraft Get(string name);

    List<SmallCraft> GetAllByTrait(string trait);
}
