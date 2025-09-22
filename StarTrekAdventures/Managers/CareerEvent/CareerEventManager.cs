using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class CareerEventManager : ICareerEventManager
{
    private readonly CareerEventSelector _careerEventSelector;

    public CareerEventManager(ICareerEventSelector careerEventSelector)
    {
        _careerEventSelector = (CareerEventSelector)careerEventSelector;
    }

    public List<CareerEvent> GetAll()
    {
        return _careerEventSelector.GetAllCareerEvents();
    }

    public List<string> GetAllNames()
    {
        return _careerEventSelector.GetAllCareerEvents().Select(x => x.Name).ToList();
    }

    public CareerEvent Get(string name)
    {
        return _careerEventSelector.GetCareerEvent(name);
    }
}
