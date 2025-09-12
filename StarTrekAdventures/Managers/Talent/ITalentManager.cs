using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ITalentManager
{
    List<Talent> GetAll();

    List<string> GetAllNames();

    Talent Get(string name);
}
