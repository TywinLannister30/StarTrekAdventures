using System.Collections.Generic;

namespace StarTrekAdventures.Models.Version1
{
    public class Character
    {
        public Character()
        {
            Traits = new List<string>();
            Values = new List<string>();
            Focuses = new List<string>();
            Talents = new List<Talent>();
            CareerEvents = new List<string>();

            Attributes = new CharacterAttributes
            {
                Control = 7,
                Daring = 7,
                Fitness = 7,
                Insight = 7,
                Presence = 7,
                Reason = 7
            };

            Disciplines = new CharacterDisciplines
            {
                Command = 1,
                Conn = 1,
                Engineering = 1,
                Security = 1,
                Science = 1,
                Medicine = 1
            };
        }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Rank { get; set; }
        public string Role { get; set; }

        public string Species { get; set; }
        public string Environment { get; set; }
        public string Upbringing { get; set; }
        public string Track { get; set; }
        public string Career { get; set; }
        public List<string> CareerEvents { get; set; }

        public ICollection<string> Traits { get; set; }

        public ICollection<string> Values { get; set; }

        public CharacterAttributes Attributes { get; set; }

        public CharacterDisciplines Disciplines { get; set; }

        public int Stress { get; set; }

        public int DamageBonus { get; set; }

        public ICollection<string> Focuses { get; set; }

        public ICollection<Talent> Talents { get; set; }

        public ICollection<string> BorgImplants { get; set; }

        public bool IsValid
        {
            get
            {
                var attributeSum = 0;
                attributeSum += Attributes.Control;
                attributeSum += Attributes.Daring;
                attributeSum += Attributes.Fitness;
                attributeSum += Attributes.Insight;
                attributeSum += Attributes.Presence;
                attributeSum += Attributes.Reason;

                if (attributeSum != 56)
                {
                    ValidationIssue = $"Sum of attributes is {attributeSum}. It should be 56.";
                    return false;
                }

                var disciplineSum = 0;
                disciplineSum += Disciplines.Command;
                disciplineSum += Disciplines.Conn;
                disciplineSum += Disciplines.Engineering;
                disciplineSum += Disciplines.Medicine;
                disciplineSum += Disciplines.Science;
                disciplineSum += Disciplines.Security;

                if (disciplineSum != 16)
                {
                    ValidationIssue = $"Sum of disciplines is {disciplineSum}. It should be 16.";
                    return false;
                }

                if (Values.Count != 4)
                {
                    ValidationIssue = $"The character has {Values.Count} values. It should be 4.";
                    return false;
                }

                if (Talents.Count != 4)
                {
                    ValidationIssue = $"The character has {Talents.Count} talents. It should be 4.";
                    return false;
                }

                if (Focuses.Count != 6)
                {
                    ValidationIssue = $"The character has {Focuses.Count} focuses. It should be 6.";
                    return false;
                }

                return true;
            }
        }

        public string ValidationIssue { get; set; }
    }
}
