using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IAwardManager
{
    List<Award> GetAll();

    List<string> GetAllNames();

    Award Get(string name);
}
