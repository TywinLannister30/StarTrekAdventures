using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class AwardManager : IAwardManager
{
    private readonly IAwardSelector _awardSelector;
    public AwardManager(IAwardSelector awardSelector)
    {
        _awardSelector = awardSelector;
    }

    public List<Award> GetAll()
    {
        return _awardSelector.GetAllAwards();
    }

    public List<string> GetAllNames()
    {
        return _awardSelector.GetAllAwards().Select(x => x.Name).ToList();
    }

    public Award Get(string name)
    {
        return _awardSelector.GetAward(name);
    }
}
