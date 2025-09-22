using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IStarshipTalentSelector
{
    StarshipTalent ChooseTalent(Starship starship);

    StarshipTalent GetTalent(string name);

    StarshipTalent GetTalentFromList(Starship starship, ICollection<string> talentChoices);

    List<StarshipTalent> GetAllTalents();
}
