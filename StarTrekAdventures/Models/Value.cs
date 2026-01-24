using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class Value
{
    public Value()
    {
        Source = BookSource.Core;
        AnyTraitRequirement = new List<string>();
        AllTraitRequirement = new List<string>();
    }

    public string Name { get; set; }

    public string TraitRequirement { get; set; }

    public List<string> AnyTraitRequirement { get; set; }

    public List<string> AllTraitRequirement { get; set; }

    public string TalentRequirement { get; set; }

    public string TrackRequirement { get; set; }

    public string ExperienceRequirement { get; set; }

    public int Weight { get; set; }

    public string Source { get; set; }
}
