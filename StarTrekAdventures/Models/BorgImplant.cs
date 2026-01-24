using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class BorgImplant
{
    public BorgImplant()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public int StressModifier { get; set; }

    public int ProtectionModifier { get; set; }

    public string TraitGained { get; set; }

    public string Source { get; set; }
}
