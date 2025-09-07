using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors
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
            new CareerEvent
            {
                Name = "Betrayed Ideals for a Superior",
                AttributeModifierChoices = new CharacterAttributes { Presence = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Command = 1 },
                Focuses = new List<string> { Focus.Persuasion, Focus.Inspiration, Focus.Investigation }
            },

            new CareerEvent
            {
                Name = "Breakthrough or Invention",
                AnyAttribute = true,
                DepartmentModifierChoices = new CharacterDepartments { Engineering = 1 },
                Focuses = new List<string> { Focus.ExperimentalTechnology, Focus.Invention, Focus.Improvisation },
                GainARandomTrait = new List<string> { "Inventor" }
            },

            new CareerEvent
            {
                Name = "Called Out a Superior",
                AttributeModifierChoices = new CharacterAttributes { Reason = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Conn = 1 },
                Focuses = new List<string> { Focus.UniformCodeOfJustice, Focus.History, Focus.StarfleetProtocol }
            },

            new CareerEvent
            {
                Name = "Conflict with a Hostile Culture",
                AttributeModifierChoices = new CharacterAttributes { Fitness = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Security = 1 },
                Focuses = new List<string> { Focus.HandPhasers, Focus.HandToHandCombat, Focus.TacticalSystems }
            },

            new CareerEvent
            {
                Name = "Dealt with a Plague",
                AttributeModifierChoices = new CharacterAttributes { Insight = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Medicine = 1 },
                Focuses = new List<string> { Focus.InfectiousDiseases, Focus.EmergencyMedicine, Focus.Triage }
            },

            new CareerEvent
            {
                Name = "Death of a Friend",
                AttributeModifierChoices = new CharacterAttributes { Insight = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Medicine = 1 },
                Focuses = new List<string> { Focus.Councelling }
            },

            new CareerEvent 
            { 
               Name = "Discovered an Artefact", 
               AttributeModifierChoices = new CharacterAttributes { Reason = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Engineering = 1 },
               Focuses = new List<string> { Focus.AncientTechnology, Focus.Computers, Focus.ReverseEngineering } 
            },

            new CareerEvent
            {
               Name = "Encountered a Rogue AI Ancient",
               AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Command = 1, Science = 1 },
               Focuses = new List<string> { Focus.Computers, Focus.Cybernetics, Focus.Holoprogramming }
            },

            new CareerEvent
            {
               Name = "Encountered a Spatial Anomoly",
               AttributeModifierChoices = new CharacterAttributes { Daring = 1, Control = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Conn = 1, Science = 1 },
               Focuses = new List<string> { Focus.AnomalousPhysics, Focus.QuantumMechanics, Focus.SubspaceDynamics }
            },

            new CareerEvent
            {
               Name = "Encountered a Temporal Anomoly",
               AttributeModifierChoices = new CharacterAttributes { Daring = 1, Control = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Science = 1, Engineering = 1 },
               Focuses = new List<string> { Focus.Archaeology, Focus.History, Focus.TemporalMechanics },
               GainARandomTrait = new List<string> { "Seen the Future", "Trans-temporal Awareness", "Time-Displaced." }
            },

            new CareerEvent 
            { 
                Name = "Encountered a Truly Alien Being", 
                AttributeModifierChoices = new CharacterAttributes { Reason = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Science = 1 },
                Focuses = new List<string> { Focus.Empathy, Focus.Philosophy, Focus.Xenobiology } 
            },

            new CareerEvent
            {
               Name = "Experienced an Alternate Dimension",
               AttributeModifierChoices = new CharacterAttributes { Reason = 1, Fitness = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Science = 1, Security = 1 },
               Focuses = new List<string> { Focus.AlternateHistories, Focus.MultiDimensionalPhysics, Focus.SubspaceDynamics },
            },

            new CareerEvent
            {
               Name = "Fellowship at an Elite Institution",
               AttributeModifierChoices = new CharacterAttributes { Presence = 1, Reason = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Science = 1, Medicine = 1 },
               Focuses = new List<string> { Focus.ArchaeologicalMedicine, Focus.Cybernetics, Focus.TheoreticalPhysics  },
               GainARandomTrait = new List<string> { "Daystrom Fellow", "Studied at the Vulcan Science Academy" }
            },

            new CareerEvent 
            { 
                Name = "First Contact", 
                AttributeModifierChoices = new CharacterAttributes { Presence = 1 }, 
                AnyDepartment = true,
                Focuses = new List<string> { Focus.CulturalStudies, Focus.Diplomacy, Focus.Infiltration } 
            },

            new CareerEvent
            {
                Name = "Lauded by Another Culture",
                AttributeModifierChoices = new CharacterAttributes { Presence = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Science = 1 }
            },

            new CareerEvent 
            { 
                Name = "Learned Unique Language", 
                AttributeModifierChoices = new CharacterAttributes { Insight = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Science = 1 },
                Focuses = new List<string> { Focus.Linguistics, Focus.CulturalStudies, Focus.Negotiation } 
            },

            new CareerEvent 
            { 
                Name = "Mentored", 
                AnyAttribute = true,
                DepartmentModifierChoices = new CharacterDepartments { Conn = 1 },
                Focuses = new List<string> { Focus.Composure, Focus.Etiquette } 
            },

            new CareerEvent 
            { 
                Name = "Negotiate a Treaty", 
                AttributeModifierChoices = new CharacterAttributes { Control = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Command = 1 },
                Focuses = new List<string> { Focus.Diplomacy, Focus.GalacticPolitics, Focus.Negotiation } 
            },

            new CareerEvent 
            { 
                Name = "New Battle Strategy", 
                AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Security = 1 },
                Focuses = new List<string> { Focus.CombatTactics, Focus.HazardAwareness } 
            },

            new CareerEvent 
            { 
                Name = "Recruited to Starfleet Intelligence", 
                AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Security = 1 },
                Focuses = new List<string> { Focus.Composure, Focus.Infiltration, Focus.Persuasion } 
            },

            new CareerEvent 
            { 
                Name = "Required to Take Command", 
                AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Command = 1 },
                Focuses = new List<string> { Focus.Inspiration, Focus.Composure } 
            },

            new CareerEvent 
            { 
                Name = "Serious Injury", 
                AttributeModifierChoices = new CharacterAttributes { Fitness = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Medicine = 1 },
                Focuses = new List<string> { Focus.Athletics, Focus.Art, Focus.Philosophy },
                GainARandomTrait = new List<string> { 
                    "Prosthetic Arm", "Prosthetic Arms", "Prosthetic Leg", "Prosthetic Legs",
                    "Prosthetic Lung", "Prosthetic Lungs", "Prosthetic Eye", "Prosthetic Eyes", "Prosthetic Heart"}
            },

            new CareerEvent 
            { 
                Name = "Ship Destroyed", 
                AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Security = 1 },
                Focuses = new List<string> { Focus.ExtraVehicularActivity, Focus.SmallCraft, Focus.Survival} 
            },

            new CareerEvent 
            { 
                Name = "Solved an Engineering Crisis", 
                AttributeModifierChoices = new CharacterAttributes { Control = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Engineering = 1 },
                Focuses = new List<string> { Focus.ElectroPlasmaPowerSystems, Focus.FusionReactors, Focus.WarpEngines } 
            },

            new CareerEvent 
            { 
                Name = "Special Commendation", 
                AttributeModifierChoices = new CharacterAttributes { Fitness = 1 }, 
                AnyDepartment = true,
                Focuses = new List<string> { Focus.Athletics, Focus.Survival, Focus.EmergencyMedicine } 
            },

            new CareerEvent
            {
               Name = "Studied Archaeotechnology",
               AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Engineering = 1, Medicine = 1 },
               Focuses = new List<string> { Focus.Archaeotechnology, Focus.Electronics, Focus.History },
            },

            new CareerEvent
            {
               Name = "Studied a New Power Source",
               AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Engineering = 1, Science = 1 },
               Focuses = new List<string> { Focus.EPSPowerSystems, Focus.MatterAntimatterReactors, Focus.PlasmaPhysics },
            },

            new CareerEvent
            {
               Name = "Technological Catastrophe",
               AttributeModifierChoices = new CharacterAttributes { Daring = 1, Fitness = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Command = 1, Medicine = 1 },
               Focuses = new List<string> { Focus.DamageControlProcedures, Focus.FirstAid, Focus.NuclearPhysics  },
            },

            new CareerEvent
            {
               Name = "Tested Transporter Improvements",
               AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Engineering = 1, Medicine = 1 },
               Focuses = new List<string> { Focus.MolecularSynthesis, Focus.SensorOperations, Focus.TransportersAndReplicators  },
            },

            new CareerEvent 
            { 
                Name = "Transporter Accident", 
                AttributeModifierChoices = new CharacterAttributes { Control = 1 },
                DepartmentModifierChoices = new CharacterDepartments { Conn = 1 },
                Focuses = new List<string> { Focus.TransportersAndReplicators, Focus.SmallCraft, Focus.QuantumMechanics } 
            },

            new CareerEvent
            {
               Name = "Worked on a Transwarp Project",
               AttributeModifierChoices = new CharacterAttributes { Reason = 1, Insight = 1 },
               DepartmentModifierChoices = new CharacterDepartments { Conn = 1, Engineering = 1 },
               Focuses = new List<string> { Focus.Astromycology, Focus.QuantumMechanics, Focus.SubspaceTheory  },
            }
        };
    }
}
