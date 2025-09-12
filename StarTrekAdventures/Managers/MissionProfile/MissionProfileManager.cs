using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class MissionProfileManager : IMissionProfileManager
{
    public List<MissionProfile> GetAll()
    {
        return MissionProfileSelector.GetAllMissionProfiles();
    }

    public List<string> GetAllNames()
    {
        return MissionProfileSelector.GetAllMissionProfiles().Select(x => x.Name).ToList();
    }

    public MissionProfile Get(string name)
    {
        return MissionProfileSelector.GetMissionProfile(name);
    }
}
