using System.Collections.Generic;

namespace StarTrekAdventures.Models
{
    public class CareerEvent
    {
        public string Name { get; set; }

        public CharacterAttributes AttributeModifierChoices { get; set; }

        public CharacterDepartments DepartmentModifierChoices { get; set; }

        public List<string> Focuses { get; set; }

        public bool AnyAttribute { get; set; }

        public bool AnyDepartment { get; set; }

        public List<string> GainARandomTrait { get; set; } 
    }
}
