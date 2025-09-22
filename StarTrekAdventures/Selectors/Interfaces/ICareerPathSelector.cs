using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ICareerPathSelector
{
    CareerPath ChooseCareerPath(Character character);

    List<CareerPath> GetAllCareerPaths();

    CareerPath GetCareerPath(string name);

    CareerPath GetCareerPath(string name, string major);
}
