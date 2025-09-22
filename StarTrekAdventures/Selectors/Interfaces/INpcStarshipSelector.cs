using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface INpcStarshipSelector
{
    NpcStarship GetNpcStarship(string name);

    List<NpcStarship> GetAllNpcStarships();
}
