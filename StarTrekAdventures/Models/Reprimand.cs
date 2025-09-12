using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class Reprimand
{
    public string Name { get; set; }

    public string Cost 
    { 
        get
        {
            if (VariableCost) return "Variable";

            return CostNum.ToString();
        }
     }

    [JsonIgnore]
    public int CostNum { get; set; }

    [JsonIgnore]
    public bool VariableCost { get; set; }

    public string Description { get; set; }
}
