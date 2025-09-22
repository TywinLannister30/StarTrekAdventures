using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ISpeciesSelector
{
    List<Species> ChooseSpecies(string specificSpecies);

    Species GetSpecies(string name);

    Species GetAnotherRandomSpecies(string name);

    List<Species> GetAllSpecies();
}
