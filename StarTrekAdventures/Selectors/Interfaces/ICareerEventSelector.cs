using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ICareerEventSelector
{
    List<CareerEvent> ChooseCareerEvents();

    List<CareerEvent> GetAllCareerEvents();

    CareerEvent GetCareerEvent(string name);
}
