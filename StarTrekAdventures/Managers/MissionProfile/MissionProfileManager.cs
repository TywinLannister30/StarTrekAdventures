using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class MissionProfileManager : IMissionProfileManager
{
    private readonly IMissionProfileSelector _missionProfileSelector;

    public MissionProfileManager(IMissionProfileSelector missionProfileSelector)
    {
        _missionProfileSelector = missionProfileSelector;
    }

    public List<MissionProfile> GetAll()
    {
        return _missionProfileSelector.GetAllMissionProfiles();
    }

    public List<string> GetAllNames()
    {
        return _missionProfileSelector.GetAllMissionProfiles().Select(x => x.Name).ToList();
    }

    public MissionProfile Get(string name)
    {
        return _missionProfileSelector.GetMissionProfile(name);
    }
}
