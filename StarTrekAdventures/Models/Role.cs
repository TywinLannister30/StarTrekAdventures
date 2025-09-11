using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class Role
{
    public string Name { get; set; }

    public string Benefit { get; set; }

    [JsonIgnore]
    public int AdditionalValues{ get; set; }

    [JsonIgnore]
    public int AdditionalFocuses { get; set; }

    [JsonIgnore]
    public ICollection<string> AdditionalFocusesChoices { get; set; }
}
