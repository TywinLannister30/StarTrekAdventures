using StarTrekAdventures.Constants;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class SpeciesAbility
{
    public SpeciesAbility()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    [JsonIgnore]
    public string NpcDescription { get; set; }

    [JsonIgnore]
    public string AddTalent { get; set; }

    [JsonIgnore]
    public List<string> AddOneOfTheseTalents {get; set;}

    [JsonIgnore]
    public int AdditionalFocuses { get; set; }

    [JsonIgnore]
    public int ProtectionBonus { get; set; }

    [JsonIgnore]
    public string StressBasedOn { get; set; } = AttributeName.Fitness;

    [JsonIgnore]
    public string TraitGained { get; set; }

    [JsonIgnore]
    public bool HasPastime { get; set; } = true;
    
    [JsonIgnore]
    public bool AddAugmentTalents { get; set; } = false;

    public string Source { get; set; }
}
