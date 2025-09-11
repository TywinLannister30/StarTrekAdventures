using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class CareerEventSelector
{
    public static List<CareerEvent> ChooseCareerEvents()
    {
        return CareerEvents.OrderBy(n => Util.GetRandom()).Take(2).ToList();
    }

    private static readonly List<CareerEvent> CareerEvents = new List<CareerEvent>
    {
        new()
        {
            Name = "Betrayed Ideals for a Superior",
            AttributeModifierChoices = new CharacterAttributes { Presence = 1 },
            DepartmentModifierChoices = new Departments { Command = 1 },
            Focuses = new List<string> { Focus.Persuasion, Focus.Inspiration, Focus.Investigation }
        },

        new()
        {
            Name = "Breakthrough or Invention",
            AnyAttribute = true,
            DepartmentModifierChoices = new Departments { Engineering = 1 },
            Focuses = new List<string> { Focus.ExperimentalTechnology, Focus.Invention, Focus.Improvisation },
            GainARandomTrait = new List<string> { "Inventor" }
        },

        new()
        {
            Name = "Called Out a Superior",
            AttributeModifierChoices = new CharacterAttributes { Reason = 1 },
            DepartmentModifierChoices = new Departments { Conn = 1 },
            Focuses = new List<string> { Focus.UniformCodeOfJustice, Focus.History, Focus.StarfleetProtocol }
        },

        new()
        {
            Name = "Conflict with a Hostile Culture",
            AttributeModifierChoices = new CharacterAttributes { Fitness = 1 },
            DepartmentModifierChoices = new Departments { Security = 1 },
            Focuses = new List<string> { Focus.HandPhasers, Focus.HandToHandCombat, Focus.TacticalSystems }
        },

        new()
        {
            Name = "Dealt with a Plague",
            AttributeModifierChoices = new CharacterAttributes { Insight = 1 },
            DepartmentModifierChoices = new Departments { Medicine = 1 },
            Focuses = new List<string> { Focus.InfectiousDiseases, Focus.EmergencyMedicine, Focus.Triage }
        },

        new()
        {
            Name = "Death of a Friend",
            AttributeModifierChoices = new CharacterAttributes { Insight = 1 },
            DepartmentModifierChoices = new Departments { Medicine = 1 },
            Focuses = new List<string> { Focus.Councelling }
        },

        new() 
        { 
           Name = "Discovered an Artefact", 
           AttributeModifierChoices = new CharacterAttributes { Reason = 1 },
           DepartmentModifierChoices = new Departments { Engineering = 1 },
           Focuses = new List<string> { Focus.AncientTechnology, Focus.Computers, Focus.ReverseEngineering } 
        },

        new()
        {
           Name = "Encountered a Rogue AI Ancient",
           AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
           DepartmentModifierChoices = new Departments { Command = 1, Science = 1 },
           Focuses = new List<string> { Focus.Computers, Focus.Cybernetics, Focus.Holoprogramming }
        },

        new()
        {
           Name = "Encountered a Spatial Anomoly",
           AttributeModifierChoices = new CharacterAttributes { Daring = 1, Control = 1 },
           DepartmentModifierChoices = new Departments { Conn = 1, Science = 1 },
           Focuses = new List<string> { Focus.AnomalousPhysics, Focus.QuantumMechanics, Focus.SubspaceDynamics }
        },

        new()
        {
           Name = "Encountered a Temporal Anomoly",
           AttributeModifierChoices = new CharacterAttributes { Daring = 1, Control = 1 },
           DepartmentModifierChoices = new Departments { Science = 1, Engineering = 1 },
           Focuses = new List<string> { Focus.Archaeology, Focus.History, Focus.TemporalMechanics },
           GainARandomTrait = new List<string> { "Seen the Future", "Trans-temporal Awareness", "Time-Displaced." }
        },

        new() 
        { 
            Name = "Encountered a Truly Alien Being", 
            AttributeModifierChoices = new CharacterAttributes { Reason = 1 },
            DepartmentModifierChoices = new Departments { Science = 1 },
            Focuses = new List<string> { Focus.Empathy, Focus.Philosophy, Focus.Xenobiology } 
        },

        new()
        {
           Name = "Experienced an Alternate Dimension",
           AttributeModifierChoices = new CharacterAttributes { Reason = 1, Fitness = 1 },
           DepartmentModifierChoices = new Departments { Science = 1, Security = 1 },
           Focuses = new List<string> { Focus.AlternateHistories, Focus.MultiDimensionalPhysics, Focus.SubspaceDynamics },
        },

        new()
        {
           Name = "Fellowship at an Elite Institution",
           AttributeModifierChoices = new CharacterAttributes { Presence = 1, Reason = 1 },
           DepartmentModifierChoices = new Departments { Science = 1, Medicine = 1 },
           Focuses = new List<string> { Focus.ArchaeologicalMedicine, Focus.Cybernetics, Focus.TheoreticalPhysics  },
           GainARandomTrait = new List<string> { "Daystrom Fellow", "Studied at the Vulcan Science Academy" }
        },

        new() 
        { 
            Name = "First Contact", 
            AttributeModifierChoices = new CharacterAttributes { Presence = 1 }, 
            AnyDepartment = true,
            Focuses = new List<string> { Focus.CulturalStudies, Focus.Diplomacy, Focus.Infiltration } 
        },

        new()
        {
            Name = "Lauded by Another Culture",
            AttributeModifierChoices = new CharacterAttributes { Presence = 1 },
            DepartmentModifierChoices = new Departments { Science = 1 }
        },

        new() 
        { 
            Name = "Learned Unique Language", 
            AttributeModifierChoices = new CharacterAttributes { Insight = 1 },
            DepartmentModifierChoices = new Departments { Science = 1 },
            Focuses = new List<string> { Focus.Linguistics, Focus.CulturalStudies, Focus.Negotiation } 
        },

        new() 
        { 
            Name = "Mentored", 
            AnyAttribute = true,
            DepartmentModifierChoices = new Departments { Conn = 1 },
            Focuses = new List<string> { Focus.Composure, Focus.Etiquette } 
        },

        new() 
        { 
            Name = "Negotiate a Treaty", 
            AttributeModifierChoices = new CharacterAttributes { Control = 1 },
            DepartmentModifierChoices = new Departments { Command = 1 },
            Focuses = new List<string> { Focus.Diplomacy, Focus.GalacticPolitics, Focus.Negotiation } 
        },

        new() 
        { 
            Name = "New Battle Strategy", 
            AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
            DepartmentModifierChoices = new Departments { Security = 1 },
            Focuses = new List<string> { Focus.CombatTactics, Focus.HazardAwareness } 
        },

        new() 
        { 
            Name = "Recruited to Starfleet Intelligence", 
            AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
            DepartmentModifierChoices = new Departments { Security = 1 },
            Focuses = new List<string> { Focus.Composure, Focus.Infiltration, Focus.Persuasion } 
        },

        new() 
        { 
            Name = "Required to Take Command", 
            AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
            DepartmentModifierChoices = new Departments { Command = 1 },
            Focuses = new List<string> { Focus.Inspiration, Focus.Composure } 
        },

        new() 
        { 
            Name = "Serious Injury", 
            AttributeModifierChoices = new CharacterAttributes { Fitness = 1 },
            DepartmentModifierChoices = new Departments { Medicine = 1 },
            Focuses = new List<string> { Focus.Athletics, Focus.Art, Focus.Philosophy },
            GainARandomTrait = new List<string> { 
                "Prosthetic Arm", "Prosthetic Arms", "Prosthetic Leg", "Prosthetic Legs",
                "Prosthetic Lung", "Prosthetic Lungs", "Prosthetic Eye", "Prosthetic Eyes", "Prosthetic Heart"}
        },

        new() 
        { 
            Name = "Ship Destroyed", 
            AttributeModifierChoices = new CharacterAttributes { Daring = 1 },
            DepartmentModifierChoices = new Departments { Security = 1 },
            Focuses = new List<string> { Focus.ExtraVehicularActivity, Focus.SmallCraft, Focus.Survival} 
        },

        new() 
        { 
            Name = "Solved an Engineering Crisis", 
            AttributeModifierChoices = new CharacterAttributes { Control = 1 },
            DepartmentModifierChoices = new Departments { Engineering = 1 },
            Focuses = new List<string> { Focus.ElectroPlasmaPowerSystems, Focus.FusionReactors, Focus.WarpEngines } 
        },

        new() 
        { 
            Name = "Special Commendation", 
            AttributeModifierChoices = new CharacterAttributes { Fitness = 1 }, 
            AnyDepartment = true,
            Focuses = new List<string> { Focus.Athletics, Focus.Survival, Focus.EmergencyMedicine } 
        },

        new()
        {
           Name = "Studied Archaeotechnology",
           AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
           DepartmentModifierChoices = new Departments { Engineering = 1, Medicine = 1 },
           Focuses = new List<string> { Focus.Archaeotechnology, Focus.Electronics, Focus.History },
        },

        new()
        {
           Name = "Studied a New Power Source",
           AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
           DepartmentModifierChoices = new Departments { Engineering = 1, Science = 1 },
           Focuses = new List<string> { Focus.EPSPowerSystems, Focus.MatterAntimatterReactors, Focus.PlasmaPhysics },
        },

        new()
        {
           Name = "Technological Catastrophe",
           AttributeModifierChoices = new CharacterAttributes { Daring = 1, Fitness = 1 },
           DepartmentModifierChoices = new Departments { Command = 1, Medicine = 1 },
           Focuses = new List<string> { Focus.DamageControlProcedures, Focus.FirstAid, Focus.NuclearPhysics  },
        },

        new()
        {
           Name = "Tested Transporter Improvements",
           AttributeModifierChoices = new CharacterAttributes { Control = 1, Reason = 1 },
           DepartmentModifierChoices = new Departments { Engineering = 1, Medicine = 1 },
           Focuses = new List<string> { Focus.MolecularSynthesis, Focus.SensorOperations, Focus.TransportersAndReplicators  },
        },

        new() 
        { 
            Name = "Transporter Accident", 
            AttributeModifierChoices = new CharacterAttributes { Control = 1 },
            DepartmentModifierChoices = new Departments { Conn = 1 },
            Focuses = new List<string> { Focus.TransportersAndReplicators, Focus.SmallCraft, Focus.QuantumMechanics } 
        },

        new()
        {
           Name = "Worked on a Transwarp Project",
           AttributeModifierChoices = new CharacterAttributes { Reason = 1, Insight = 1 },
           DepartmentModifierChoices = new Departments { Conn = 1, Engineering = 1 },
           Focuses = new List<string> { Focus.Astromycology, Focus.QuantumMechanics, Focus.SubspaceTheory  },
        }
    };
}
