using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IMissionProfileManager
{
    List<MissionProfile> GetAll();

    List<string> GetAllNames();

    MissionProfile Get(string name);
}
