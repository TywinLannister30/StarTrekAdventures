using StarTrekAdventures.Constants;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class StarshipSpecialRule
{
    public StarshipSpecialRule() 
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public List<string> Description { get; set; }

    [JsonIgnore]
    public bool StructureOnlyForShields { get; set; }

    [JsonIgnore]
    public bool NoSmallCraftCapacity { get; set; }

    [JsonIgnore]
    public int SmallCraftReadinessModifier { get; set; }

    [JsonIgnore]
    public int CrewSupportModifier { get; set; }

    [JsonIgnore]
    public bool DoubleCrewSupport { get; set; }

    [JsonIgnore]
    public string MustTakeMissionProfile { get; set; }

    [JsonIgnore]
    public bool ChooseMissionPod { get; set; }

    [JsonIgnore]
    public bool MajorRefit { get; set; }

    [JsonIgnore]
    public int ExtraRefits { get; set; }

    public string Source { get; set; }
}
