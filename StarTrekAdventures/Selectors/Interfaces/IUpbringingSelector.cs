using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IUpbringingSelector
{
    Upbringing ChooseUpbringing(Character character);

    Upbringing GetUpbringing(string name);

    List<Upbringing> GetAllUpbringings();
}
