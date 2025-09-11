using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SpeciesManager : ISpeciesManager
{
    public List<Species> GetAllSpecies()
    {
        return SpeciesSelector.GetAllSpecies();
    }

    public List<string> GetAllSpeciesNames()
    {
        return SpeciesSelector.GetAllSpecies().Select(speciesModel => speciesModel.Name).ToList();
    }

    public Species GetSpecies(string name)
    {
        return SpeciesSelector.GetSpecies(name);
    }
}
