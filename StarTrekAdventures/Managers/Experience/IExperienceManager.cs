using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IExperienceManager
{
    List<Experience> GetAll();

    List<string> GetAllNames();

    Experience Get(string name);
}
