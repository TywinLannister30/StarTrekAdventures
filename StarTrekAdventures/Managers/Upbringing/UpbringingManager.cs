using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class UpbringingManager : IUpbringingManager
{
    public List<Upbringing> GetAll()
    {
        return UpbringingSelector.GetAllUpbringings();
    }

    public List<string> GetAllNames()
    {
        return UpbringingSelector.GetAllUpbringings().Select(x => x.Name).ToList();
    }

    public Upbringing Get(string name)
    {
        return UpbringingSelector.GetUpbringing(name);
    }
}
