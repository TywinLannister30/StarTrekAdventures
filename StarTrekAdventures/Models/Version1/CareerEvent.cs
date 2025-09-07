using System.Collections.Generic;

namespace StarTrekAdventures.Models.Version1
{
    public class CareerEvent
    {
        public string Name { get; set; }

        public CharacterAttributes AttributeModifiers { get; set; }

        public CharacterDisciplines DisciplineModifiers { get; set; }

        public List<string> Focuses { get; set; }

        public bool AnyAttribute { get; set; }

        public bool AnyDiscipline{ get; set; }
    }
}
