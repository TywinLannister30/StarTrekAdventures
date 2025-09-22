using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface ISpaceframeSelector
{
    Spaceframe ChooseSpaceframe(string specificSpaceframe);

    Spaceframe GetSpaceframe(string name);

    List<Spaceframe> GetAllSpaceframes();
}
