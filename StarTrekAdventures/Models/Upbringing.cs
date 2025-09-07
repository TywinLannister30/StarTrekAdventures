using System.Collections.Generic;

namespace StarTrekAdventures.Models
{
    public class Upbringing
    {
        public string Name { get; set; }

        public CharacterAttributes Attributes { get; set; }

        public CharacterDepartments DepartmentChoices { get; set; }

        public List<string> Focuses { get; set; }

        public bool AnyDepartment { get; set; }
    }
}
