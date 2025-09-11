using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SpeciesManager : ISpeciesManager
{
    public List<Species> GetAll()
    {
        return SpeciesSelector.GetAllSpecies();
    }

    public List<string> GetAllNames()
    {
        return SpeciesSelector.GetAllSpecies().Select(x => x.Name).ToList();
    }

    public Species Get(string name)
    {
        return SpeciesSelector.GetSpecies(name);
    }
}
