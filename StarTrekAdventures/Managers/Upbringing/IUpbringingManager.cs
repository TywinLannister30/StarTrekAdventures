using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IUpbringingManager
{
    List<Upbringing> GetAll();

    List<string> GetAllNames();

    Upbringing Get(string name);
}
