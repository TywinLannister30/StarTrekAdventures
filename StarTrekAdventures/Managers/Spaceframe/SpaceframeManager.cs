using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SpaceframeManager : ISpaceframeManager
{
    public List<Spaceframe> GetAll()
    {
        return SpaceframeSelector.GetAllSpaceframes();
    }

    public List<string> GetAllNames()
    {
        return SpaceframeSelector.GetAllSpaceframes().Select(x => x.Name).ToList();
    }

    public Spaceframe Get(string name)
    {
        return SpaceframeSelector.GetSpaceframe(name);
    }
}
