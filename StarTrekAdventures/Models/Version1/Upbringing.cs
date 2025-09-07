using System.Collections.Generic;

namespace StarTrekAdventures.Models.Version1
{
    public class Upbringing
    {
        public string Name { get; set; }

        public CharacterAttributes Attributes { get; set; }

        public CharacterDisciplines DisciplineChoices { get; set; }

        public List<string> Focuses { get; set; }

        public bool AnyDiscipline { get; set; }
    }
}
