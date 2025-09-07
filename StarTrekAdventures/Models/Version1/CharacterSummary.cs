using System.Collections.Generic;

namespace StarTrekAdventures.Models.Version1
{
    public class CharacterSummary
    {
        public string Role { get; set; }
        public string Rank { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Traits { get; set; }
        public ICollection<string> Values { get; set; }
        public CharacterAttributes Attributes { get; set; }
        public CharacterDisciplines Disciplines { get; set; }
        public string Focuses { get; set; }
        public string Talents { get; set; }
        public string BorgImplants { get; set; }
        public int Stress { get; set; }
        public int DamageBonus { get; set; }
        public string Species { get; set; }
        public string Environment { get; set; }
        public string Track { get; set; }
        public string Career { get; set; }
        public string CareerEvents { get; set; }
    }
}
