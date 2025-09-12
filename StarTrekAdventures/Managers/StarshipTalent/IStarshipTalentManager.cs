using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IStarshipTalentManager
{
    List<StarshipTalent> GetAll();

    List<string> GetAllNames();

    StarshipTalent Get(string name);
}
