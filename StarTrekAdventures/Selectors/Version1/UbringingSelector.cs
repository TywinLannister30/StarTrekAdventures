using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
{
    public class UbringingSelector
    {
        public static Upbringing ChooseUpringing()
        {
            return Upringings.OrderBy(n => Util.GetRandom()).First();
        }

        public static Upbringing GetUpringing(string name)
        {
            return Upringings.First(x => x.Name == name);
        }

        private static readonly List<Upbringing> Upringings = new List<Upbringing>
        {
            new Upbringing {
                Name = "Starfleet (Accepted)",
                Attributes = new CharacterAttributes { Control = 2, Fitness = 1 },
                AnyDiscipline = true,
                Focuses = new List<string> { Focus.Astronavigation, Focus.Composure, Focus.ExtraVehicularActivity, Focus.HandPhasers, Focus.HandToHandCombat, Focus.History, Focus.SmallCraft, Focus.StarfleetProtocol, Focus.StarshipRecognition } },

            new Upbringing {
                Name = "Starfleet (Rebelled)",
                Attributes = new CharacterAttributes { Daring = 2, Insight = 1 },
                AnyDiscipline = true,
                Focuses = new List<string> { Focus.Astronavigation, Focus.Composure, Focus.ExtraVehicularActivity, Focus.HandPhasers, Focus.HandToHandCombat, Focus.History, Focus.SmallCraft, Focus.StarfleetProtocol, Focus.StarshipRecognition } },

            new Upbringing {
                Name = "Business or Trade (Accepted)",
                Attributes = new CharacterAttributes { Presence = 2, Daring = 1 },
                DisciplineChoices = new CharacterDisciplines { Command = 1, Engineering = 1, Science = 1 },
                Focuses = new List<string> { Focus.Finances, Focus.Geology, Focus.Linguistics, Focus.Manufacturing, Focus.Metallurgy, Focus.Negotiation, Focus.Survey } },

            new Upbringing {
                Name = "Business or Trade (Rebelled)",
                Attributes = new CharacterAttributes { Insight = 2, Reason = 1 },
                DisciplineChoices = new CharacterDisciplines { Command = 1, Engineering = 1, Science = 1 },
                Focuses = new List<string> { Focus.Finances, Focus.Geology, Focus.Linguistics, Focus.Manufacturing, Focus.Metallurgy, Focus.Negotiation, Focus.Survey } },

            new Upbringing {
                Name = "Agriculture or Rural (Accepted)",
                Attributes = new CharacterAttributes { Fitness = 2, Control = 1 },
                DisciplineChoices = new CharacterDisciplines { Conn = 1, Security = 1, Medicine = 1 },
                Focuses = new List<string> { Focus.AnimalHandling, Focus.Athletics, Focus.EmergencyMedicine, Focus.Endurance, Focus.GroundVehicles, Focus.InfectiousDiseases, Focus.Navigation, Focus.Toxicology } },

            new Upbringing {
                Name = "Agriculture or Rural (Rebelled)",
                Attributes = new CharacterAttributes { Reason = 2, Presence = 1 },
                DisciplineChoices = new CharacterDisciplines { Conn = 1, Security = 1, Medicine = 1 },
                Focuses = new List<string> { Focus.AnimalHandling, Focus.Athletics, Focus.EmergencyMedicine, Focus.Endurance, Focus.GroundVehicles, Focus.InfectiousDiseases, Focus.Navigation, Focus.Toxicology } },

            new Upbringing {
                Name = "Science and Technology (Accepted)",
                Attributes = new CharacterAttributes { Control = 2, Reason = 1 },
                DisciplineChoices = new CharacterDisciplines { Conn = 1, Engineering = 1, Science = 1, Medicine = 1 },
                Focuses = new List<string> { Focus.Astrophysics, Focus.Astronavigation, Focus.Computers, Focus.Cybernetics, Focus.Genetics, Focus.Physics, Focus.PowerSystems, Focus.QuantumMechanics, Focus.SubspaceCommunications, Focus.Surgery, Focus.WarpFieldDynamics, Focus.BiologyOrXenobiology } },

            new Upbringing {
                Name = "Science and Technology (Rebelled)",
                Attributes = new CharacterAttributes { Insight = 2, Daring = 1 },
                DisciplineChoices = new CharacterDisciplines { Conn = 1, Engineering = 1, Science = 1, Medicine = 1 },
                Focuses = new List<string> { Focus.Astrophysics, Focus.Astronavigation, Focus.Computers, Focus.Cybernetics, Focus.Genetics, Focus.Physics, Focus.PowerSystems, Focus.QuantumMechanics, Focus.SubspaceCommunications, Focus.Surgery, Focus.WarpFieldDynamics, Focus.BiologyOrXenobiology } },

            new Upbringing {
                Name = "Artistic and Creative (Accepted)",
                Attributes = new CharacterAttributes { Presence = 2, Insight = 1 },
                DisciplineChoices = new CharacterDisciplines { Command = 1, Engineering = 1, Science = 1 },
                Focuses = new List<string> { Focus.BotanyOrXenobotany, Focus.CulturalStudies, Focus.Holoprogramming, Focus.Linguistics, Focus.Music, Focus.Observation, Focus.Persuasion, Focus.Psychology } },

            new Upbringing {
                Name = "Artistic and Creative (Rebelled)",
                Attributes = new CharacterAttributes { Fitness = 2, Daring = 1 },
                DisciplineChoices = new CharacterDisciplines { Command = 1, Engineering = 1, Science = 1 },
                Focuses = new List<string> { Focus.BotanyOrXenobotany, Focus.CulturalStudies, Focus.Holoprogramming, Focus.Linguistics, Focus.Music, Focus.Observation, Focus.Persuasion, Focus.Psychology } },

            new Upbringing {
                Name = "Diplomacy and Politics (Accepted)",
                Attributes = new CharacterAttributes { Presence = 2, Control = 1 },
                DisciplineChoices = new CharacterDisciplines { Command = 1, Conn = 1, Security = 1 },
                Focuses = new List<string> { Focus.Composure, Focus.Debate, Focus.Diplomacy, Focus.Espionage, Focus.Interrogation, Focus.Law, Focus.Philosophy, Focus.StarfleetProtocol } },

            new Upbringing {
                Name = "Diplomacy and Politics (Rebelled)",
                Attributes = new CharacterAttributes { Reason = 2, Fitness = 1 },
                DisciplineChoices = new CharacterDisciplines { Command = 1, Conn = 1, Security = 1 },
                Focuses = new List<string> { Focus.Composure, Focus.Debate, Focus.Diplomacy, Focus.Espionage, Focus.Interrogation, Focus.Law, Focus.Philosophy, Focus.StarfleetProtocol } },
        };
    }
}
