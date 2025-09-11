using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ICareerEventManager
{
    List<CareerEvent> GetAll();

    List<string> GetAllNames();

    CareerEvent Get(string name);
}
