
namespace StarTrekAdventures.Models
{
    public class Environment
    {
        public string Name { get; set; }

        public CharacterAttributes AttributeChoices { get; set; }
        public CharacterDepartments DepartmentChoices { get; set; }

        public bool SpeciesAttributes { get; set; }
        public bool AnotherSpeciesAttributes { get; set; }
        public bool AnyDepartment { get; set; }
    }
}
