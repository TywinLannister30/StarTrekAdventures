using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ICareerPathManager
{
    List<CareerPath> GetAll();

    List<string> GetAllNames();

    CareerPath Get(string name);
}
