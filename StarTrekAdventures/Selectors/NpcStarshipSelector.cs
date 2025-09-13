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
    };
}
