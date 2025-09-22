using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IMissionProfileSelector
{
    MissionProfile ChooseMissionProfile(Starship starship);

    List<MissionProfile> GetAllMissionProfiles();

    MissionProfile GetMissionProfile(string name);
}
