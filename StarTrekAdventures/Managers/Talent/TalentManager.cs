using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class TalentManager : ITalentManager
{
    private ITalentSelector _talentSelector { get; }

    public TalentManager(ITalentSelector talentSelector)
    {
        _talentSelector = talentSelector;
    }

    public List<Talent> GetAll()
    {
        return _talentSelector.GetAllTalents();
    }

    public List<string> GetAllNames()
    {
        return _talentSelector.GetAllTalents().Select(x => x.Name).ToList();
    }

    public Talent Get(string name)
    {
        return _talentSelector.GetTalent(name);
    }
}
