using System.Collections.Generic;

namespace StarTrekAdventures.Models.Version1
{
    public class Track
    {
        public string Name { get; set; }

        public CharacterDisciplines DisciplineModifiers { get; set; }

        public List<string> Focuses { get; set; }
    }
}
