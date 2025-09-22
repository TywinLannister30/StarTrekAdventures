using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class StarshipTalentManager : IStarshipTalentManager
{
    private readonly IStarshipTalentSelector _starshipTalentSelector;

    public StarshipTalentManager(IStarshipTalentSelector starshipTalentSelector)
    {
        _starshipTalentSelector = starshipTalentSelector;
    }

    public List<StarshipTalent> GetAll()
    {
        return _starshipTalentSelector.GetAllTalents();
    }

    public List<string> GetAllNames()
    {
        return _starshipTalentSelector.GetAllTalents().Select(x => x.Name).ToList();
    }

    public StarshipTalent Get(string name)
    {
        return _starshipTalentSelector.GetTalent(name);
    }
}
