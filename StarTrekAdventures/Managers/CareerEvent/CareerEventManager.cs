using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class CareerEventManager : ICareerEventManager
{
    public List<CareerEvent> GetAll()
    {
        return CareerEventSelector.GetAllCareerEvents();
    }

    public List<string> GetAllNames()
    {
        return CareerEventSelector.GetAllCareerEvents().Select(x => x.Name).ToList();
    }

    public CareerEvent Get(string name)
    {
        return CareerEventSelector.GetCareerEvent(name);
    }
}
