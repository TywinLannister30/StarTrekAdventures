using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class TalentManager : ITalentManager
{
    public List<Talent> GetAll()
    {
        return TalentSelector.GetAllTalents();
    }

    public List<string> GetAllNames()
    {
        return TalentSelector.GetAllTalents().Select(x => x.Name).ToList();
    }

    public Talent Get(string name)
    {
        return TalentSelector.GetTalent(name);
    }
}
