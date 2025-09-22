using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IUpbringingSelector
{
    Upbringing ChooseUpbringing();

    Upbringing GetUpbringing(string name);

    List<Upbringing> GetAllUpbringings();
}
