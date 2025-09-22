using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class UpbringingManager : IUpbringingManager
{
    private readonly IUpbringingSelector _upbringingSelector;

    public UpbringingManager(IUpbringingSelector upbringingSelector)
    {
        _upbringingSelector = upbringingSelector;
    }

    public List<Upbringing> GetAll()
    {
        return _upbringingSelector.GetAllUpbringings();
    }

    public List<string> GetAllNames()
    {
        return _upbringingSelector.GetAllUpbringings().Select(x => x.Name).ToList();
    }

    public Upbringing Get(string name)
    {
        return _upbringingSelector.GetUpbringing(name);
    }
}
