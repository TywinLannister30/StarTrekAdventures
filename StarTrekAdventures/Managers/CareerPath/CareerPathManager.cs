using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class CareerPathManager : ICareerPathManager
{
    private readonly ICareerPathSelector _careerPathSelector;

    public CareerPathManager(ICareerPathSelector careerPathSelector)
    {
        _careerPathSelector = careerPathSelector;
    }

    public List<CareerPath> GetAll()
    {
        return _careerPathSelector.GetAllCareerPaths();
    }

    public List<string> GetAllNames()
    {
        return _careerPathSelector.GetAllCareerPaths().Select(x => x.Name).ToList();
    }

    public CareerPath Get(string name)
    {
        return _careerPathSelector.GetCareerPath(name);
    }
}
