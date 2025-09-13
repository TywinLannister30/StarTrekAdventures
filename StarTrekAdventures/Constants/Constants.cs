namespace StarTrekAdventures.Constants
{
    public class Enums
    {
        public enum Gender
        {
            None = 0,
            Male = 1,
            Female = 2
        }

        public enum InjuryType
        {
            Stun,
            StunOrDeadly,
            Deadly
        }

        public enum LifepathStage
        {
            Species = 1,
            Environemt = 2,
            Upbringing = 3,
            StarfleetAcademy = 4,
            Career = 5,
            CareerEvents = 6,
            FinishingTouches = 7
        }

        public enum NPCType
        {
            Minor,
            Notable,
            Major
        }

        public enum Operator
        {
            None = 0,
            And = 1,
            Or = 2
        }

        public enum StarshipWeaponType
        {
            None,
            Energy,
            Torpedo
        }

        public enum StarshipWeaponRange
        {
            None,
            Close,
            Medium,
            Long
        }

        public enum WeaponSize
        {
            OneHanded,
            TwoHanded
        }

        public enum WeaponType
        {
            Melee,
            Ranged
        }
    }

    public static class SpeciesName
    {
        public const string Aenar = "Aenar";
        public const string Andorian = "Andorian";
        public const string Ankari = "Ankari";
        public const string Arbazan = "Arbazan";
        public const string Ardanan = "Ardanan";
        public const string Argrathi = "Argrathi";
        public const string Arkarian = "Arkarian";
        public const string Aurelian = "Aurelian";
        public const string Bajoran = "Bajoran";
        public const string Barzan = "Barzan";
        public const string Benzite = "Benzite";
        public const string Betazoid = "Betazoid";
        public const string Bolian = "Bolian";
        public const string Breen = "Breen";
        public const string Caitian = "Caitian";
        public const string Cardassian = "Cardassian";
        public const string Changeling = "Changeling";
        public const string CyberneticallyEnhanced = "Cybernetically Enhanced";
        public const string Deltan = "Deltan";
        public const string Denobulan = "Denobulan";
        public const string Dosi = "Dosi";
        public const string Drai = "Drai";
        public const string Edosian = "Edosian";
        public const string Efrosian = "Efrosian";
        public const string Ferengi = "Ferengi";
        public const string Grazerite = "Grazerite";
        public const string Haliian = "Haliian";
        public const string Human = "Human";
        public const string JemHadar = "Jem'Hadar";
        public const string Jye = "Jye";
        public const string Karemma = "Karemma";
        public const string KelpianPreVaharai = "Kelpian (Pre-Vahar'ai)";
        public const string KelpianPostVaharai = "Kelpian (Post-Vahar'ai)";
        public const string Klingon = "Klingon";
        public const string Ktarian = "Ktarian";
        public const string LiberatedBorg = "Liberated Borg";
        public const string Lokirrim = "Lokirrim";
        public const string Lurian = "Lurian";
        public const string Mari = "Mari";
        public const string Monean = "Monean";
        public const string Nausicaan = "Nausicaan";
        public const string Ocampa = "Ocampa";
        public const string Orion = "Orion";
        public const string Osnullus = "Osnullus";
        public const string Paradan = "Paradan";
        public const string Pendari = "Pendari";
        public const string Reman = "Reman";
        public const string Rakhari = "Rakhari";
        public const string RigellianChelon = "Rigellian Chelon";
        public const string RigellianJelna = "Rigellian Jelna";
        public const string Risian = "Risian";
        public const string Romulan = "Romulan";
        public const string Saurian = "Saurian";
        public const string Sikarian = "Sikarian";
        public const string Skreeaa = "Skreeaa";
        public const string Sona = "Son'a";
        public const string SoongTypeAndroid = "Soong-Type Android";
        public const string Talaxian = "Talaxian";
        public const string Tellarite = "Tellarite";
        public const string Tosk = "Tosk";
        public const string Trill = "Trill";
        public const string Turei = "Turei";
        public const string Vorta = "Vorta";
        public const string Vulcan = "Vulcan";
        public const string Wadi = "Wadi";
        public const string Xahean = "Xahean";
        public const string XindiArboreal = "Xindi-Arboreal";
        public const string XindiInsectoid = "Xindi-Insectoid";
        public const string XindiPrimate = "Xindi-Primate";
        public const string XindiReptilian = "Xindi-Reptilian";
        public const string Zahl = "Zahl";
        public const string Zakdorn = "Zakdorn";
        public const string Zaranite = "Zaranite";
    }

    public static class AttributeName
    {
        public const string Control = "Control";
        public const string Daring = "Daring";
        public const string Fitness = "Fitness";
        public const string Insight = "Insight";
        public const string Presence = "Presence";
        public const string Reason = "Reason";
    }

    public static class DisciplineName
    {
        public const string Command = "Command";
        public const string Conn = "Conn";
        public const string Engineering = "Engineering";
        public const string Medicine = "Medicine";
        public const string Science = "Science";
        public const string Security = "Security";
    }

    public static class DepartmentName
    {
        public const string Command = "Command";
        public const string Conn = "Conn";
        public const string Engineering = "Engineering";
        public const string Medicine = "Medicine";
        public const string Science = "Science";
        public const string Security = "Security";
    }

    public static class SystemName
    {
        public const string Comms = "Comms";
        public const string Computers = "Computers";
        public const string Engines = "Engines";
        public const string Sensors = "Sensors";
        public const string Structure = "Structure";
        public const string Weapons = "Weapons";
    }

    public static class TrackName
    {
        public const string StarfleetOfficerCommand = "Starfleet Officer (Command)";
        public const string StarfleetOfficerOperations = "Starfleet Officer (Operations)";
        public const string StarfleetOfficerSciences = "Starfleet Officer (Sciences)";
        public const string StarfleetEnlisted = "Starfleet (Enlisted)";
        public const string StarfleetIntelligence = "Starfleet (Intelligence)";
        public const string DiplomaticCorps = "Diplomatic Corps";
        public const string CivilianPhysician = "Civilian (Physician)";
        public const string CivilianScientist = "Civilian (Scientist)";
        public const string CivilianOfficial = "Civilian (Official)";
        public const string CivilianTrader = "Civilian (Trader)";
    }

    public static class Rank
    {
        public const string Cadet = "Cadet";

        public const string Ensign = "Ensign";
        public const string LieutenantJuniorGrade = "Lieutenant (Junior Grade)";
        public const string Lieutenant = "Lieutenant";
        public const string LieutenantCommander = "Lieutenant Commander";
        public const string Commander = "Commander";
        public const string Captain = "Captain";

        public const string FleetCaptain = "Fleet Captain";
        public const string Commodore = "Commodore";
        public const string RearAdmiral = "Rear Admiral";
        public const string ViceAdmiral = "Vice-Admiral";
        public const string Admiral = "Admiral";
        public const string FleetAdmiral = "Fleet Admiral";

        public const string Crewman1stClass = "Crewman (1st class)";
        public const string Crewman2ndClass = "Crewman (2nd class)";
        public const string Crewman3rdClass = "Crewman (3rd class)";
        public const string PettyOfficer1stClass = "Petty Officer (1st class)";
        public const string PettyOfficer2ndClass = "Petty Officer (2nd class)";
        public const string PettyOfficer3rdClass = "Petty Officer (3rd class)";
        public const string Specialist1stClass = "Specialist (1st class)";
        public const string Specialist2ndClass = "Specialist (2nd class)";
        public const string Specialist3rdClass = "Specialist (3rd class)";
        public const string Yeoman1stClass = "Yeoman (1st class)";
        public const string Yeoman2ndClass = "Yeoman (2nd class)";
        public const string Yeoman3rdClass = "Yeoman (3rd class)";
        public const string ChiefPettyOfficer = "Chief Petty Officer";
        public const string ChiefSpecialist = "Chief Specialist";
        public const string SeniorChiefPettyOfficer = "Senior Chief Petty Officer";
        public const string SeniorChiefSpecialist = "Senior Chief Specialist";
        public const string MasterChiefPettyOfficer = "Master Chief Petty Officer";
        public const string MasterChiefSpecialist = "Master Chief Specialist";
    }

    public static class RoleName
    {
        public const string Adjudant = "Adjudant";
        public const string Admiral = "Admiral";
        public const string Anesthesiologist = "Anesthesiologist";
        public const string CommandingOfficer = "Commanding Officer";
        public const string DiplomaticAttache = "Diplomatic Attache";
        public const string ExecutiveOfficer = "Executive Officer";
        public const string OperationsManager = "Operations Manager";
        public const string ChiefEngineer = "Chief Engineer";
        public const string ChiefOfSecurity = "Chief of Security";
        public const string ChiefMedicalOfficer = "Chief Medical Officer";
        public const string ChiefScienceOfficer = "Chief Science Officer";
        public const string ScienceOfficer = "Science Officer";
        public const string ChiefSurgeon = "Chief Surgeon";
        public const string ChiefTacticalOfficer = "Chief Tactical Officer";
        public const string FleetLiaisonOfficer = "Fleet Liaison Officer";
        public const string FlightController = "Flight Controller";
        public const string CommunicationsOfficer = "Communications Officer";
        public const string HeadNurse = "Head Nurse";
        public const string Navigator = "Navigator";
        public const string IntelligenceOfficer = "Intelligence Officer";
        public const string PhysiciansAssistant = "Physician’s Assistant";
        public const string ShipsCounselor = "Ship's Counselor";
        public const string ShipsDoctor = "Ship's Doctor";
        public const string StrategicOperationsOfficer = "Strategic Operations Officer";
        public const string Bodyguard = "Bodyguard";
        public const string Expert = "Expert";
        public const string Merchant = "Merchant";
        public const string PoliticalLiason = "Political Liason";
        public const string IntelligenceAgent = "Intelligence Agent";
        public const string Translator = "Translator";
    }

    public static class CareerName
    {
        public const string Young = "Young Officer";
        public const string Experienced = "Experienced Officer";
        public const string Veteran = "Veteran Officer";
    }

    public static class ExperienceName
    {
        public const string Novice = "Novice";
        public const string Experienced = "Experienced";
        public const string Veteran = "Veteran";
    }

    public static class Trait
    {
        public const string ArtificalHearing = "Artifical Hearing";
        public const string ArtificalSight = "Artifical Sight";
        public const string ArtificalSmell = "Artifical Smell";
        public const string ArtificalTaste = "Artifical Taste";
        public const string ArtificalTouch = "Artifical Touch";
        public const string Augmented = "Augmented";
        public const string FlagOfficer = "Flag Officer";
    }

    public static class Focus
    {
        public const string AdvancedHolograms = "Advanced Holograms";
        public const string AlternateHistories = "AlternateHistories";
        public const string AlternativeMedicine = "Alternative Medicine";
        public const string AmbushTactics = "Ambush Tactics";
        public const string AncientTechnology = "Ancient Technology";
        public const string Anesthesiology = "Anesthesiology";
        public const string AnimalBehaviour = "Animal Behaviour";
        public const string AnimalHandling = "Animal Handling";
        public const string AnomalousPhysics = "Anomalous Physics";
        public const string Anthropology = "Anthropology";
        public const string Archaeology = "Archaeology";
        public const string Archaeotechnology = "Archaeotechnology";
        public const string ArchaeologicalMedicine = "Archaeological Medicine";
        public const string Art = "Art";
        public const string Astrometrics = "Astrometrics";
        public const string Astromycology = "Astromycology";
        public const string Astronavigation = "Astronavigation";
        public const string Astrophysics = "Astrophysics";
        public const string Athletics = "Athletics";
        public const string AtmosphericFlight = "Atmospheric Flight";
        public const string Bargain = "Bargain";
        public const string Biochemistry = "Biochemistry";
        public const string BiologyOrXenobiology = "Biology/Xenobiology";
        public const string Biotechnology = "Biotechnology";
        public const string BladeWeapons = "Blade Weapons";
        public const string BoatPilotOrSubmersibles = "Boat Pilot/Submersibles";
        public const string Botany = "Botany";
        public const string BotanyOrXenobotany = "Botany/Xenobotany";
        public const string Bureaucracy = "Bureaucracy";
        public const string Camouflage = "Camouflage";
        public const string Catastrophism = "Catastrophism";
        public const string ChemicalAndBiologicalWeapons = "Chemical and Biological Weapons";
        public const string Chemistry = "Chemistry";
        public const string Climbing = "Climbing";
        public const string CombatMedic = "Combat Medic";
        public const string CombatTactics = "Combat Tactics";
        public const string CombatManeuvers = "Combat Maneuvers";
        public const string CommunicationSystems = "Communication Systems";
        public const string Composure = "Composure";
        public const string Computers = "Computers";
        public const string ComputerSecuritySystems = "Computer Security Systems";
        public const string Cooking = "Cooking";
        public const string Councelling = "Councelling";
        public const string CourtingRituals = "Courting Rituals";
        public const string CriminalOrganizations = "Criminal Organizations";
        public const string CrisisManagement = "Crisis Management";
        public const string CulturalExpert = "Cultural Expert";
        public const string CulturalStudies = "Cultural Studies";
        public const string Cybernetics = "Cybernetics";
        public const string DamageControlProcedures = "Damage Control Procedures";
        public const string Deception = "Deception";
        public const string Debate = "Debate";
        public const string DeflectorOperations = "Deflector Operations";
        public const string DeflectorSystems = "Deflector Systems";
        public const string Demolitions = "Demolitions";
        public const string Dentistry = "Dentistry";
        public const string Diagnostics = "Diagnostics";
        public const string Diplomacy = "Diplomacy";
        public const string Disruptors = "Disruptors";
        public const string Ecology = "Ecology";
        public const string Economics = "Economics";
        public const string ElectroPlasmaPowerSystems = "Electro-Plasma Power Systems";
        public const string Electronics = "Electronics";
        public const string EmergencyMedicine = "Emergency Medicine";
        public const string EmergencyRepairs = "Emergency Repairs";
        public const string EmotionalIntelligence = "Emotional Intelligence";
        public const string Empathy = "Empathy";
        public const string Endurance = "Endurance";
        public const string EnergyWeapons = "Energy Weapons";
        public const string EPSPowerSystems = "EPS Power Systems";
        public const string Espionage = "Espionage";
        public const string Ethics = "Ethics";
        public const string Etiquette = "Etiquette";
        public const string EVA = "EVA";
        public const string EvacuationProcedures = "Evacuation Procedures";
        public const string EvasiveAction = "Evasive Action";
        public const string ExoTectonics = "Exo-tectonics";
        public const string ExtraVehicularActivity = "Extra-Vehicular Activity";
        public const string ExperimentalTechnology = "Experimental Technology";
        public const string FieldMedicine = "Field Medicine";
        public const string Finances = "Finances";
        public const string FirstAid = "First Aid";
        public const string FleetFormations = "Fleet Formations";
        public const string FleetStrategyAndTactics = "Fleet Strategy and Tactics";
        public const string FlightControlSystems = "Flight Control Systems";
        public const string Forcefields = "Forcefields";
        public const string Forensics = "Forensics";
        public const string FusionReactors = "Fusion Reactors";
        public const string GalacticHistory = "Galactic History";
        public const string GalacticPolitics = "Galactic Politics";
        public const string Gambling = "Gambling";
        public const string Genetics = "Genetics";
        public const string Geology = "Geology";
        public const string GroundVehicles = "Ground Vehicles";
        public const string GuidanceSystems = "Guidance Systems";
        public const string GuidedTherapy = "Guided Therapy";
        public const string HandToHandCombat = "Hand-to-Hand Combat";
        public const string HandPhasers = "Hand Phasers";
        public const string HazardAwareness = "Hazard Awareness";
        public const string HazardousEnvironments = "Hazardous Environments";
        public const string HelmOperations = "Helm Operations";
        public const string History = "History";
        public const string Holoprogramming = "Holoprogramming";
        public const string Improvisation = "Improvisation";
        public const string ImagingEquipment = "Imaging Equipment";
        public const string ImagingSystems = "Imaging Systems";
        public const string Immunology = "Immunology";
        public const string ImpulseEngines = "Impulse Engines";
        public const string ImpulseFundamentals = "Impulse Fundamentals";
        public const string InfectiousDiseases = "Infectious Diseases";
        public const string Infiltration = "Infiltration";
        public const string Inspiration = "Inspiration";
        public const string Interrogation = "Interrogation";
        public const string InternalMedicine = "Internal Medicine";
        public const string Intimidation = "Intimidation";
        public const string Invention = "Invention";
        public const string Investigation = "Investigation";
        public const string Journalism = "Journalism";
        public const string JuryRigging = "Jury-Rigging";
        public const string Kinesiology = "Kinesiology";
        public const string LaboratoryMaintainance = "Laboratory Maintainance";
        public const string Law = "Law";
        public const string LeadByExample = "Lead by Example";
        public const string LeadInvestigator = "Lead Investigator";
        public const string Linguistics = "Linguistics";
        public const string Literature = "Literature";
        public const string Locksmith = "Locksmith";
        public const string Logistics = "Logistics";
        public const string Manufacturing = "Manufacturing";
        public const string MarineBiology = "Marine Biology";
        public const string MartialArts = "Martial Arts";
        public const string MatterAntimatterReactors = "Matter/Antimatter Reactors";
        public const string MedicalToxicology = "Medical Toxicology";
        public const string MentalDiscipline = "Mental Discipline";
        public const string MentalResistanceTechniques = "Mental Resistance Techniques";
        public const string Metallurgy = "Metallurgy";
        public const string Meteorology = "Meteorology";
        public const string Microbiology = "Microbiology";
        public const string MilitaryHistory = "Military History";
        public const string MilitaryTactics = "Military Tactics";
        public const string MiningOperations = "Mining Operations";
        public const string ModelingAndDesign = "Modeling and Design";
        public const string MolecularSynthesis = "Molecular Synthesis";
        public const string MultiDimensionalPhysics = "Multi-Dimensional Physics";
        public const string MultiDiscipline = "Multi-Discipline";
        public const string Music = "Music";
        public const string Navigation = "Navigation";
        public const string Negotiation = "Negotiation";
        public const string NeuropsychologyOrPsychiatry = "Neuropsychology/Psychiatry";
        public const string NuclearPhysics = "Nuclear Physics";
        public const string Observation = "Observation";
        public const string Parapsychology = "Parapsychology";
        public const string PatientCare = "Patient Care";
        public const string Pediatrics = "Pediatrics";
        public const string PercussiveMaintenance = "Percussive Maintenance";
        public const string Persuasion = "Persuasion";
        public const string Phasers = "Phasers";
        public const string Pharmacology = "Pharmacology";
        public const string Philosophy = "Philosophy";
        public const string PhotonicApplications = "Photonic Applications";
        public const string Physics = "Physics";
        public const string Pickpocketing = "Pickpocketing";
        public const string PlasmaPhysics = "Plasma Physics";
        public const string Politics = "Politics";
        public const string PowerManagement = "Power Management";
        public const string PowerSystems = "Power Systems";
        public const string PrecisionManeuvering = "Precision Maneuvering";
        public const string PrimeDirective = "Prime Directive";
        public const string Propulsion = "Propulsion";
        public const string Prototyping = "Prototyping";
        public const string Psychiatry = "Psychiatry";
        public const string Psychoanalysis = "Psychoanalysis";
        public const string Psychology = "Psychology";
        public const string PsychosomaticDisorders = "Psychosomatic Disorders";
        public const string QuantumMechanics = "Quantum Mechanics";
        public const string RapidAnalysis = "Rapid Analysis";
        public const string RepairsAndMaintenance = "Repairs and Maintenance";
        public const string Research = "Research";
        public const string Resilience = "Resilience";
        public const string ReverseEngineering = "Reverse Engineering";
        public const string Rheumatology = "Rheumatology";
        public const string Rhetoric = "Rhetoric";
        public const string Saboteur = "Saboteur";
        public const string Salvage = "Salvage";
        public const string SensorCalibration = "Sensor Calibration";
        public const string SensorOperations = "Sensor Operations";
        public const string ShipEngagementTactics = "Ship Engagement Tactics";
        public const string SecuritySystems = "Security Systems";
        public const string ShipDesignAndConstruction = "Ship Design and Construction";
        public const string ShipLockdownProcedures = "Ship Lockdown Procedures";
        public const string ShipboardTacticalSystems = "Shipboard Tactical Systems";
        public const string ShuttlebayManagement = "Shuttlebay Management";
        public const string ShuttlecraftMaintenance = "Shuttlecraft Maintenance";
        public const string SmallCraft = "Small Craft";
        public const string SmallUnitTactics = "Small Unit Tactics";
        public const string Sociology = "Sociology";
        public const string StarfleetProgramming = "Starfleet Programming";
        public const string StarfleetProtocol = "Starfleet Protocols";
        public const string StarshipExpert = "Starship Expert";
        public const string StarshipRecognition = "Starship Recognition";
        public const string StarshipTactics = "Starship Tactics";
        public const string StationOperations = "Station Operations";
        public const string StellarCartography = "Stellar Cartography";
        public const string StrategyOrTactics = "Strategy/Tactics";
        public const string StressDisorders = "Stress Disorders";
        public const string StructuralEngineering = "Structural Engineering";
        public const string SubspaceCommunications = "Subspace Communications";
        public const string SubspaceDynamics = "Subspace Dynamics";
        public const string SubspaceMechanics = "Subspace Mechanics";
        public const string SubspaceTheory = "Subspace Theory";
        public const string Subterfuge = "Subterfuge";
        public const string Surgery = "Surgery";
        public const string Survey = "Survey";
        public const string Survival = "Survival";
        public const string SurvivalTraining = "Survival Training";
        public const string SystemMaintenance = "System Maintenance";
        public const string TacticalSystems = "Tactical Systems";
        public const string Tailoring = "Tailoring";
        public const string Teaching = "Teaching";
        public const string TargetingSystems = "Targeting Systems";
        public const string TeamDynamics = "Team Dynamics";
        public const string TemporalMechanics = "Temporal Mechanics";
        public const string Terraforming = "Terraforming";
        public const string TheoreticalPhysics = "Theoretical Physics";
        public const string TimeManagement = "Time Management";
        public const string Torpedoes = "Torpedoes";
        public const string Toxicology = "Toxicology";
        public const string Tracking = "Tracking";
        public const string TransportersAndReplicators = "Transporters & Replicators";
        public const string TraumaSurgery = "Trauma Surgery";
        public const string Triage = "Triage";
        public const string Troubleshooting = "Troubleshooting";
        public const string UnifiedFieldTheory = "Unified Field Theory";
        public const string UniformCodeOfJustice = "Uniform Code of Justice";
        public const string UnorthodoxMathematics = "Unorthodox Mathematics";
        public const string VeterinaryMedicine = "Veterinary Medicine";
        public const string Virology = "Virology";
        public const string Xenobiology = "Xenobiology";
        public const string WarpDrive = "Warp Drive";
        public const string WarpCoreMechanics = "Warp Core Mechanics";
        public const string WarpEngines = "Warp Engines";
        public const string WarpFieldDynamics = "Warp Field Dynamics";
        public const string WarpTheory = "Warp Theory";
        public const string Willpower = "Willpower";
        public const string ZeroGCombat = "Zero-G Combat";
    }

    public static class SpaceframeName
    {
        public const string Akira = "Akira";
        public const string Ambassador = "Ambassador";
        public const string California = "California";
        public const string Columbia = "Columbia";
        public const string Constellation = "Constellation";
        public const string Constitution = "Constitution";
        public const string ConstitutionIII = "Constitution III";
        public const string Crossfield = "Crossfield";
        public const string Defiant = "Defiant";
        public const string Excelsior = "Excelsior";
        public const string Freedom = "Freedom";
        public const string Galaxy = "Galaxy";
        public const string Intrepid = "Intrepid";
        public const string Luna = "Luna";
        public const string Miranda = "Miranda";
        public const string Nebula = "Nebula";
        public const string Nova = "Nova";
        public const string NX = "NX";
        public const string Oberth = "Oberth";
        public const string Odyssey = "Odyssey";
        public const string Pioneer = "Pioneer";
        public const string Sagan = "Sagan";
        public const string Sovereign = "Sovereign";
        public const string Walker = "Walker";

        // KLINGON
        public const string Brel = "B'rel";
        public const string D7 = "D7";
        public const string VorCha = "Vor'cha";

        // ROMULAN
        public const string DDeridex  = "D'Deridex";
        public const string Mogai = "Mogai";
        public const string TLiss = "T’Liss";

        // CARDASSIAN
        public const string Galor = "Galor";

        // FERENGI
        public const string DKora = "D'Kora";
    }

    public static class MissionProfileName
    {
        public const string Battlecruiser = "Battlecruiser";
        public const string CivilianMerchantMarine = "Civilian Merchant Marine";
        public const string ColonySupport = "Colony Support";
        public const string CrisisAndEmergencyResponse = "Crisis and Emergency Response";
        public const string EspionageOrIntelligence = "Espionage/Intelligence";
        public const string Flagship = "Flagship";
        public const string LogisticalOrQuartermaster = "Logistical/Quartermaster";
        public const string MultiroleExplorer = "Multirole Explorer";
        public const string PathfinderAndReconnaissanceOperations = "Pathfinder and Reconnaissance Operations";
        public const string Patrol = "Patrol";
        public const string ReconnaissanceOperations = "Reconnaissance Operations";
        public const string ReserveFleet = "Reserve Fleet";
        public const string ScientificAndSurveyOperations = "Scientific and Survey Operations";
        public const string StrategicAndDiplomaticOperations = "Strategic and Diplomatic Operations";
        public const string TacticalOperations = "Tactical Operations";
        public const string TechnicalTestbed = "Technical Testbed";
    }

    public static class WeaponName
    {
        public const string UnarmedStrike = "Unarmed Strike";

        public const string BatLeth = "Bat’leth";
        public const string Blade = "Blade";
        public const string Dagger = "Dagger";
        public const string DisruptorPistol = "Disruptor Pistol";
        public const string DisruptorRifle = "Disruptor Rifle";
        public const string DkTahgDagger = "D’k tahg dagger";
        public const string EnergyWhip = "Energy Whip";
        public const string JemHadarPlasmaRifle = "Jem’Hadar Plasma Rifle";
        public const string KarTakin = "Kar’takin";
        public const string PhaserType1 = "Phaser Type-1";
        public const string PhaserType2 = "Phaser Type-2";
        public const string VulcanNervePinch = "Vulcan Nerve Pinch";
    }

    public static class StarshipWeaponName
    {
        public const string DisruptorBanks = "Disruptor Banks";
        public const string DisruptorCannons = "Disruptor Cannons";

        public const string DisruptorSpinalLance = "Disruptor Spinal Lance";

        public const string ElectromagneticCannon = "Electromagnetic Cannon";

        public const string PhaseCannons = "Phase Cannons";

        public const string PhaserArrays = "Phaser Arrays";
        public const string PhaserBanks = "Phaser Banks";
        public const string PulsePhaserCannons = "Pulse Phaser Cannons";

        public const string PhotonTorpedoes = "Photon Torpedoes";
        public const string PlasmaTorpedoes = "Plasma Torpedoes";
        public const string QuantumTorpedoes = "Quantum Torpedoes";
        public const string SpatialTorpedoes = "Spatial Torpedoes";

        public const string GrapplerCable = "Grappler Cable";
        public const string TractorBeam = "Tractor Beam";
    }

    public static class StarshipTalentName
    {
        public const string AblativeArmor = "Ablative Armor";
        public const string AblativeArmorGenerator = "Ablative Armor Generator";
        public const string AblativeFieldProjector = "Ablative Armor Generator";
        public const string AdaptableEnergyWeapons = "Adaptable Energy Weapons";
        public const string AdaptiveShieldModulator = "Adaptive Shield Modulator";
        public const string AdditionalPropulsionSystemSporeHubDrive = "Additional Propulsion System (Displacement-Activated Spore Hub Drive)";
        public const string AdditionalPropulsionSystemProtostarDrive = "Additional Propulsion System (Protostar Drive)";
        public const string AdditionalPropulsionSystemQuantumSlipstreamDrive = "Additional Propulsion System (Quantum Slipstream Drive)";
        public const string AdvancedEmergencyCrewHolograms = "Advanced Emergency Crew Holograms";
        public const string AdvancedSickbay = "Advanced Sickbay";
        public const string AdvancedResearchFacilities = "Advanced Research Facilities";
        public const string AdvancedSensorSuites = "Advanced Sensor Suites";
        public const string AdvancedShields = "Advanced Shields";
        public const string AdvancedTransporters = "Advanced Transporters";
        public const string AnnularConfinementJacketing = "Annular Confinement Jacketing";
        public const string AutomatedDefences = "Automated Defences";
        public const string AutomaticReturn = "Automatic Return";
        public const string BackupEPSConduits = "Backup EPS Conduits";
        public const string CaptainsYacht = "Captain's Yacht";
        public const string CloakedMines = "Cloaked Mines";
        public const string CloakingDevice = "Cloaking Device";
        public const string ClusterTorpedoes = "Cluster Torpedoes";
        public const string CommandShip = "Command Ship";
        public const string DedicatedPersonnelCommand = "Dedicated Personnel (Command)";
        public const string DedicatedPersonnelConn = "Dedicated Personnel (Conn)";
        public const string DedicatedPersonnelEngineering = "Dedicated Personnel (Engineering)";
        public const string DedicatedPersonnelSecurity = "Dedicated Personnel (Security)";
        public const string DedicatedPersonnelScience = "Dedicated Personnel (Science)";
        public const string DedicatedPersonnelMedical= "Dedicated Personnel (Medical)";
        public const string DedicatedSubspaceTransceiverArray = "Dedicated Subspace Transceiver Array";
        public const string DeluxeGalley = "Deluxe Galley";
        public const string DiplomaticSuites = "Diplomatic Suites";
        public const string DualEnvironment = "Dual Environment";
        public const string ElectronicWarfareSystems = "Electronic Warfare Systems";
        public const string EmergencyMedicalHologram = "Emergency Medical Hologram";
        public const string ExpandedEmergencyMedicalFacilities = "Expanded Emergency Medical Facilities";
        public const string ExpandedMunitions = "Expanded Munitions";
        public const string ExpansiveDepartmentCommand = "Expansive Department (Command)";
        public const string ExpansiveDepartmentConn = "Expansive Department (Conn)";
        public const string ExpansiveDepartmentEngineering = "Expansive Department (Engineering)";
        public const string ExpansiveDepartmentSecurity = "Expansive Department (Security)";
        public const string ExpansiveDepartmentScience = "Expansive Department (Science)";
        public const string ExpansiveDepartmentMedical = "Expansive Department (Medical)";
        public const string ExtendedSensorRange = "Extended Sensor Range";
        public const string ExtensiveAutomation = "Extensive Automation";
        public const string ExtensiveMedicalLaboratories = "Extensive Medical Laboratories";
        public const string ExtensiveShuttlebays = "Extensive Shuttlebays";
        public const string FastTargetingSystems = "Fast Targeting Systems";
        public const string HighIntensityEnergyWeapons = "High-Intensity Energy Weapons";
        public const string HighPowerTractorBeam = "High-Power Tractor Beam";
        public const string HighResolutionSensors = "High-Resolution Sensors";
        public const string ImprovedDamageControl = "Improved Damage Control";
        public const string ImprovedHullIntegrity = "Improved Hull Integrity";
        public const string ImprovedImpulseDrive = "Improved Impulse Drive";
        public const string ImprovedPowerSystems = "Improved Power Systems";
        public const string ImprovedProbeBay = "Improved Probe Bay";
        public const string ImprovedReactionControlSystem = "Improved Reaction Control System";
        public const string ImprovedShieldRecharge = "Improved Shield Recharge";
        public const string ImprovedWarpDrive = "Improved Warp Drive";
        public const string IndependentWeaponPower = "Independent Weapon Power";
        public const string IndustrialReplicators = "Industrial Replicators";
        public const string Minelayer = "Minelayer";
        public const string ModularCargoBays = "Modular Cargo Bays";
        public const string ModularLaboratories = "Modular Laboratories";
        public const string PointDefenseSystem = "Point Defense System";
        public const string RapidFireTorpedoLauncher = "Rapid-Fire Torpedo Launcher";
        public const string ReducedSensorSilhouette = "Reduced Sensor Silhouette";
        public const string RedundantSystemsComms = "Redundant Systems (Comms)";
        public const string RedundantSystemsComputers = "Redundant Systems (Computers)";
        public const string RedundantSystemsEngines = "Redundant Systems (Engines)";
        public const string RedundantSystemsSensors = "Redundant Systems (Sensors)";
        public const string RedundantSystemsStructure = "Redundant Systems (Structure)";
        public const string RedundantSystemsWeapons = "Redundant Systems (Weapons)";
        public const string RegenerativeHull = "Regenerative Hull";
        public const string RuggedDesign = "Rugged Design";
        public const string SecondaryReactors = "Secondary Reactors";
        public const string SelfReplicatingMines = "Self-Replicating Mines";
        public const string SiphoningShields = "Siphoning Shields";
        public const string SophisticatedAstrometricsFacilities = "Sophisticated Astrometrics Facilities";
        public const string TachyonDetectionField = "Tachyon Detection Field";
        public const string TraceablePayloadSystem = "Traceable Payload System";
        public const string TransportInhibitors = "Transport Inhibitors";
        public const string VariableGeometryWarpField = "Variable Geometry Warp Field";
        public const string VersatileTractorBeam = "Versatile Tractor Beam";
        public const string WormholeRelaySystem = "Wormhole Relay System";
    }

    public static class StarshipSpecialRuleName
    {
        public const string AbundantPersonnel = "Abundant Personnel";
        public const string AquariusEscort = "Aquarius Escort";
        public const string ClassifiedDesign = "Classified Design";
        public const string CompactVessel = "Compact Vessel";
        public const string EncounterTheStrange = "Encounter the Strange";
        public const string ExperimentalVessel = "Experimental Vessel";
        public const string FarFromHome = "Far From Home";
        public const string FourNacelleStability = "Four-Nacelle Stability";
        public const string GrapplerCable = "Grappler Cable";
        public const string LargerCrew = "Larger Crew";
        public const string LandingGear = "Landing Gear";
        public const string MissionOfMercy = "Mission of Mercy";
        public const string MissionPod = "Mission Pod";
        public const string PolarizedHullPlating = "Polarized Hull Plating";
        public const string PeakPerformance = "Peak Performance";
        public const string PreferentialTargeting = "Preferential Targeting";
        public const string PrestigiousPosting = "Prestigious Posting";
        public const string Prototype = "Prototype";
        public const string QuantumSlipstreamBurstDrive = "Quantum Slipstream Burst Drive";
        public const string ReadyForBattle = "Ready for Battle";
        public const string Reliable = "Reliable";
        public const string SaucerSeperation = "Saucer Seperation";
        public const string SaucerSeperationAndReconnection = "Saucer Seperation and Reconnection";
        public const string SpecializedShuttlebay = "Specialized Shuttlebay";
        public const string TheLastGeneration = "The Last Generation";
        public const string UpgradedSystem = "Upgraded System";
    }

    public static class NpcSpecialRuleName
    {
        public const string ImmuneToFear = "Immune to Fear";
        public const string ImmuneToPain = "Immune to Pain";
        public const string IntensiveTraining = "Intensive Training";
    }
}
