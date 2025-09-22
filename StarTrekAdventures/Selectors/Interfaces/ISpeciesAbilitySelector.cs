using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ISpeciesAbilitySelector
{
    SpeciesAbility GetSpeciesAbility(string name);

    List<SpeciesAbility> GetAllSpeciesAbilities();

    NpcSpecialRule GetSpeciesAbilityAsSpecialRule(string abilityName);
}
