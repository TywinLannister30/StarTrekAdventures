using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface INpcStarshipManager
{
    List<NpcStarship> GetAll();

    List<string> GetAllNames();

    NpcStarship Get(string name);

    List<NpcStarship> GetAllByTrait(string trait);
}
