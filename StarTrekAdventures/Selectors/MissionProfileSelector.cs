using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class MissionProfileSelector
{
    public static MissionProfile ChooseMissionProfile(Starship starship)
    {
        foreach (var specialRule in starship.SpecialRules)
        {
            if (!string.IsNullOrEmpty(specialRule.MustTakeMissionProfile))
            {
                return MissionProfiles.First(x => x.Name == specialRule.MustTakeMissionProfile);
            }
        }

        var weightedMissionProfileList = new WeightedList<MissionProfile>();

        foreach (var missionProfile in MissionProfiles)
        {
            if (starship.SuggestedMissionProfiles.Contains(missionProfile.Name))
                weightedMissionProfileList.AddEntry(missionProfile, 10);
            else
                weightedMissionProfileList.AddEntry(missionProfile, 1);
        }

        return weightedMissionProfileList.GetRandom();
    }

    internal static List<MissionProfile> GetAllMissionProfiles()
    {
        return MissionProfiles;
    }

    internal static MissionProfile GetMissionProfile(string name)
    {
        return MissionProfiles.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    private static readonly List<MissionProfile> MissionProfiles = new()
    {
        new()
        {
            Name = MissionProfileName.Battlecruiser,
            Description = "In the mid-23rd century, the lessons of the Earth- Romulan War are still firmly in the minds of those on the core Federation worlds, and some vessels are outfitted as vessels of war in case hostilities begin with the Klingon or Romulan Empires. A similar push to develop heavy combat vessels arose during the Borg crisis and Dominion War in the 2360s and 2370s. These vessels are rare in Starfleet, and those outfitted as such rarely stray far from important starbases or the worlds they guard.",
            Systems = new StarshipSystems { Weapons = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 2, Security = 3, Medicine = 1, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AblativeArmor,
                StarshipTalentName.CommandShip,
                StarshipTalentName.FastTargetingSystems,
                StarshipTalentName.ImprovedDamageControl,
                StarshipTalentName.RapidFireTorpedoLauncher
            }
        },
        new()
        {
            Name = MissionProfileName.CivilianMerchantMarine,
            Description = "Many decommissioned Starfleet vessels find their way into the Merchant Marines, an active reserve where starships and personnel go to continue service to the Federation in a less formal and less risky way. Merchant Marines may be called upon by Starfleet to serve as logistical vessels in times of need, and many of these starships act in the place of active service Starfleet vessels when no others are available. Most other spacefaring civilizations have similar services.",
            Systems = new StarshipSystems { Structure = 1 },
            Departments = new Departments
            {
                Command = 1, Conn = 2, Engineering = 3, Security = 3, Medicine = 2, Science = 1
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.BackupEPSConduits,
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.ImprovedPowerSystems,
                StarshipTalentName.RuggedDesign
            },
            Source = BookSource.GameToolkit
        },
        new()
        {
            Name = MissionProfileName.ColonySupport,
            Description = "Vessels equipped to assist colonies in their initial stages provide necessary supplies, as well as scientific and medical backup to new colony worlds, the kinds of places that deal with unknowns which may still present themselves years after initial settlement.",
            Systems = new StarshipSystems { Comms = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 2, Security = 2, Medicine = 3, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AdvancedSickbay,
                StarshipTalentName.AdvancedTransporters,
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.HighPowerTractorBeam
            },
            Source = BookSource.GameToolkit
        },
        new()
        {
            Name = MissionProfileName.CrisisAndEmergencyResponse,
            Description = "These vessels are equipped to respond quickly to a crisis, whatever it may be. Normally capable of supporting expansive shuttlebays, they can deploy large quantities of personnel or cargo to, or evacuate large populations from, disaster areas. Such vessels also serve as hospital ships and troop transport during conflicts.",
            Systems = new StarshipSystems { Sensors = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 1, Security = 2, Medicine = 3, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AdvancedSickbay,
                StarshipTalentName.EmergencyMedicalHologram,
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.ModularLaboratories
            }
        },
        new()
        {
            Name = MissionProfileName.EspionageOrIntelligence,
            Description = "Vessels equipped for espionage are rare in active Starfleet service, but are used by member cultures within the Federation, and by other polities such as the Romulan Empire and Cardassian Union, whose intelligence agencies often employ dedicated vessels (whether or not they are legally permitted to), and in many cultures, intelligence agencies may commandeer existing vessels for their needs. These vessels are often equipped with highly sensitive monitoring devices, enhanced sensors, and stealth systems (though stopping short of actual cloaking devices for Starfleet vessels). These vessels range close to—and sometimes beyond—foreign borders. Serving on these ships is often a dangerous and thankless proposition.",
            Systems = new StarshipSystems { Sensors = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 1, Security = 3, Medicine = 1, Science = 3
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.ElectronicWarfareSystems,
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ImprovedReactionControlSystem,
                StarshipTalentName.ReducedSensorSilhouette
            }
        },
        new()
        {
            Name = MissionProfileName.Flagship,
            Description = "Flagships are a specialized form of command ship, with a dedicated flag bridge or strategic operations center within the vessel. These ships can act as a mobile fleet headquarters, with systems and personnel dedicated to ensuring the operations of whole fleets, or even serving as a vessel for the continuity of command should disaster strike.",
            Systems = new StarshipSystems { Comms = 1 },
            Departments = new Departments
            {
                Command = 3, Conn = 1, Engineering = 2, Security = 3, Medicine = 1, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.DedicatedSubspaceTransceiverArray,
                StarshipTalentName.DiplomaticSuites,
                StarshipTalentName.RedundantSystemsComms
            }
        },
        new()
        {
            Name = MissionProfileName.LogisticalOrQuartermaster,
            Description = "These vessels provide the backbone of any fleet, even in the era of the replicator. Whenever vital equipment or personnel need to be moved, vessels like this are often central to ensuring that those tools and people get where they’re needed most. In Starfleet in particular, these vessels also serve as a second line of operations following the important business of first contact, providing material and infrastructure support to worlds recently contacted or who seek membership in the Federation.",
            Systems = new StarshipSystems { Engines = 1 },
            Departments = new Departments
            {
                Command = 3, Conn = 2, Engineering = 3, Security = 2, Medicine = 1, Science = 1
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.ImprovedWarpDrive,
                StarshipTalentName.RuggedDesign
            },
            Source = BookSource.GameToolkit
        },
        new()
        {
            Name = MissionProfileName.MultiroleExplorer,
            Description = "Many of Starfleet’s most renowned and revered vessels have been jack-of-all-trades ships, rather than specialized for a single type of mission. This versatility allowed the likes of Jonathan Archer, Christopher Pike, James Kirk, and Jean-Luc Picard to explore strange new worlds, seek out new life and new civilizations, and boldly go where no one has gone before.",
            AnyOneSystem = true,
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 2, Security = 2, Medicine = 2, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.ImprovedHullIntegrity,
                StarshipTalentName.ImprovedPowerSystems,
                StarshipTalentName.RedundantSystemsComms,
                StarshipTalentName.RedundantSystemsComputers,
                StarshipTalentName.RedundantSystemsStructure,
                StarshipTalentName.RedundantSystemsSensors,
                StarshipTalentName.RedundantSystemsEngines,
                StarshipTalentName.RedundantSystemsWeapons,
                StarshipTalentName.RuggedDesign,
                StarshipTalentName.SecondaryReactors
            }
        },
        new()
        {
            Name = MissionProfileName.PathfinderAndReconnaissanceOperations,
            Description = "Long-range missions often employ the most advanced stellar cartography and astrometric facilities, allowing them to chart and navigate unknown regions of space more effectively, especially where spatial distortions make those regions difficult to navigate. These vessels are relied upon for extended exploratory missions, intelligence- gathering military operations, and risky “pathfinder” operations into the unknown.",
            Systems = new StarshipSystems { Engines = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 3, Engineering = 2, Security = 2, Medicine = 1, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ImprovedReactionControlSystem,
                StarshipTalentName.ImprovedWarpDrive,
                StarshipTalentName.RuggedDesign
            }
        },
        new()
        {
            Name = MissionProfileName.Patrol,
            Description = "Patrol vessels are dedicated to acting as peacekeepers in regions of space where hostility is not only possible, but likely. These vessels tend to operate along borders with other polities, and act as picket vessels during fleet actions. In times of peace, patrol vessels can be assigned to survey missions, or operate patrols against pirates, smugglers, and similar dangers.",
            Systems = new StarshipSystems { Sensors = 1 },
            Departments = new Departments
            {
                Command = 1, Conn = 3, Engineering = 1, Security = 3, Medicine = 2, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.FastTargetingSystems,
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ImprovedPowerSystems
            }
        },
        new()
        {
            Name = MissionProfileName.ReserveFleet,
            Description = "These starships are often older vessels that have been withdrawn from active duty and are equipped as standby vessels in case of disasters both natural and manufactured. Some new ships are also outfitted in this manner, but are classified as “fleet support,” assisting flotillas in deployments away from the supply lines of core worlds.",
            Systems = new StarshipSystems { Structure = 1 },
            Departments = new Departments
            {
                Command = 1, Conn = 2, Engineering = 3, Security = 3, Medicine = 2, Science = 1
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AdvancedSickbay,
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.ImprovedHullIntegrity,
                StarshipTalentName.SecondaryReactors
            },
            Source = BookSource.GameToolkit
        },
        new()
        {
            Name = MissionProfileName.ScientificAndSurveyOperations,
            Description = "Starfleet’s mission of exploration and discovery means that it employs many vessels for purely scientific missions, studying unknown phenomena, or supporting ongoing research. While most Federation starships are expected to have at least some capacity for scientific endeavor, some vessels are outfitted specifically for such missions.",
            Systems = new StarshipSystems { Computers = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 1, Engineering = 3, Security = 1, Medicine = 2, Science = 3
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AdvancedResearchFacilities,
                StarshipTalentName.AdvancedSensorSuites,
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ModularLaboratories
            }
        },
        new()
        {
            Name = MissionProfileName.StrategicAndDiplomaticOperations,
            Description = "Vessels equipped for this profile are often placed under the command of flag officers and used as the heart of squadrons, battlegroups, and even whole fleets. These ships, and the prestige and standing that accompanies them, are also used for major diplomatic undertakings where they can serve as mobile embassies and represent the best of the Federation.",
            Systems = new StarshipSystems { Comms = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 1, Security = 2, Medicine = 2, Science = 3
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.DiplomaticSuites,
                StarshipTalentName.ElectronicWarfareSystems,
                StarshipTalentName.ExtensiveShuttlebays
            }
        },
        new()
        {
            Name = MissionProfileName.TacticalOperations,
            Description = "While Starfleet is not a military, the defense of the Federation is one of Starfleet’s responsibilities, and Starfleet has been required to prepare for war on numerous occasions. Thus, many ships are equipped for peacekeeping and military actions, though the number of vessels outfitted in this manner varies depending on the politics of the day.",
            Systems = new StarshipSystems { Weapons = 1 },
            Departments = new Departments
            {
                Command = 2, Conn = 2, Engineering = 2, Security = 3, Medicine = 2, Science = 1
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AblativeArmor,
                StarshipTalentName.FastTargetingSystems,
                StarshipTalentName.ImprovedDamageControl,
                StarshipTalentName.ImprovedImpulseDrive
            }
        },
        new()
        {
            Name = MissionProfileName.TechnicalTestbed,
            Description = "The ship is equipped with numerous state-of-the-art or even prototype technologies, allowing them to be tested or studied in practical conditions so that flaws can be discovered and overcome, and that systems can be refined and improved upon. These ships are often deployed on a broad range of resource-intensive missions to provide a diverse range of conditions for equipment and technology testing.",
            Systems = new StarshipSystems { Engines = 1 },
            Departments = new Departments
            {
                Command = 1, Conn = 2, Engineering = 3, Security = 2, Medicine = 2, Science = 2
            },
            TalentChoices = new List<string>
            {
                StarshipTalentName.AdvancedShields,
                StarshipTalentName.ImprovedImpulseDrive,
                StarshipTalentName.ImprovedPowerSystems,
                StarshipTalentName.ImprovedWarpDrive
            },
            Source = BookSource.GameToolkit
        }
    };
}
