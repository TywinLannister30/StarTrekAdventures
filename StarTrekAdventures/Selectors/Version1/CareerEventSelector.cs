using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class CareerEventSelector
    {
        public static List<CareerEvent> ChooseCareerEvents()
        {
            return CareerEvents.OrderBy(n => Util.GetRandom()).Take(2).ToList();
        }

        public static CareerEvent GetCareerEvent(string name)
        {
            return CareerEvents.First(x => x.Name == name);
        }

        private static readonly List<CareerEvent> CareerEvents = new List<CareerEvent>
        {
            new CareerEvent { Name = "Ship Destroyed", AttributeModifiers = new CharacterAttributes { Daring = 1 }, DisciplineModifiers = new CharacterDisciplines { Security = 1 },
                Focuses = new List<string> { Focus.ExtraVehicularActivity, Focus.SmallCraft, Focus.Survival} },

            new CareerEvent { Name = "Death of a Friend", AttributeModifiers = new CharacterAttributes { Insight = 1 }, DisciplineModifiers = new CharacterDisciplines { Medicine = 1 },
                Focuses = new List<string> { Focus.Councelling } },

            new CareerEvent { Name = "Lauded by Another Culture", AttributeModifiers = new CharacterAttributes { Presence = 1 }, DisciplineModifiers = new CharacterDisciplines { Science = 1 } },

            new CareerEvent { Name = "Negotiate a Treaty", AttributeModifiers = new CharacterAttributes { Control = 1 }, DisciplineModifiers = new CharacterDisciplines { Command = 1 },
                Focuses = new List<string> { Focus.Diplomacy, Focus.GalacticPolitics, Focus.Negotiation } },

            new CareerEvent { Name = "Required to Command", AttributeModifiers = new CharacterAttributes { Daring = 1 }, DisciplineModifiers = new CharacterDisciplines { Command = 1 },
                Focuses = new List<string> { Focus.LeadByExample, Focus.Inspiration, Focus.Composure } },

            new CareerEvent { Name = "Encounter with a Truly Alien Being", AttributeModifiers = new CharacterAttributes { Reason = 1 }, DisciplineModifiers = new CharacterDisciplines { Science = 1 },
                Focuses = new List<string> { Focus.Empathy, Focus.Philosophy, Focus.BiologyOrXenobiology } },

            new CareerEvent { Name = "Serious Injury", AttributeModifiers = new CharacterAttributes { Fitness = 1 }, DisciplineModifiers = new CharacterDisciplines { Medicine = 1 },
                Focuses = new List<string> { Focus.Athletics, Focus.Art, Focus.Philosophy } },

            new CareerEvent { Name = "Conflict with a Hostile Culture", AttributeModifiers = new CharacterAttributes { Fitness = 1 }, DisciplineModifiers = new CharacterDisciplines { Security = 1 },
                Focuses = new List<string> { Focus.HandPhasers, Focus.HandToHandCombat, Focus.ShipboardTacticalSystems } },

            new CareerEvent { Name = "Mentored", AnyAttribute = true, DisciplineModifiers = new CharacterDisciplines { Conn = 1 },
                Focuses = new List<string> { Focus.Composure, Focus.Etiquette } },

            new CareerEvent { Name = "Transporter Accident", AttributeModifiers = new CharacterAttributes { Control = 1 }, DisciplineModifiers = new CharacterDisciplines { Conn = 1 },
                Focuses = new List<string> { Focus.TransportersAndReplicators, Focus.SmallCraft, Focus.QuantumMechanics } },

            new CareerEvent { Name = "Dealing with a Plague", AttributeModifiers = new CharacterAttributes { Insight = 1 }, DisciplineModifiers = new CharacterDisciplines { Medicine = 1 },
                Focuses = new List<string> { Focus.InfectiousDiseases, Focus.EmergencyMedicine, Focus.Triage } },

            new CareerEvent { Name = "Betrayed Ideals for a Superior", AttributeModifiers = new CharacterAttributes { Presence = 1 }, DisciplineModifiers = new CharacterDisciplines { Command = 1 },
                Focuses = new List<string> { Focus.Persuasion, Focus.Inspiration, Focus.Investigation } },

            new CareerEvent { Name = "Called Out a Superior", AttributeModifiers = new CharacterAttributes { Reason = 1 }, DisciplineModifiers = new CharacterDisciplines { Conn = 1 },
                Focuses = new List<string> { Focus.UniformCodeOfJustice, Focus.History, Focus.StarfleetProtocol } },

            new CareerEvent { Name = "New Battle Strategy", AttributeModifiers = new CharacterAttributes { Daring = 1 }, DisciplineModifiers = new CharacterDisciplines { Security = 1 },
                Focuses = new List<string> { Focus.CombatTactics, Focus.HazardAwareness, Focus.LeadByExample } },

            new CareerEvent { Name = "Learns Unique Language", AttributeModifiers = new CharacterAttributes { Insight = 1 }, DisciplineModifiers = new CharacterDisciplines { Science = 1 },
                Focuses = new List<string> { Focus.Linguistics, Focus.CulturalStudies, Focus.Negotiation } },

            new CareerEvent { Name = "Discovers an Artefact", AttributeModifiers = new CharacterAttributes { Reason = 1 }, DisciplineModifiers = new CharacterDisciplines { Engineering = 1 },
                Focuses = new List<string> { Focus.AncientTechnology, Focus.Computers, Focus.ReverseEngineering } },

            new CareerEvent { Name = "Special Commendation", AttributeModifiers = new CharacterAttributes { Fitness = 1 }, AnyDiscipline = true,
                Focuses = new List<string> { Focus.Athletics, Focus.Survival, Focus.EmergencyMedicine } },

            new CareerEvent { Name = "Solved an Engineering Crisis", AttributeModifiers = new CharacterAttributes { Control = 1 }, DisciplineModifiers = new CharacterDisciplines { Engineering = 1 },
                Focuses = new List<string> { Focus.ElectroPlasmaPowerSystems, Focus.FusionReactors, Focus.WarpEngines } },

            new CareerEvent { Name = "Breakthrough or Invention", AnyAttribute = true, DisciplineModifiers = new CharacterDisciplines { Engineering = 1 },
                Focuses = new List<string> { Focus.ExperimentalTechnology, Focus.Invention, Focus.Improvisation } },

            new CareerEvent { Name = "First Contact", AttributeModifiers = new CharacterAttributes { Presence = 1 }, AnyDiscipline = true,
                Focuses = new List<string> { Focus.CulturalStudies, Focus.Diplomacy, Focus.Infiltration } },

            new CareerEvent { Name = "Recruited to Starfleet Intelligence", AttributeModifiers = new CharacterAttributes { Daring = 1 }, DisciplineModifiers = new CharacterDisciplines { Security = 1 },
                Focuses = new List<string> { Focus.Composure, Focus.Infiltration, Focus.Persuasion } },
        };
    }
}
