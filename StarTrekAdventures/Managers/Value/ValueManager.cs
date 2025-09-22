using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ValueManager : IValueManager
{
    private readonly IValueSelector _valueSelector;

    public ValueManager(IValueSelector valueSelector)
    {
        _valueSelector = valueSelector;
    }

    public List<Value> GetAll()
    {
        return _valueSelector.GetAllValues();
    }

    public List<string> GetAllNames()
    {
        return _valueSelector.GetAllValues().Select(x => x.Name).ToList();
    }

    public Value Get(string name)
    {
        return _valueSelector.GetSpecificValue(name);
    }

    public List<Value> GetAllBySpecies(string species)
    {
        return _valueSelector.GetAllValues().Where(x => x.TraitRequirement != null && x.TraitRequirement.Equals(species, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }

    public List<string> GetAllNamesBySpecies(string species)
    {
        return _valueSelector.GetAllValues().Where(x => x.TraitRequirement != null && x.TraitRequirement.Equals(species, StringComparison.CurrentCultureIgnoreCase)).Select(x => x.Name).ToList();
    }
}
