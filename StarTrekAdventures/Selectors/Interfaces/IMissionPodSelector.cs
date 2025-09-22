using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IMissionPodSelector
{
    MissionPod ChooseMissionPod();
}
