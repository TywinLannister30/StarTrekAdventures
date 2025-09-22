using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface INpcSpecialRuleSelector
{
    NpcSpecialRule GetSpecialRule(string name);
}
