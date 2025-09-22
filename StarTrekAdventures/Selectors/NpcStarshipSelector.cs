﻿using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class NpcStarshipSelector : INpcStarshipSelector
{
    private readonly IStarshipSpecialRuleSelector _starshipSpecialRuleSelector;
    private readonly IStarshipTalentSelector _starshipTalentSelector;
    private readonly IStarshipWeaponSelector _starshipWeaponSelector;

    public NpcStarshipSelector(
        IStarshipSpecialRuleSelector starshipSpecialRuleSelector, 
        IStarshipTalentSelector starshipTalentSelector,
        IStarshipWeaponSelector starshipWeaponSelector)
    {
        _starshipSpecialRuleSelector = starshipSpecialRuleSelector;
        _starshipTalentSelector = starshipTalentSelector;
        _starshipWeaponSelector = starshipWeaponSelector;
    }

    public NpcStarship GetNpcStarship(string name)
    {
        var selectedNpc = GetAllNpcStarshipsList().First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        return CreateNpcStarship(selectedNpc);
    }

    public List<NpcStarship> GetAllNpcStarships()
    {
        var selectedNpcs = GetAllNpcStarshipsList();

        var npcs = new List<NpcStarship>();

        foreach (var selectedNpc in selectedNpcs)
        {
            npcs.Add(CreateNpcStarship(selectedNpc));
        }

        return npcs;
    }

    private static NpcStarship CreateNpcStarship(NpcStarship selectedNpc)
    {
        var npc = new NpcStarship(selectedNpc);

        npc.SetResistance();
        npc.SetShields();
        npc.SetCrewSupport();
        npc.SetSmallCraftReadiness();

        if (npc.GrapplerCableStrength > 0)
        {
            npc.Attacks.Add(new StarshipWeapon { Name = StarshipWeaponName.GrapplerCable, Damage = npc.GrapplerCableStrength, IsTractorBeam = true });
        }

        if (npc.TractorBeamStrength > 0)
        {
            npc.Attacks.Add(new StarshipWeapon { Name = StarshipWeaponName.TractorBeam, Damage = npc.TractorBeamStrength, IsTractorBeam = true });
        }

        foreach (var weapon in npc.Attacks)
            weapon.SetEffect(npc);

        return npc;
    }

    private List<NpcStarship> GetAllNpcStarshipsList()
    {
        var allNpcs = new List<NpcStarship>();
        allNpcs.AddRange(GetShowStarships());
        allNpcs.AddRange(GetStarfleetStarships());
        allNpcs.AddRange(GetKlingonStarships());
        allNpcs.AddRange(GetRomulanStarships());
        allNpcs.AddRange(GetCardassianStarships());
        allNpcs.AddRange(GetFerengiStarships());
        allNpcs.AddRange(GetDominionStarships());
        return allNpcs;
    }

    private IEnumerable<NpcStarship> GetShowStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "USS Enterprise NCC-1701-D",
            Description = new List<string>
            {
                "After Kirk’s Enterprise was destroyed, and the subsequent Enterprise-A was decommissioned, Starfleet continued the legacy of ships named Enterprise. In the 2360s, this legacy was borne by the Enterprise-D, under the command of Jean-Luc Picard. As the Federation’s flagship, she bears Starfleet’s best and brightest, and is one of the most prestigious postings in Starfleet.",
                "The Enterprise-D entered service in a time of relative peace, witnessing the conclusion of the Federation–Cardassian War and the signing of the treaty that created the Demilitarized Zone, but she also faced new challenges and new threats. Her crew had the first known encounters with an entity from the Q Continuum. She was involved in numerous confrontations with the Romulans, the first such encounters with Romulan forces in nearly a century. She made first official contact with the Borg, and was pivotal in their defeat after the disastrous Battle of Wolf 359."
            },
            CrewQualityEnum = CrewQuality.Talented,
            MissionProfile = MissionProfileName.MultiroleExplorer,
            Traits = new List<string>
            {
                "Federation Starship",
                "Galaxy class",
                "A City in Space",
                "Flagship of the Federation",
                "Fifth to Bear the Name “Enterprise”",
                "Legendary"
            },
            Scale = 6,
            Systems = new StarshipSystems { Comms = 9, Computers = 10, Engines = 10, Sensors = 9, Structure = 10, Weapons = 10 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 2, Medicine = 3, Science = 3 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserArrays),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.CaptainsYacht),
                _starshipTalentSelector.GetTalent(StarshipTalentName.DiplomaticSuites),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ExtensiveShuttlebays),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ModularLaboratories),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RedundantSystemsStructure),
                _starshipTalentSelector.GetTalent(StarshipTalentName.SecondaryReactors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.AbundantPersonnel),
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.PrestigiousPosting),
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.SaucerSeperation)
            },
            Source = BookSource.NextGenerationCrewPack1stEdition
        },
        new()
        {
            Name = "La Sirena",
            Description = new List<string>
            {
                "Launched from the Hatzeplats colony’s Kaplan shipyards in 2298 and originally named Sheina Meidel, the vessel that would become La Sirena had an unremarkable career as an interstellar merchant vessel serving the colony worlds of Hatzeplats, Ergets Andersh, and Fargesn through the first half of the 24th century. The vessel was transferred to the Yoyodyne Propulsion Systems team at Luna for testing of newly developed warp field generation technologies following the discovery of subspace ruptures formed by warp travel. Rather than being scrapped after decades of testing, the vessel was then given to Cristóbal Rios after his retirement from Starfleet in order to begin a career as a civilian merchant captain. Rios brought the vessel into line with modern Starfleet standards and installed holoemitters across the entire interior volume of the vessel to allow holographic crewmembers to assist him in the operations of the vessel.",
            },
            CrewQualityEnum = CrewQuality.Talented,
            MissionProfile = MissionProfileName.MultiroleExplorer,
            Traits = new List<string>
            {
                "Federation Starship",
                "Kaplan F17 Speed Freighter",
                "Civilian Transport",
            },
            Scale = 2,
            Systems = new StarshipSystems { Comms = 6, Computers = 8, Engines = 10, Sensors = 8, Structure = 8, Weapons = 11 },
            Departments = new Departments { Command = 3, Conn = 4, Engineering = 4, Security = 2, Medicine = 1, Science = 1 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserArrays),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 1,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.AdvancedEmergencyCrewHolograms),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign)
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.CompactVessel),
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.LandingGear),
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.Reliable)
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition
        },
    };

    private IEnumerable<NpcStarship> GetStarfleetStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "Aquarius-class Escort",
            Description = new List<string>
            {
                "The Aquarius escort is a small starship embedded in a docking slip at the aft of the Odyssey. The Aquarius is an independent starship and can travel at warp, though its endurance is limited, and it is not designed to go on extended missions. When deployed, the Aquarius can be an NPC ally starship or can be commanded by a player at the gamemaster’s discretion. Deploying the Aquarius class functions the same way as launching a small craft, though it does not take up any of the ship’s Small Craft Capacity.",
                "As it exists as part of its parent ship, the Aquarius class does not have a separate Crew Support rating. It also does not have talents, though it can be improved with character advancement.)"
            },
            CrewQualityEnum = CrewQuality.None,
            Traits = new List<string>
            {
                "Federation Starship",
                "Aquarius class",
                "Escort Vessel"
            },
            Scale = 2,
            Systems = new StarshipSystems { Comms = 10, Computers = 10, Engines = 8, Sensors = 10, Structure = 6, Weapons = 10 },
            Departments = new Departments { Command = 1, Conn = 4, Engineering = 2, Security = 4, Medicine = 1, Science = 2 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserArrays),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserCannons),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            Talents = new List<StarshipTalent>(),
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.CompactVessel)
            },
            NoCrewSupport = true,
            Source = BookSource.GameToolkit
        },
        new()
        {
            Name = "Constitution-Class",
            Description = new List<string>
            {
                "In the 23rd century, Constitution-class vessels were Starfleet’s primary exploration vessels. The following represents a standard starship of the class."
            },
            CrewQualityEnum = CrewQuality.Talented,
            MissionProfile = MissionProfileName.MultiroleExplorer,
            Traits = new List<string>
            {
                "Federation Starship",
                "Constitution class"
            },
            Scale = 4,
            Systems = new StarshipSystems { Comms = 7, Computers = 8, Engines = 8, Sensors = 8, Structure = 7, Weapons = 7 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 3, Medicine = 2, Science = 3 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedHullIntegrity),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ModularLaboratories),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RedundantSystemsEngines),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.SaucerSeperation)
            }
        },
        new()
        {
            Name = "Galaxy-Class",
            Description = new List<string>
            {
                "In the mid-24th century, Galaxy-class vessels were designed to be deep space explorers and often served as an admiral’s flagship. The following represents a standard starship of the class."
            },
            CrewQualityEnum = CrewQuality.Talented,
            MissionProfile = MissionProfileName.MultiroleExplorer,
            Traits = new List<string>
            {
                "Federation Starship",
                "Galaxy class",
                "A City in Space"
            },
            Scale = 6,
            Systems = new StarshipSystems { Comms = 9, Computers = 10, Engines = 10, Sensors = 10, Structure = 10, Weapons = 10 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 2, Medicine = 3, Science = 3 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserArrays),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.AdvancedResearchFacilities),
                _starshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedPowerSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ModularLaboratories),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RedundantSystemsStructure),
                _starshipTalentSelector.GetTalent(StarshipTalentName.SecondaryReactors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.AbundantPersonnel),
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.SaucerSeperation)
            }
        },
    };

    private IEnumerable<NpcStarship> GetKlingonStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "D7 Battlecruiser",
            Description = new List<string>
            {
                "In the 23rd century, the D7 battlecruiser was the mainstay of the Klingon Defense Force."
            },
            CrewQualityEnum = CrewQuality.Proficient,
            MissionProfile = MissionProfileName.Battlecruiser,
            Traits = new List<string>
            {
                "Klingon Starship",
                "Symbol of Klingon Unity"
            },
            Scale = 4,
            Systems = new StarshipSystems { Comms = 7, Computers = 7, Engines = 8, Sensors = 7, Structure = 8, Weapons = 10 },
            Departments = new Departments { Command = 2, Conn = 3, Engineering = 2, Security = 5, Medicine = 1, Science = 2 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorCannons),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.BackupEPSConduits),
                _starshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                _starshipTalentSelector.GetTalent(StarshipTalentName.FastTargetingSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
        },
        new()
        {
            Name = "B’rel-class Bird of Prey",
            Description = new List<string>
            {
                "The B’rel class is one of the most common types of Klingon scout or raider encountered in the Alpha and Beta Quadrants."
            },
            CrewQualityEnum = CrewQuality.Proficient,
            MissionProfile = MissionProfileName.Patrol,
            Traits = new List<string>
            {
                "Klingon Starship",
                "B’rel class",
                "Bird of Prey",
                "Agile Raider"
            },
            Scale = 3,
            Systems = new StarshipSystems { Comms = 8, Computers = 7, Engines = 9, Sensors = 8, Structure = 7, Weapons = 9 },
            Departments = new Departments { Command = 1, Conn = 4, Engineering = 1, Security = 5, Medicine = 2, Science = 2 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorCannons),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 2,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                _starshipTalentSelector.GetTalent(StarshipTalentName.FastTargetingSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.LandingGear)
            }
        },
    };

    private IEnumerable<NpcStarship> GetRomulanStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "T’Liss-class Bird of Prey",
            Description = new List<string>
            {
                "The T’Liss class was the primary scout ship type of the 23rd century Romulan Navy."
            },
            CrewQualityEnum = CrewQuality.Talented,
            MissionProfile = MissionProfileName.PathfinderAndReconnaissanceOperations,
            Traits = new List<string>
            {
                "Romulan Bird of Prey",
                "Experimental"
            },
            Scale = 4,
            Systems = new StarshipSystems { Comms = 6, Computers = 8, Engines = 8, Sensors = 9, Structure = 7, Weapons = 9 },
            Departments = new Departments { Command = 2, Conn = 4, Engineering = 3, Security = 3, Medicine = 1, Science = 2 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PlasmaTorpedoes),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ElectronicWarfareSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedReactionControlSystem),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ReducedSensorSilhouette),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.Prototype)
            }
        },
        new()
        {
            Name = "D’Deridex-class Warbird",
            Description = new List<string>
            {
                "The mainstay of the mid-to-late 24th century Romulan fleet, the D’Deridex-class warbirds were more than a match for most Federation and Klingon starships of the time."
            },
            CrewQualityEnum = CrewQuality.Talented,
            MissionProfile = MissionProfileName.EspionageOrIntelligence,
            Traits = new List<string>
            {
                "Romulan Starship",
                "Imposing"
            },
            Scale = 7,
            Systems = new StarshipSystems { Comms = 9, Computers = 10, Engines = 10, Sensors = 11, Structure = 11, Weapons = 9 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 4, Medicine = 1, Science = 3 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PlasmaTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ElectronicWarfareSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.FastTargetingSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedDamageControl),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ReducedSensorSilhouette),
                _starshipTalentSelector.GetTalent(StarshipTalentName.SecondaryReactors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                _starshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.AbundantPersonnel)
            }
        },
    };

    private IEnumerable<NpcStarship> GetCardassianStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "Galor-class Cruiser",
            Description = new List<string>
            {
                "The main battle cruiser of the Cardassian navy, a bit dated as of the mid- 24th century, but capable enough to suppress most resistance."
            },
            CrewQualityEnum = CrewQuality.Proficient,
            MissionProfile = MissionProfileName.Patrol,
            Traits = new List<string>
            {
                "Cardassian Starship",
                "Galor class"
            },
            Scale = 4,
            Systems = new StarshipSystems { Comms = 9, Computers = 8, Engines = 9, Sensors = 8, Structure = 8, Weapons = 9 },
            Departments = new Departments { Command = 2, Conn = 3, Engineering = 2, Security = 4, Medicine = 2, Science = 2 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorSpinalLance),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            }
        },
    };

    private IEnumerable<NpcStarship> GetFerengiStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "D’Kora-class Marauder",
            Description = new List<string>
            {
                "In the 24th century, the D’Kora class was the largest Ferengi starship in the Ferengi navy, though a number were sold to independent merchant-captains as well."
            },
            CrewQualityEnum = CrewQuality.Proficient,
            MissionProfile = MissionProfileName.Flagship,
            Traits = new List<string>
            {
                "Ferengi Marauder",
                "D’Kora class",
                "The Best Latinum Can Buy"
            },
            Scale = 5,
            Systems = new StarshipSystems { Comms = 9, Computers = 8, Engines = 10, Sensors = 9, Structure = 10, Weapons = 7 },
            Departments = new Departments { Command = 4, Conn = 1, Engineering = 3, Security = 3, Medicine = 1, Science = 3 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.ElectromagneticCannons),
            },
            TractorBeamStrength = 4,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.AdvancedShields),
                _starshipTalentSelector.GetTalent(StarshipTalentName.DeluxeGalley),
                _starshipTalentSelector.GetTalent(StarshipTalentName.DiplomaticSuites),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ElectronicWarfareSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
            }
        },
    };

    private IEnumerable<NpcStarship> GetDominionStarships() => new List<NpcStarship>
    {
        new()
        {
            Name = "Jem’Hadar Attack Ship",
            Description = new List<string>
            {
                "The primary fighter of the Dominion, used by the Jem’Hadar to strike fear into the hearts of their adversaries."
            },
            CrewQualityEnum = CrewQuality.Talented,
            Traits = new List<string>
            {
                "Dominion Warship"
            },
            Scale = 3,
            Systems = new StarshipSystems { Comms = 7, Computers = 7, Engines = 8, Sensors = 10, Structure = 6, Weapons = 10 },
            Departments = new Departments { Command = 1, Conn = 5, Engineering = 2, Security = 4, Medicine = 1, Science = 1 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhasedPoleronBeamBanks),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorCannons),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 2,
            Talents = new List<StarshipTalent>
            {
                new()
                {
                    Name = "Anti-Cloak Sensors",
                    Description = new List<string>
                    {
                        "Dominion vessels are fitted with antiproton beam scanners and long-range tachyon scanners, that allow them to reliably detect cloaked vessels. Dominion vessels may always attack cloaked ships, though the Difficulty of attacks against a cloaked ship increases by 1."
                    }
                },
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedImpulseDrive),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedReactionControlSystem)
            }
        },
        new()
        {
            Name = "Jem’Hadar Battlecruiser",
            Description = new List<string>
            {
                "A powerful warship capable of subjugating planets or standing in battle against the starships of most opponents."
            },
            CrewQualityEnum = CrewQuality.Talented,
            Traits = new List<string>
            {
                "Dominion Warship"
            },
            Scale = 6,
            Systems = new StarshipSystems { Comms = 9, Computers = 8, Engines = 9, Sensors = 10, Structure = 12, Weapons = 12 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 5, Medicine = 0, Science = 1 },
            Attacks = new List<StarshipWeapon>
            {
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhasedPoleronBeamArray),
                _starshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                _starshipTalentSelector.GetTalent(StarshipTalentName.AdvancedTransporters),
                new()
                {
                    Name = "Anti-Cloak Sensors",
                    Description = new List<string>
                    {
                        "Dominion vessels are fitted with antiproton beam scanners and long-range tachyon scanners, that allow them to reliably detect cloaked vessels. Dominion vessels may always attack cloaked ships, though the Difficulty of attacks against a cloaked ship increases by 1."
                    }
                },
                _starshipTalentSelector.GetTalent(StarshipTalentName.BackupEPSConduits),
                _starshipTalentSelector.GetTalent(StarshipTalentName.HighIntensityEnergyWeapons),
                _starshipTalentSelector.GetTalent(StarshipTalentName.ImprovedPowerSystems),
                _starshipTalentSelector.GetTalent(StarshipTalentName.RapidFireTorpedoLauncher),
            }
        },
    };
}
