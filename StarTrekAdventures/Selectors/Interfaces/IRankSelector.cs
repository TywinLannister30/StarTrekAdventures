using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IRankSelector
{
    string ChooseRank(Character character);
}
