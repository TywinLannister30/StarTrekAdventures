using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IStarshipManager
{
    Starship CreateStarship(string spaceframe);
}
