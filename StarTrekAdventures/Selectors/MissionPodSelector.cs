using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class MissionPodSelector : IMissionPodSelector
{
    public MissionPod ChooseMissionPod()
    {
        return MissionPods.OrderBy(n => Util.GetRandom()).First();

    }

    private static readonly ICollection<MissionPod> MissionPods = new List<MissionPod>
    {
        new() 
        {
            Name = "Astrometrics and Navigation",
            Systems = new StarshipSystems
            {
                Computers = 1, Engines = 1,
            },
            Departments = new Departments
            {
                Conn = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedSensorSuites,
                StarshipTalentName.ImprovedWarpDrive
            }
        },
        new()
        {
            Name = "Command and Control",
            Systems = new StarshipSystems
            {
                Comms = 1, Computers = 1,
            },
            Departments = new Departments
            {
                Command = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.ElectronicWarfareSystems
            }
        },
        new()
        {
            Name = "Defensive Shield Enhancement",
            Systems = new StarshipSystems
            {
                Engines = 1, Structure = 1,
            },
            Departments = new Departments
            {
                Engineering = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedShields,
                StarshipTalentName.ImprovedShieldRecharge
            }
        },
        new()
        {
            Name = "Emergency Recovery",
            Systems = new StarshipSystems
            {
                Engines = 1, Structure = 1,
            },
            Departments = new Departments
            {
                Conn = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.HighPowerTractorBeam
            },
            ChooseOneTalent = new List<string>
            {
                StarshipTalentName.RedundantSystemsComms,
                StarshipTalentName.RedundantSystemsComputers,
                StarshipTalentName.RedundantSystemsEngines,
                StarshipTalentName.RedundantSystemsSensors,
                StarshipTalentName.RedundantSystemsStructure,
                StarshipTalentName.RedundantSystemsWeapons,
            }
        },
        new()
        {
            Name = "Field Hospital",
            Systems = new StarshipSystems
            {
                Computers = 2
            },
            Departments = new Departments
            {
                Medicine = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.EmergencyMedicalHologram,
                StarshipTalentName.AdvancedSickbay
            }
        },
        new()
        {
            Name = "Fleet Carrier",
            Systems = new StarshipSystems
            {
                Comms = 1, Structure = 1
            },
            Departments = new Departments
            {
                Security = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.ExtensiveShuttlebays
            }
        },
        new()
        {
            Name = "Fleet Command Support",
            Systems = new StarshipSystems
            {
                Comms = 1, Computers = 1
            },
            Departments = new Departments
            {
                Command = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.FastTargetingSystems
            }
        },
        new()
        {
            Name = "Mobile Drydock",
            Systems = new StarshipSystems
            {
                Structure = 1, Computers = 1
            },
            Departments = new Departments
            {
                Engineering = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.ImprovedDamageControl,
                StarshipTalentName.RuggedDesign
            }
        },
        new()
        {
            Name = "Sensors",
            Systems = new StarshipSystems
            {
                Sensors = 2
            },
            Departments = new Departments
            {
                Science = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedSensorSuites,
                StarshipTalentName.HighResolutionSensors
            }
        },
        new()
        {
            Name = "Warp Propulsion Pod",
            Systems = new StarshipSystems
            {
                Engines = 2
            },
            Departments = new Departments
            {
                Conn = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.ImprovedWarpDrive,
                StarshipTalentName.SecondaryReactors
            }
        },
        new()
        {
            Name = "Weapons",
            Systems = new StarshipSystems
            {
                Sensors = 1, Weapons = 1
            },
            Departments = new Departments
            {
                Security = 1
            },
            Talents = new List<string>
            {
                StarshipTalentName.FastTargetingSystems,
                StarshipTalentName.RapidFireTorpedoLauncher
            }
        },
    };
}
