using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IReprimandManager
{
    List<Reprimand> GetAll();

    List<string> GetAllNames();

    Reprimand Get(string name);
}
