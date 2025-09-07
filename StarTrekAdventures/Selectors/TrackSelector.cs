using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors
{
    public static class TrackSelector
    {
        private const int MaxDispline = 4;

        public static Track ChooseTrack(Character character)
        {
            var availableTracks = new WeightedList<Track>();

            foreach (var track in Tracks)
            {
                if (track.DepartmentModifiers.Command + character.Departments.Command <= MaxDispline &&
                    track.DepartmentModifiers.Conn + character.Departments.Conn <= MaxDispline &&
                    track.DepartmentModifiers.Engineering + character.Departments.Engineering <= MaxDispline &&
                    track.DepartmentModifiers.Medicine + character.Departments.Medicine <= MaxDispline &&
                    track.DepartmentModifiers.Science + character.Departments.Science <= MaxDispline &&
                    track.DepartmentModifiers.Security + character.Departments.Security <= MaxDispline)
                    availableTracks.AddEntry(track, track.Weight);
            }

            return availableTracks.GetRandom();
        }

        private static readonly List<Track> Tracks = new List<Track>
        {
            new Track {
                Name = TrackName.StarfleetOfficerCommand,
                Major = DepartmentName.Command,
                Trait = "Starfleet Officer",
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                Focuses = new List<string> { Focus.Astronavigation, Focus.Composure, Focus.Diplomacy, Focus.ExtraVehicularActivity, Focus.EvasiveAction, Focus.HelmOperations, Focus.Inspiration, Focus.Persuasion, Focus.SmallCraft, Focus.StarshipRecognition, Focus.StarfleetProtocol, Focus.TeamDynamics },
                Weight = 10
            },

            new Track {
                Name = TrackName.StarfleetOfficerCommand,
                Major = DepartmentName.Conn,
                Trait = "Starfleet Officer",
                DepartmentModifiers = new CharacterDepartments { Conn = 2 },
                Focuses = new List<string> { Focus.Astronavigation, Focus.Composure, Focus.Diplomacy, Focus.ExtraVehicularActivity, Focus.EvasiveAction, Focus.HelmOperations, Focus.Inspiration, Focus.Persuasion, Focus.SmallCraft, Focus.StarshipRecognition, Focus.StarfleetProtocol, Focus.TeamDynamics },
                Weight = 10 },

            new Track {
                Name = TrackName.StarfleetOfficerOperations,
                Major = DepartmentName.Engineering,
                Trait = "Starfleet Officer",
                DepartmentModifiers = new CharacterDepartments { Engineering = 2 },
                Focuses = new List<string> { Focus.Computers, Focus.Cybernetics, Focus.ElectroPlasmaPowerSystems, Focus.Espionage, Focus.HandPhasers, Focus.HandToHandCombat, Focus.Infiltration, Focus.Interrogation, Focus.ShipboardTacticalSystems, Focus.Survival, Focus.TransportersAndReplicators, Focus.WarpFieldDynamics },
                Weight = 10 },

            new Track {
                Name = TrackName.StarfleetOfficerOperations,
                Major = DepartmentName.Security,
                Trait = "Starfleet Officer",
                DepartmentModifiers = new CharacterDepartments { Security = 2 },
                Focuses = new List<string> { Focus.Computers, Focus.Cybernetics, Focus.ElectroPlasmaPowerSystems, Focus.Espionage, Focus.HandPhasers, Focus.HandToHandCombat, Focus.Infiltration, Focus.Interrogation, Focus.ShipboardTacticalSystems, Focus.Survival, Focus.TransportersAndReplicators, Focus.WarpFieldDynamics },
                Weight = 10 },

            new Track {
                Name = TrackName.StarfleetOfficerSciences,
                Major = DepartmentName.Medicine,
                Trait = "Starfleet Officer",
                RandomTrait = new List<string> { "Physician", "Psychiatrist" },
                DepartmentModifiers = new CharacterDepartments { Medicine = 2 },
                Focuses = new List<string> { Focus.Anthropology, Focus.Astrophysics, Focus.Botany, Focus.Computers, Focus.Cybernetics, Focus.EmergencyMedicine, Focus.ExoTectonics, Focus.Genetics, Focus.Geology, Focus.InfectiousDiseases, Focus.Linguistics, Focus.Physics, Focus.Psychiatry, Focus.QuantumMechanics, Focus.TraumaSurgery, Focus.Virology, Focus.WarpFieldDynamics, Focus.Xenobiology },
                Weight = 10 },

            new Track {
                Name = TrackName.StarfleetOfficerSciences,
                Major = DepartmentName.Science,
                Trait = "Starfleet Officer",
                DepartmentModifiers = new CharacterDepartments { Science = 2 },
                Focuses = new List<string> { Focus.Anthropology, Focus.Astrophysics, Focus.Botany, Focus.Computers, Focus.Cybernetics, Focus.EmergencyMedicine, Focus.ExoTectonics, Focus.Genetics, Focus.Geology, Focus.InfectiousDiseases, Focus.Linguistics, Focus.Physics, Focus.Psychiatry, Focus.QuantumMechanics, Focus.TraumaSurgery, Focus.Virology, Focus.WarpFieldDynamics, Focus.Xenobiology },
                Weight = 10 },

            new Track {
                Name = TrackName.StarfleetEnlisted,
                Major = DepartmentName.Conn,
                DepartmentModifiers = new CharacterDepartments { Conn = 2 },
                Trait = "Starfleet Crew",
                Focuses = new List<string> { Focus.Computers, Focus.ElectroPlasmaPowerSystems, Focus.EmergencyMedicine, Focus.EVA, Focus.HandPhasers, Focus.HandToHandCombat, Focus.HelmOperations, Focus.ShipboardTacticalSystems, Focus.SmallCraft, Focus.Survival, Focus.TransportersAndReplicators },
                Weight = 5 },

            new Track {
                Name = TrackName.StarfleetEnlisted,
                Major = DepartmentName.Security,
                DepartmentModifiers = new CharacterDepartments { Security = 2 },
                Trait = "Starfleet Crew",
                Focuses = new List<string> { Focus.Computers, Focus.ElectroPlasmaPowerSystems, Focus.EmergencyMedicine, Focus.EVA, Focus.HandPhasers, Focus.HandToHandCombat, Focus.HelmOperations, Focus.ShipboardTacticalSystems, Focus.SmallCraft, Focus.Survival, Focus.TransportersAndReplicators },
                Weight = 5 },

            new Track {
                Name = TrackName.StarfleetEnlisted,
                Major = DepartmentName.Engineering,
                DepartmentModifiers = new CharacterDepartments { Engineering = 2 },
                Trait = "Starfleet Crew",
                Focuses = new List<string> { Focus.Computers, Focus.ElectroPlasmaPowerSystems, Focus.EmergencyMedicine, Focus.EVA, Focus.HandPhasers, Focus.HandToHandCombat, Focus.HelmOperations, Focus.ShipboardTacticalSystems, Focus.SmallCraft, Focus.Survival, Focus.TransportersAndReplicators },
                Weight = 5 },

            new Track {
                Name = TrackName.StarfleetEnlisted,
                Major = DepartmentName.Science,
                DepartmentModifiers = new CharacterDepartments { Science = 2 },
                Trait = "Starfleet Crew",
                Focuses = new List<string> { Focus.Computers, Focus.ElectroPlasmaPowerSystems, Focus.EmergencyMedicine, Focus.EVA, Focus.HandPhasers, Focus.HandToHandCombat, Focus.HelmOperations, Focus.ShipboardTacticalSystems, Focus.SmallCraft, Focus.Survival, Focus.TransportersAndReplicators },
                Weight = 5 },

            new Track {
                Name = TrackName.StarfleetIntelligence,
                Major = DepartmentName.Command,
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                Trait = "Intelligence Operative",
                Focuses = new List<string> { Focus.Computers, Focus.Diplomacy, Focus.Espionage, Focus.HandPhasers, Focus.HandPhasers, Focus.HandToHandCombat, Focus.Infiltration, Focus.Interrogation, Focus.Linguistics, Focus.Persuasion, Focus.Politics },
                Weight = 1 },

            new Track {
                Name = TrackName.StarfleetIntelligence,
                Major = DepartmentName.Security,
                DepartmentModifiers = new CharacterDepartments { Security = 2 },
                Trait = "Intelligence Operative",
                Focuses = new List<string> { Focus.Computers, Focus.Diplomacy, Focus.Espionage, Focus.HandPhasers, Focus.HandPhasers, Focus.HandToHandCombat, Focus.Infiltration, Focus.Interrogation, Focus.Linguistics, Focus.Persuasion, Focus.Politics },
                Weight = 1 },

            new Track {
                Name = TrackName.DiplomaticCorps,
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                RandomTrait = new List<string> { "Ambassador", "Diplomat" },
                Focuses = new List<string> { Focus.Anthropology, Focus.Composure, Focus.Diplomacy, Focus.Espionage, Focus.History, Focus.Linguistics, Focus.Literature, Focus.Persuasion, Focus.Philosophy, Focus.Politics },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianPhysician,
                RandomTrait = new List<string> { "Geneticist", "Physician", "Psychiatrist", "Surgeon" },
                DepartmentModifiers = new CharacterDepartments { Medicine = 2 },
                Focuses = new List<string> { Focus.Cybernetics, Focus.EmergencyMedicine,  Focus.Genetics, Focus.InfectiousDiseases, Focus.Psychiatry, Focus.Surgery, Focus.TraumaSurgery, Focus.Virology, Focus.Xenobiology },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianScientist,
                Major = DepartmentName.Science,
                RandomTrait = new List<string> { "Cyberneticist", "Scientist" },
                MustSelectAttribute = AttributeName.Reason,
                DepartmentModifiers = new CharacterDepartments { Science = 2 },
                Focuses = new List<string> { Focus.Astrophysics, Focus.Botany, Focus.Computers, Focus.Cybernetics, Focus.ExoTectonics, Focus.Genetics, Focus.Physics, Focus.QuantumMechanics, Focus.SubspaceTheory, Focus.TemporalMechanics, Focus.TransportersAndReplicators, Focus.WarpFieldDynamics },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianScientist,
                Major = DepartmentName.Engineering,
                RandomTrait = new List<string> { "Engineer", "Transporter Expert" },
                MustSelectAttribute = AttributeName.Reason,
                DepartmentModifiers = new CharacterDepartments { Engineering = 2 },
                Focuses = new List<string> { Focus.Astrophysics, Focus.Botany, Focus.Computers, Focus.Cybernetics, Focus.ExoTectonics, Focus.Genetics, Focus.Physics, Focus.QuantumMechanics, Focus.SubspaceTheory, Focus.TemporalMechanics, Focus.TransportersAndReplicators, Focus.WarpFieldDynamics },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianOfficial,
                Major = AttributeName.Insight,
                Trait = "Administrator",
                MustSelectAttribute = AttributeName.Insight,
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                Focuses = new List<string> { Focus.Bureaucracy, Focus.Diplomacy, Focus.Politics, Focus.Linguistics, Focus.History, Focus.Philosophy },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianOfficial,
                Major = AttributeName.Presence,
                Trait = "Administrator",
                MustSelectAttribute = AttributeName.Presence,
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                Focuses = new List<string> { Focus.Bureaucracy, Focus.Diplomacy, Focus.Politics, Focus.Linguistics, Focus.History, Focus.Philosophy },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianTrader,
                Major = AttributeName.Insight,
                RandomTrait = new List<string> { "Bartender", "Free Trader", "Merchant" },
                MustSelectAttribute = AttributeName.Insight,
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                Focuses = new List<string> { Focus.Art, Focus.Cooking, Focus.Psychology, Focus.Economics, Focus.Logistics, Focus.Persuasion, Focus.Tailoring, Focus.Disruptors },
                Weight = 1 },

            new Track {
                Name = TrackName.CivilianTrader,
                Major = AttributeName.Presence,
                RandomTrait = new List<string> { "Bartender", "Free Trader", "Merchant" },
                MustSelectAttribute = AttributeName.Presence,
                DepartmentModifiers = new CharacterDepartments { Command = 2 },
                Focuses = new List<string> { Focus.Art, Focus.Cooking, Focus.Psychology, Focus.Economics, Focus.Logistics, Focus.Persuasion, Focus.Tailoring, Focus.Disruptors },
                Weight = 1 },
        };
    }
}
