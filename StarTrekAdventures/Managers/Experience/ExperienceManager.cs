using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ExperienceManager : IExperienceManager
{
    private readonly IExperienceSelector _experienceSelector;

    public ExperienceManager(IExperienceSelector experienceSelector)
    {
        _experienceSelector = experienceSelector;
    }

    public List<Experience> GetAll()
    {
        return _experienceSelector.GetAllExperiences();
    }

    public List<string> GetAllNames()
    {
        return _experienceSelector.GetAllExperiences().Select(x => x.Name).ToList();
    }

    public Experience Get(string name)
    {
        return _experienceSelector.GetExperience(name);
    }
}
