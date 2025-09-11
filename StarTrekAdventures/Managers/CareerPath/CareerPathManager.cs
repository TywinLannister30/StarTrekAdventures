using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class CareerPathManager : ICareerPathManager
{
    public List<CareerPath> GetAll()
    {
        return CareerPathSelector.GetAllCareerPaths();
    }

    public List<string> GetAllNames()
    {
        return CareerPathSelector.GetAllCareerPaths().Select(x => x.Name).ToList();
    }

    public CareerPath Get(string name)
    {
        return CareerPathSelector.GetCareerPath(name);
    }
}
