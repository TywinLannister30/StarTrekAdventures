using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IExperienceSelector
{
    Experience ChooseExperience(Character character);

    Experience GetExperience(string name);

    List<Experience> GetAllExperiences();
}
