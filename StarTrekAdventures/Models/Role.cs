using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarTrekAdventures.Models
{
    public class Role
    {
        public string Name { get; set; }

        public string Benefit { get; set; }

        [JsonIgnore]
        public int AdditionalValues{ get; set; }

        [JsonIgnore]
        public int AdditionalFocuses { get; set; }

        [JsonIgnore]
        public List<string> AdditionalFocusesChoices { get; set; }
    }
}
