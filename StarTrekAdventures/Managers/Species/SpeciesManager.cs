using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SpeciesManager : ISpeciesManager
{
    private ISpeciesSelector _speciesSelector { get; set; }

    public SpeciesManager(ISpeciesSelector speciesSelector)
    {
        _speciesSelector = speciesSelector;
    }

    public List<Species> GetAll()
    {
        return _speciesSelector.GetAllSpecies();
    }

    public List<string> GetAllNames()
    {
        return _speciesSelector.GetAllSpecies().Select(x => x.Name).ToList();
    }

    public Species Get(string name)
    {
        return _speciesSelector.GetSpecies(name);
    }

    public SpeciesAbility GetSpeciesAbility(string name)
    {
        return _speciesSelector.GetSpecies(name).SpeciesAbility;
    }
}
