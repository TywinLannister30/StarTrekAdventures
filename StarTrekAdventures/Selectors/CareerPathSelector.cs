using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class CareerPathSelector
{
    private const int MaxDispline = 4;

    public static CareerPath ChooseCareerPath(Character character)
    {
        var availableCareerPaths = new WeightedList<CareerPath>();

        foreach (var careerPath in CareerPaths)
        {
            if (careerPath.DepartmentModifiers.Command + character.Departments.Command <= MaxDispline &&
                careerPath.DepartmentModifiers.Conn + character.Departments.Conn <= MaxDispline &&
                careerPath.DepartmentModifiers.Engineering + character.Departments.Engineering <= MaxDispline &&
                careerPath.DepartmentModifiers.Medicine + character.Departments.Medicine <= MaxDispline &&
                careerPath.DepartmentModifiers.Science + character.Departments.Science <= MaxDispline &&
                careerPath.DepartmentModifiers.Security + character.Departments.Security <= MaxDispline)
                availableCareerPaths.AddEntry(careerPath, careerPath.Weight);
        }

        return availableCareerPaths.GetRandom();
    }

    internal static List<CareerPath> GetAllCareerPaths()
    {
        return CareerPaths;
    }

    internal static CareerPath GetCareerPath(string name)
    {
        return CareerPaths.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    private static readonly List<CareerPath> CareerPaths = new()
    {
        new CareerPath {
            Name = TrackName.StarfleetOfficerCommand,
            Major = DepartmentName.Command,
            Trait = "Starfleet Officer",
            DepartmentModifiers = new Departments { Command = 2 },
            Focuses = new List<string> { 
                Focus.Art, Focus.Bargain, Focus.Composure, Focus.CourtingRituals, Focus.CulturalExpert, Focus.Debate, 
                Focus.Deception, Focus.Diplomacy, Focus.EmotionalIntelligence, Focus.Etiquette, Focus.Gambling,
                Focus.History, Focus.Inspiration, Focus.Intimidation, Focus.Journalism, Focus.Law, Focus.Linguistics,
                Focus.MentalDiscipline, Focus.MultiDiscipline, Focus.Negotiation, Focus.Persuasion, Focus.Philosophy,
                Focus.Politics, Focus.PrimeDirective, Focus.Rhetoric, Focus.StarfleetProtocol, Focus.StationOperations, 
                Focus.StrategyOrTactics, Focus.Teaching, Focus.TeamDynamics, Focus.TimeManagement },
            Weight = 10
        },

        new CareerPath {
            Name = TrackName.StarfleetOfficerCommand,
            Major = DepartmentName.Conn,
            Trait = "Starfleet Officer",
            DepartmentModifiers = new Departments { Conn = 2 },
            Focuses = new List<string> { 
                Focus.Astronavigation, Focus.Astrophysics, Focus.AtmosphericFlight, Focus.BoatPilotOrSubmersibles, 
                Focus.Climbing, Focus.CombatManeuvers, Focus.CommunicationSystems, Focus.EvacuationProcedures, Focus.EvasiveAction, 
                Focus.ExtraVehicularActivity, Focus.FlightControlSystems, Focus.GroundVehicles, Focus.GuidanceSystems, 
                Focus.HelmOperations, Focus.ImpulseEngines, Focus.PowerManagement, Focus.PrecisionManeuvering,
                Focus.RepairsAndMaintenance, Focus.ShipDesignAndConstruction, Focus.ShuttlebayManagement,
                Focus.SmallCraft, Focus.StationOperations, Focus.StarfleetProtocol, Focus.StarshipExpert, 
                Focus.StarshipRecognition, Focus.StellarCartography, Focus.SubspaceTheory, Focus.Survival, Focus.Tracking,
                Focus.WarpDrive, Focus.ZeroGCombat, },
            Weight = 10 },

        new CareerPath {
            Name = TrackName.StarfleetOfficerOperations,
            Major = DepartmentName.Engineering,
            Trait = "Starfleet Officer",
            DepartmentModifiers = new Departments { Engineering = 2 },
            Focuses = new List<string> {
                Focus.AdvancedHolograms, Focus.Computers, Focus.Cybernetics, Focus.DeflectorSystems, Focus.Diagnostics, 
                Focus.ElectroPlasmaPowerSystems, Focus.EmergencyRepairs, Focus.EnergyWeapons, Focus.EVA, Focus.FlightControlSystems, 
                Focus.Forcefields, Focus.ImagingEquipment, Focus.ImpulseEngines, Focus.JuryRigging, Focus.Locksmith, 
                Focus.Manufacturing, Focus.MiningOperations, Focus.ModelingAndDesign, Focus.PercussiveMaintenance,
                Focus.Propulsion, Focus.ReverseEngineering, Focus.Saboteur, Focus.Salvage, Focus.SensorCalibration,
                Focus.ShuttlecraftMaintenance, Focus.StructuralEngineering, Focus.SubspaceMechanics, Focus.SystemMaintenance, 
                Focus.TransportersAndReplicators, Focus.Troubleshooting, Focus.WarpCoreMechanics},
            Weight = 10 },

        new CareerPath {
            Name = TrackName.StarfleetOfficerOperations,
            Major = DepartmentName.Security,
            Trait = "Starfleet Officer",
            DepartmentModifiers = new Departments { Security = 2 },
            Focuses = new List<string> 
            {
                Focus.AmbushTactics, Focus.BladeWeapons, Focus.Camouflage, Focus.ChemicalAndBiologicalWeapons, Focus.CombatMedic, 
                Focus.ComputerSecuritySystems, Focus.CriminalOrganizations, Focus.CrisisManagement, Focus.DeflectorOperations, 
                Focus.Demolitions, Focus.Espionage, Focus.EvacuationProcedures, Focus.FleetFormations, Focus.Forensics, 
                Focus.HandPhasers, Focus.HazardousEnvironments, Focus.Interrogation, Focus.Intimidation, Focus.LeadInvestigator,
                Focus.MartialArts, Focus.MentalResistanceTechniques, Focus.Phasers, Focus.Pickpocketing, Focus.SecuritySystems,
                Focus.ShipEngagementTactics, Focus.ShipLockdownProcedures, Focus.SmallUnitTactics, Focus.StrategyOrTactics, 
                Focus.TargetingSystems, Focus.Torpedoes },
            Weight = 10 },

        new CareerPath {
            Name = TrackName.StarfleetOfficerSciences,
            Major = DepartmentName.Medicine,
            Trait = "Starfleet Officer",
            RandomTrait = new List<string> { "Physician", "Psychiatrist" },
            DepartmentModifiers = new Departments { Medicine = 2 },
            Focuses = new List<string> 
            { 
                Focus.AlternativeMedicine, Focus.Anesthesiology, Focus.Biotechnology, Focus.Councelling, Focus.Dentistry, 
                Focus.EmergencyMedicine, Focus.Ethics, Focus.FieldMedicine, Focus.FirstAid, Focus.Genetics, Focus.GuidedTherapy,
                Focus.ImagingSystems, Focus.Immunology, Focus.InfectiousDiseases, Focus.InternalMedicine, Focus.Kinesiology, 
                Focus.MedicalToxicology, Focus.Microbiology, Focus.NeuropsychologyOrPsychiatry, Focus.Parapsychology,
                Focus.PatientCare, Focus.Pediatrics, Focus.Pharmacology, Focus.Psychiatry, Focus.Psychoanalysis,
                Focus.PsychosomaticDisorders, Focus.Rheumatology, Focus.StressDisorders, Focus.Surgery, Focus.Triage,
                Focus.VeterinaryMedicine, Focus.Virology },
            Weight = 10 },

        new CareerPath {
            Name = TrackName.StarfleetOfficerSciences,
            Major = DepartmentName.Science,
            Trait = "Starfleet Officer",
            DepartmentModifiers = new Departments { Science = 2 },
            Focuses = new List<string> 
            { 
                Focus.AnimalBehaviour, Focus.Anthropology, Focus.Archaeology, Focus.Astrometrics, Focus.Astrophysics,
                Focus.Biochemistry, Focus.BiologyOrXenobiology, Focus.BotanyOrXenobotany, Focus.Catastrophism, Focus.Chemistry, 
                Focus.Cybernetics, Focus.DeflectorOperations, Focus.Ecology, Focus.ExoTectonics, Focus.Geology, 
                Focus.LaboratoryMaintainance, Focus.Linguistics, Focus.MarineBiology, Focus.Meteorology, Focus.Microbiology, 
                Focus.Physics, Focus.Prototyping, Focus.QuantumMechanics, Focus.RapidAnalysis, Focus.Research, Focus.SensorOperations, 
                Focus.Sociology, Focus.StarfleetProgramming, Focus.SubspaceTheory, Focus.TemporalMechanics, Focus.Terraforming,
                Focus.UnifiedFieldTheory, Focus.UnorthodoxMathematics, Focus.WarpTheory },
            Weight = 10 },

        new CareerPath {
            Name = TrackName.StarfleetEnlisted,
            Major = DepartmentName.Conn,
            DepartmentModifiers = new Departments { Conn = 2 },
            Trait = "Starfleet Crew",
            Focuses = new List<string> {
                Focus.Astronavigation, Focus.Astrophysics, Focus.AtmosphericFlight, Focus.BoatPilotOrSubmersibles,
                Focus.Climbing, Focus.CombatManeuvers, Focus.CommunicationSystems, Focus.EvacuationProcedures, Focus.EvasiveAction,
                Focus.ExtraVehicularActivity, Focus.FlightControlSystems, Focus.GroundVehicles, Focus.GuidanceSystems,
                Focus.HelmOperations, Focus.ImpulseEngines, Focus.PowerManagement, Focus.PrecisionManeuvering,
                Focus.RepairsAndMaintenance, Focus.ShipDesignAndConstruction, Focus.ShuttlebayManagement,
                Focus.SmallCraft, Focus.StationOperations, Focus.StarfleetProtocol, Focus.StarshipExpert,
                Focus.StarshipRecognition, Focus.StellarCartography, Focus.SubspaceTheory, Focus.Survival, Focus.Tracking,
                Focus.WarpDrive, Focus.ZeroGCombat, },
            Weight = 5 },

        new CareerPath {
            Name = TrackName.StarfleetEnlisted,
            Major = DepartmentName.Security,
            DepartmentModifiers = new Departments { Security = 2 },
            Trait = "Starfleet Crew",
            Focuses = new List<string>
            {
                Focus.AmbushTactics, Focus.BladeWeapons, Focus.Camouflage, Focus.ChemicalAndBiologicalWeapons, Focus.CombatMedic,
                Focus.ComputerSecuritySystems, Focus.CriminalOrganizations, Focus.CrisisManagement, Focus.DeflectorOperations,
                Focus.Demolitions, Focus.Espionage, Focus.EvacuationProcedures, Focus.FleetFormations, Focus.Forensics,
                Focus.HandPhasers, Focus.HazardousEnvironments, Focus.Interrogation, Focus.Intimidation, Focus.LeadInvestigator,
                Focus.MartialArts, Focus.MentalResistanceTechniques, Focus.Phasers, Focus.Pickpocketing, Focus.SecuritySystems,
                Focus.ShipEngagementTactics, Focus.ShipLockdownProcedures, Focus.SmallUnitTactics, Focus.StrategyOrTactics,
                Focus.TargetingSystems, Focus.Torpedoes },
            Weight = 5 },

        new CareerPath {
            Name = TrackName.StarfleetEnlisted,
            Major = DepartmentName.Engineering,
            DepartmentModifiers = new Departments { Engineering = 2 },
            Trait = "Starfleet Crew",
            Focuses = new List<string> {
                Focus.AdvancedHolograms, Focus.Computers, Focus.Cybernetics, Focus.DeflectorSystems, Focus.Diagnostics,
                Focus.ElectroPlasmaPowerSystems, Focus.EmergencyRepairs, Focus.EnergyWeapons, Focus.EVA, Focus.FlightControlSystems,
                Focus.Forcefields, Focus.ImagingEquipment, Focus.ImpulseEngines, Focus.JuryRigging, Focus.Locksmith,
                Focus.Manufacturing, Focus.MiningOperations, Focus.ModelingAndDesign, Focus.PercussiveMaintenance,
                Focus.Propulsion, Focus.ReverseEngineering, Focus.Saboteur, Focus.Salvage, Focus.SensorCalibration,
                Focus.ShuttlecraftMaintenance, Focus.StructuralEngineering, Focus.SubspaceMechanics, Focus.SystemMaintenance,
                Focus.TransportersAndReplicators, Focus.Troubleshooting, Focus.WarpCoreMechanics},
            Weight = 5 },

        new CareerPath {
            Name = TrackName.StarfleetEnlisted,
            Major = DepartmentName.Science,
            DepartmentModifiers = new Departments { Science = 2 },
            Trait = "Starfleet Crew",
            Focuses = new List<string>
            {
                Focus.AnimalBehaviour, Focus.Anthropology, Focus.Archaeology, Focus.Astrometrics, Focus.Astrophysics,
                Focus.Biochemistry, Focus.BiologyOrXenobiology, Focus.BotanyOrXenobotany, Focus.Catastrophism, Focus.Chemistry,
                Focus.Cybernetics, Focus.DeflectorOperations, Focus.Ecology, Focus.ExoTectonics, Focus.Geology,
                Focus.LaboratoryMaintainance, Focus.Linguistics, Focus.MarineBiology, Focus.Meteorology, Focus.Microbiology,
                Focus.Physics, Focus.Prototyping, Focus.QuantumMechanics, Focus.RapidAnalysis, Focus.Research, Focus.SensorOperations,
                Focus.Sociology, Focus.StarfleetProgramming, Focus.SubspaceTheory, Focus.TemporalMechanics, Focus.Terraforming,
                Focus.UnifiedFieldTheory, Focus.UnorthodoxMathematics, Focus.WarpTheory },
            Weight = 5 },

        new CareerPath {
            Name = TrackName.StarfleetIntelligence,
            Major = DepartmentName.Command,
            DepartmentModifiers = new Departments { Command = 2 },
            Trait = "Intelligence Operative",
            Focuses = new List<string> { 
                Focus.Art, Focus.Bargain, Focus.Composure, Focus.Computers, Focus.CulturalExpert, Focus.Deception, 
                Focus.Diplomacy, Focus.Espionage, Focus.Gambling, Focus.HandPhasers, Focus.HandPhasers, Focus.HandToHandCombat, 
                Focus.Infiltration, Focus.Interrogation, Focus.Intimidation, Focus.Law, Focus.Linguistics, Focus.MentalDiscipline, 
                Focus.Persuasion, Focus.Politics, Focus.StrategyOrTactics },
            Weight = 1 },

        new CareerPath {
            Name = TrackName.StarfleetIntelligence,
            Major = DepartmentName.Security,
            DepartmentModifiers = new Departments { Security = 2 },
            Trait = "Intelligence Operative",
            Focuses = new List<string>
            {
                Focus.AmbushTactics, Focus.BladeWeapons, Focus.Camouflage, Focus.ChemicalAndBiologicalWeapons, Focus.CombatMedic,
                Focus.ComputerSecuritySystems, Focus.CriminalOrganizations, Focus.DeflectorOperations, Focus.Demolitions, 
                Focus.Espionage, Focus.FleetFormations, Focus.Forensics, Focus.HandPhasers, Focus.HazardousEnvironments, 
                Focus.HandToHandCombat, Focus.Infiltration, Focus.Interrogation, Focus.Intimidation, Focus.LeadInvestigator, 
                Focus.Linguistics, Focus.MartialArts, Focus.MentalResistanceTechniques, Focus.Persuasion, Focus.Phasers, 
                Focus.Pickpocketing, Focus.SecuritySystems },

            Weight = 1 },

        new CareerPath {
            Name = TrackName.DiplomaticCorps,
            DepartmentModifiers = new Departments { Command = 2 },
            RandomTrait = new List<string> { "Ambassador", "Diplomat" },
            Focuses = new List<string> { 
                Focus.Anthropology, Focus.Art, Focus.Composure, Focus.Debate, Focus.Deception, Focus.Diplomacy, Focus.Espionage,
                Focus.Etiquette, Focus.History, Focus.Law, Focus.Linguistics, Focus.Literature, Focus.MentalDiscipline, 
                Focus.Negotiation, Focus.Persuasion, Focus.Philosophy, Focus.Politics, Focus.TimeManagement },
            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianPhysician,
            RandomTrait = new List<string> { "Geneticist", "Physician", "Psychiatrist", "Surgeon" },
            DepartmentModifiers = new Departments { Medicine = 2 },
            Focuses = new List<string>
            {
                Focus.AlternativeMedicine, Focus.Anesthesiology, Focus.Biotechnology, Focus.Councelling, Focus.Dentistry,
                Focus.EmergencyMedicine, Focus.Ethics, Focus.FieldMedicine, Focus.FirstAid, Focus.Genetics, Focus.GuidedTherapy,
                Focus.ImagingSystems, Focus.Immunology, Focus.InfectiousDiseases, Focus.InternalMedicine, Focus.Kinesiology,
                Focus.MedicalToxicology, Focus.Microbiology, Focus.NeuropsychologyOrPsychiatry, Focus.Parapsychology,
                Focus.PatientCare, Focus.Pediatrics, Focus.Pharmacology, Focus.Psychiatry, Focus.Psychoanalysis,
                Focus.PsychosomaticDisorders, Focus.Rheumatology, Focus.StressDisorders, Focus.Surgery, Focus.Triage,
                Focus.VeterinaryMedicine, Focus.Virology },

            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianScientist,
            Major = DepartmentName.Science,
            RandomTrait = new List<string> { "Cyberneticist", "Scientist" },
            MustSelectAttribute = AttributeName.Reason,
            DepartmentModifiers = new Departments { Science = 2 },
            Focuses = new List<string>
            {
                Focus.AnimalBehaviour, Focus.Anthropology, Focus.Archaeology, Focus.Astrometrics, Focus.Astrophysics,
                Focus.Biochemistry, Focus.BiologyOrXenobiology, Focus.BotanyOrXenobotany, Focus.Catastrophism, Focus.Chemistry,
                Focus.Cybernetics, Focus.DeflectorOperations, Focus.Ecology, Focus.ExoTectonics, Focus.Geology,
                Focus.LaboratoryMaintainance, Focus.Linguistics, Focus.MarineBiology, Focus.Meteorology, Focus.Microbiology,
                Focus.Physics, Focus.Prototyping, Focus.QuantumMechanics, Focus.RapidAnalysis, Focus.Research, Focus.SensorOperations,
                Focus.Sociology, Focus.StarfleetProgramming, Focus.SubspaceTheory, Focus.TemporalMechanics, Focus.Terraforming,
                Focus.UnifiedFieldTheory, Focus.UnorthodoxMathematics, Focus.WarpTheory },
            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianScientist,
            Major = DepartmentName.Engineering,
            RandomTrait = new List<string> { "Engineer", "Transporter Expert" },
            MustSelectAttribute = AttributeName.Reason,
            DepartmentModifiers = new Departments { Engineering = 2 },
            Focuses = new List<string> {
                Focus.AdvancedHolograms, Focus.Computers, Focus.Cybernetics, Focus.DeflectorSystems, Focus.Diagnostics,
                Focus.ElectroPlasmaPowerSystems, Focus.EmergencyRepairs, Focus.EnergyWeapons, Focus.EVA, Focus.FlightControlSystems,
                Focus.Forcefields, Focus.ImagingEquipment, Focus.ImpulseEngines, Focus.JuryRigging, Focus.Locksmith,
                Focus.Manufacturing, Focus.MiningOperations, Focus.ModelingAndDesign, Focus.PercussiveMaintenance,
                Focus.Propulsion, Focus.ReverseEngineering, Focus.Saboteur, Focus.Salvage, Focus.SensorCalibration,
                Focus.ShuttlecraftMaintenance, Focus.StructuralEngineering, Focus.SubspaceMechanics, Focus.SystemMaintenance,
                Focus.TransportersAndReplicators, Focus.Troubleshooting, Focus.WarpCoreMechanics},

            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianOfficial,
            Major = AttributeName.Insight,
            Trait = "Administrator",
            MustSelectAttribute = AttributeName.Insight,
            DepartmentModifiers = new Departments { Command = 2 },
            Focuses = new List<string> 
            { 
                Focus.Bureaucracy, Focus.Diplomacy, Focus.Politics, Focus.Linguistics, Focus.History, Focus.Philosophy 
            },
            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianOfficial,
            Major = AttributeName.Presence,
            Trait = "Administrator",
            MustSelectAttribute = AttributeName.Presence,
            DepartmentModifiers = new Departments { Command = 2 },
            Focuses = new List<string> 
            { 
                Focus.Bureaucracy, Focus.Diplomacy, Focus.Politics, Focus.Linguistics, Focus.History, Focus.Philosophy 
            },
            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianTrader,
            Major = AttributeName.Insight,
            RandomTrait = new List<string> { "Bartender", "Free Trader", "Merchant" },
            MustSelectAttribute = AttributeName.Insight,
            DepartmentModifiers = new Departments { Command = 2 },
            Focuses = new List<string> 
            { 
                Focus.Art, Focus.Cooking, Focus.Psychology, Focus.Economics, Focus.Logistics, Focus.Persuasion, 
                Focus.Tailoring, Focus.Disruptors 
            },
            Weight = 1 },

        new CareerPath {
            Name = TrackName.CivilianTrader,
            Major = AttributeName.Presence,
            RandomTrait = new List<string> { "Bartender", "Free Trader", "Merchant" },
            MustSelectAttribute = AttributeName.Presence,
            DepartmentModifiers = new Departments { Command = 2 },
            Focuses = new List<string> 
            { 
                Focus.Art, Focus.Cooking, Focus.Psychology, Focus.Economics, Focus.Logistics, Focus.Persuasion, 
                Focus.Tailoring, Focus.Disruptors 
            },
            Weight = 1 },
    };
}
