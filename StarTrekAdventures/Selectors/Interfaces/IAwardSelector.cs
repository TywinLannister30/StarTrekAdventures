using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IAwardSelector
{
    Award GetAward(string name);

    List<Award> GetAllAwards();
}
