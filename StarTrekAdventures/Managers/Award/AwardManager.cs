using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class AwardManager : IAwardManager
{
    public List<Award> GetAll()
    {
        return AwardSelector.GetAllAwards();
    }

    public List<string> GetAllNames()
    {
        return AwardSelector.GetAllAwards().Select(x => x.Name).ToList();
    }

    public Award Get(string name)
    {
        return AwardSelector.GetAward(name);
    }
}
