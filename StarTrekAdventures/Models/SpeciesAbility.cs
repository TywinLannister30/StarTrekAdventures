using StarTrekAdventures.Constants;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class SpeciesAbility
{
    public string Name { get; set; }

    public string Description { get; set; }
    
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
}
