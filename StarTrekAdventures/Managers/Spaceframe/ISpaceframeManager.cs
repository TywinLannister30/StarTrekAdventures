using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ISpaceframeManager
{
    List<Spaceframe> GetAll();

    List<string> GetAllNames();

    Spaceframe Get(string name);
}
