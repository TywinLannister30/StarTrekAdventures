using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IReprimandSelector
{
    Reprimand GetReprimand(string name);

    List<Reprimand> GetAllReprimands();
}
