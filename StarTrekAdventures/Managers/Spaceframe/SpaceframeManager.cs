using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class SpaceframeManager : ISpaceframeManager
{
    private readonly ISpaceframeSelector _spaceframeSelector;

    public SpaceframeManager(ISpaceframeSelector spaceframeSelector)
    {
        _spaceframeSelector = spaceframeSelector;
    }

    public List<Spaceframe> GetAll()
    {
        return _spaceframeSelector.GetAllSpaceframes();
    }

    public List<string> GetAllNames()
    {
        return _spaceframeSelector.GetAllSpaceframes().Select(x => x.Name).ToList();
    }

    public Spaceframe Get(string name)
    {
        return _spaceframeSelector.GetSpaceframe(name);
    }
}
