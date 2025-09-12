using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class StarshipTalentManager : IStarshipTalentManager
{
    public List<StarshipTalent> GetAll()
    {
        return StarshipTalentSelector.GetAllTalents();
    }

    public List<string> GetAllNames()
    {
        return StarshipTalentSelector.GetAllTalents().Select(x => x.Name).ToList();
    }

    public StarshipTalent Get(string name)
    {
        return StarshipTalentSelector.GetTalent(name);
    }
}
