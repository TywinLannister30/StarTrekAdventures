using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ITalentSelector
{
    Talent ChooseTalent(Character character);

    public Talent GetTalent(string name);

    public List<Talent> GetAllTalents();

    public NpcSpecialRule GetTalentAsSpecialRule(string name);
}
