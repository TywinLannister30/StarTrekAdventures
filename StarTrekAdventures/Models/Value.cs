using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class Value
{
    public Value()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string TraitRequirement { get; set; }

    public string TalentRequirement { get; set; }

    public string TrackRequirement { get; set; }

    public string ExperienceRequirement { get; set; }

    public int Weight { get; set; }

    public string Source { get; set; }
}
