using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class TrackSelector
    {
        private const int MaxDispline = 4;

        public static Track ChooseTrack(Character character)
        {
            var availableTracks = new List<Track>();

            foreach (var track in Tracks)
            {
                if (track.DisciplineModifiers.Command + character.Disciplines.Command <= MaxDispline &&
                    track.DisciplineModifiers.Conn + character.Disciplines.Conn <= MaxDispline &&
                    track.DisciplineModifiers.Engineering + character.Disciplines.Engineering <= MaxDispline &&
                    track.DisciplineModifiers.Medicine + character.Disciplines.Medicine <= MaxDispline &&
                    track.DisciplineModifiers.Science + character.Disciplines.Science <= MaxDispline &&
                    track.DisciplineModifiers.Security + character.Disciplines.Security <= MaxDispline)
                    availableTracks.Add(track);
            }

            return availableTracks.OrderBy(n => Util.GetRandom()).First();
        }

        public static Track GetUpringing(string name)
        {
            return Tracks.First(x => x.Name == name);
        }

        private static readonly List<Track> Tracks = new List<Track>
        {
            new Track {
                Name = DisciplineName.Command,
                DisciplineModifiers = new CharacterDisciplines { Command = 2 },
                Focuses = new List<string> { Focus.Art, Focus.Composure, Focus.CulturalStudies, Focus.Debate, Focus.Deception, Focus.Diplomacy, Focus.Empathy, Focus.Gambling, Focus.History, Focus.Inspiration, Focus.Law, Focus.LeadByExample, Focus.Linguistics, Focus.MentalDiscipline, Focus.Negotiation, Focus.Persuasion, Focus.Philosophy, Focus.Politics, Focus.StarshipRecognition, Focus.StarfleetProtocol, Focus.StrategyOrTactics, Focus.Teaching, Focus.TeamDynamics } },

            new Track {
                Name = DisciplineName.Conn,
                DisciplineModifiers = new CharacterDisciplines { Conn = 2 },
                Focuses = new List<string> { Focus.Astronavigation, Focus.Astrophysics, Focus.AtmosphericFlight, Focus.CombatManeuvers, Focus.ExtraVehicularActivity, Focus.EvasiveAction, Focus.GroundVehicles, Focus.HelmOperations, Focus.ImpulseEngines, Focus.SmallCraft, Focus.StarfleetProtocol, Focus.StarshipRecognition, Focus.Survival, Focus.WarpDrive } },

            new Track {
                Name = DisciplineName.Engineering,
                DisciplineModifiers = new CharacterDisciplines { Engineering = 2 },
                Focuses = new List<string> { Focus.AdvancedHolograms, Focus.Computers, Focus.Cybernetics, Focus.Diagnostics, Focus.ElectroPlasmaPowerSystems, Focus.EmergencyRepairs, Focus.EnergyWeapons, Focus.FlightControlSystems, Focus.ImagingEquipment, Focus.ImpulseFundamentals, Focus.JuryRigging, Focus.ModelingAndDesign, Focus.ReverseEngineering, Focus.SensorCalibration, Focus.StructuralEngineering, Focus.SystemMaintenance, Focus.TransportersAndReplicators, Focus.Troubleshooting, Focus.WarpCoreMechanics, Focus.WarpFieldDynamics } },

            new Track {
                Name = DisciplineName.Security,
                DisciplineModifiers = new CharacterDisciplines { Security = 2 },
                Focuses = new List<string> { Focus.CriminalOrganizations, Focus.Espionage, Focus.FleetFormations, Focus.Forensics, Focus.HandPhasers, Focus.HazardousEnvironments, Focus.Infiltration, Focus.Interrogation, Focus.MartialArts, Focus.SecuritySystems, Focus.ShipEngagementTactics, Focus.ShipLockdownProcedures, Focus.ShipboardTacticalSystems, Focus.SmallUnitTactics, Focus.Survival, Focus.TargetingSystems } },

            new Track {
                Name = DisciplineName.Science,
                DisciplineModifiers = new CharacterDisciplines { Science = 2 },
                Focuses = new List<string> { Focus.Anthropology, Focus.Archaeology, Focus.Astrometrics, Focus.Astrophysics, Focus.BiologyOrXenobiology, Focus.BotanyOrXenobotany, Focus.Chemistry, Focus.Computers, Focus.Cybernetics, Focus.DeflectorOperations, Focus.ExoTectonics, Focus.GalacticHistory, Focus.Geology, Focus.Linguistics, Focus.PhotonicApplications, Focus.Physics, Focus.QuantumMechanics, Focus.Research, Focus.SensorOperations, Focus.SubspaceTheory, Focus.TemporalMechanics, Focus.UnifiedFieldTheory, Focus.WarpFieldDynamics, Focus.WarpTheory} },

            new Track {
                Name = DisciplineName.Medicine,
                DisciplineModifiers = new CharacterDisciplines { Medicine = 2 },
                Focuses = new List<string> { Focus.Anesthesiology, Focus.BiologyOrXenobiology, Focus.Cybernetics, Focus.Dentistry, Focus.EmergencyMedicine, Focus.Genetics, Focus.GuidedTherapy, Focus.ImagingSystems, Focus.Immunology, Focus.InfectiousDiseases, Focus.InternalMedicine, Focus.MedicalToxicology, Focus.NeuropsychologyOrPsychiatry, Focus.Pediatrics, Focus.Psychiatry, Focus.PsychosomaticDisorders, Focus.Rheumatology, Focus.StressDisorders, Focus.Surgery, Focus.TraumaSurgery, Focus.Virology } },
        };
    }
}
