using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ReprimandManager : IReprimandManager
{
    public List<Reprimand> GetAll()
    {
        return ReprimandSelector.GetAllReprimands();
    }

    public List<string> GetAllNames()
    {
        return ReprimandSelector.GetAllReprimands().Select(x => x.Name).ToList();
    }

    public Reprimand Get(string name)
    {
        return ReprimandSelector.GetReprimand(name);
    }
}
