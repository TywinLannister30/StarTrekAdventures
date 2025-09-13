using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class WeaponQuality
{
    public WeaponQuality()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public List<string> Description { get; set; }

    public string Source { get; set; }
}
