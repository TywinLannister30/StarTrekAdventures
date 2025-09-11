using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ExperienceManager : IExperienceManager
{
    public List<Experience> GetAll()
    {
        return ExperienceSelector.GetAllExperiences();
    }

    public List<string> GetAllNames()
    {
        return ExperienceSelector.GetAllExperiences().Select(x => x.Name).ToList();
    }

    public Experience Get(string name)
    {
        return ExperienceSelector.GetExperience(name);
    }
}
