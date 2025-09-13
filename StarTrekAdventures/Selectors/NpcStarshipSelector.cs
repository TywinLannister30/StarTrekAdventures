using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class NpcStarshipSelector
{
    public static NpcStarship GetNpcStarship(string name)
    {
        var selectedNpc = NcpStarships.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        return CreateNpcStarship(selectedNpc);
    }

    internal static List<NpcStarship> GetAllNpcStarships()
    {
        var selectedNpcs = NcpStarships;

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

    private static readonly List<NpcStarship> NcpStarships = new()
    {
        // STARFLEET & FEDERATION STARSHIPs
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedHullIntegrity),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ModularLaboratories),
                StarshipTalentSelector.GetTalent(StarshipTalentName.RedundantSystemsEngines),
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                StarshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.SaucerSeperation)
            }
        },
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserArrays),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.AdvancedResearchFacilities),
                StarshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedPowerSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ModularLaboratories),
                StarshipTalentSelector.GetTalent(StarshipTalentName.RedundantSystemsStructure),
                StarshipTalentSelector.GetTalent(StarshipTalentName.SecondaryReactors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                StarshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.AbundantPersonnel),
                StarshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.SaucerSeperation)
            }
        },

        // KLINGON STARSHIPs
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorCannons),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.BackupEPSConduits),
                StarshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                StarshipTalentSelector.GetTalent(StarshipTalentName.FastTargetingSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
        },
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorCannons),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 2,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                StarshipTalentSelector.GetTalent(StarshipTalentName.FastTargetingSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                StarshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.LandingGear)
            }
        },

        // ROMULAN STARSHIPS
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PlasmaTorpedoes),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ElectronicWarfareSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedReactionControlSystem),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ReducedSensorSilhouette),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                StarshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.Prototype)
            }
        },
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PlasmaTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.CloakingDevice),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ElectronicWarfareSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.FastTargetingSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedDamageControl),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ReducedSensorSilhouette),
                StarshipTalentSelector.GetTalent(StarshipTalentName.SecondaryReactors),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                StarshipSpecialRuleSelector.GetSpecialRule(StarshipSpecialRuleName.AbundantPersonnel)
            }
        },

        // CARDASSIAN STARSHIPS
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorSpinalLance),
            },
            TractorBeamStrength = 3,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            }
        },

        // FERENGI STARSHIPS
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.ElectromagneticCannon),
            },
            TractorBeamStrength = 4,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.AdvancedShields),
                StarshipTalentSelector.GetTalent(StarshipTalentName.DeluxeGalley),
                StarshipTalentSelector.GetTalent(StarshipTalentName.DiplomaticSuites),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ElectronicWarfareSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.HighResolutionSensors),
            }
        },

        // DOMINION STARSHIPS
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhasedPoleronBeamBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.DisruptorCannons),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
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
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedImpulseDrive),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedReactionControlSystem)
            }
        },
        new NpcStarship
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
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhasedPoleronBeamArray),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            },
            TractorBeamStrength = 5,
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.AdvancedTransporters),
                new()
                {
                    Name = "Anti-Cloak Sensors",
                    Description = new List<string>
                    {
                        "Dominion vessels are fitted with antiproton beam scanners and long-range tachyon scanners, that allow them to reliably detect cloaked vessels. Dominion vessels may always attack cloaked ships, though the Difficulty of attacks against a cloaked ship increases by 1."
                    }
                },
                StarshipTalentSelector.GetTalent(StarshipTalentName.BackupEPSConduits),
                StarshipTalentSelector.GetTalent(StarshipTalentName.HighIntensityEnergyWeapons),
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedPowerSystems),
                StarshipTalentSelector.GetTalent(StarshipTalentName.RapidFireTorpedoLauncher),
            }
        },
    };
}
