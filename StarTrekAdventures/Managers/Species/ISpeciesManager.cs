using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ISpeciesManager
{
    List<Species> GetAll();

    List<string> GetAllNames();

    Species Get(string name);

    SpeciesAbility GetSpeciesAbility(string name);
}
