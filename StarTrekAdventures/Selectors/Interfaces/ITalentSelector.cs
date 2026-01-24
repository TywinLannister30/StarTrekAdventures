using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ITalentSelector
{
    Talent ChooseTalent(Character character, string traitName = null);

    Talent GetTalent(string name);

    List<Talent> GetAllTalents();

    NpcSpecialRule GetTalentAsSpecialRule(string name);
}
