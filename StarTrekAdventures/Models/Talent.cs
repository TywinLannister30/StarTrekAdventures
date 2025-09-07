using Newtonsoft.Json;
using System.Collections.Generic;

namespace StarTrekAdventures.Models
{
    public class Talent
    {
        public string Name { get; set; }
        public List<string> Description { get; set; }

        [JsonIgnore]
        public string TraitRequirement { get; set; }

        [JsonIgnore]
        public List<string> AnyTraitRequirement { get; set; }

        [JsonIgnore]
        public string FocusRequirement { get; set; }

        [JsonIgnore]
        public string TalentRequirement { get; set; }

        [JsonIgnore]
        public string MayNotTakeWithRole{ get; set; }

        [JsonIgnore]
        public List<string> AnyRoleRequirement { get; set; }

        [JsonIgnore]
        public List<string> GainRandomFocus { get; set; }

        [JsonIgnore]
        public string GenderRequirement { get; set; }

        [JsonIgnore]
        public bool GMPermission { get; set; }

        [JsonIgnore]
        public string MayNotTakeWithTalent { get; set; }

        [JsonIgnore]
        public DepartmentRequirements DepartmentRequirements { get; set; }

        [JsonIgnore]
        public CharacterAttributes AttributeRequirements { get; set; }

        [JsonIgnore]
        public string TraitGained { get; set; }

        [JsonIgnore]
        public int StressModifier { get; set; }

        [JsonIgnore]
        public int ProtectionModifier { get; set; }

        [JsonIgnore]
        public bool MixedHeritageAllowed { get; set; } = true;

        [JsonIgnore]
        public bool Symbiote { get; set; }

        [JsonIgnore]
        public bool MayBeSelected { get; set; } = true;

        [JsonIgnore]
        public int AdditionalValues { get; set; }

        [JsonIgnore]
        public bool BorgImplants { get; set; }

        [JsonIgnore]
        public string AddDepartmentToStress { get; set; }

        [JsonIgnore]
        public bool ExtraRole { get; set; }

        [JsonIgnore]
        public bool ChooseFocus { get; set; }

        [JsonIgnore]
        public int Weight { get; set; }
    }
}
