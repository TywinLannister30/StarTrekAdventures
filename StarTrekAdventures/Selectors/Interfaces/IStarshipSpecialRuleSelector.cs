using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IStarshipSpecialRuleSelector
{
    StarshipSpecialRule GetSpecialRule(string name);
}
