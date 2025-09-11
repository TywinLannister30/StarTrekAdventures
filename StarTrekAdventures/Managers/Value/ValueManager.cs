using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ValueManager : IValueManager
{
    public List<Value> GetAll()
    {
        return ValueSelector.GetAllValues();
    }

    public List<string> GetAllNames()
    {
        return ValueSelector.GetAllValues().Select(x => x.Name).ToList();
    }

    public Value Get(string name)
    {
        return ValueSelector.GetSpecificValue(name);
    }

    public List<Value> GetAllBySpecies(string species)
    {
        return ValueSelector.GetAllValues().Where(x => x.TraitRequirement != null && x.TraitRequirement.Equals(species, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    public List<string> GetAllNamesBySpecies(string species)
    {
        return ValueSelector.GetAllValues().Where(x => x.TraitRequirement != null && x.TraitRequirement.Equals(species, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.Name).ToList();

    }
}
