
namespace StarTrekAdventures.Models.Version1
{
    public class Environment
    {
        public string Name { get; set; }

        public CharacterAttributes AttributeChoices { get; set; }
        public CharacterDisciplines DisciplineChoices { get; set; }

        public bool SpeciesAttributes { get; set; }
        public bool AnotherSpeciesAttributes { get; set; }
        public bool AnyDiscipline { get; set; }
    }
}
