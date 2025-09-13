using StarTrekAdventures.Constants;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class Role
{
    public Role() 
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Benefit { get; set; }

    [JsonIgnore]
    public int AdditionalValues{ get; set; }

    [JsonIgnore]
    public int AdditionalFocuses { get; set; }

    [JsonIgnore]
    public ICollection<string> AdditionalFocusesChoices { get; set; }

    public string Source { get; set; }
}
