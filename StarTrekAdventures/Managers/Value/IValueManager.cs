using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IValueManager
{
    List<Value> GetAll();

    List<string> GetAllNames();

    Value Get(string name);

    List<Value> GetAllBySpecies(string species);

    List<string> GetAllNamesBySpecies(string species);
}
