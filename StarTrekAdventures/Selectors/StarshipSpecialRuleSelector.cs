using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class StarshipSpecialRuleSelector
{
    public static StarshipSpecialRule GetSpecialRule(string name)
    {
        return StarshipSpecialRules.First(x => x.Name == name);
    }

    private static readonly List<StarshipSpecialRule> StarshipSpecialRules = new()
    {
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.AbundantPersonnel,
            Description = new List<string>
            {
                "The ship’s Crew Support is doubled, after any other modifiers, and any effects or abilities which would increase Crew Support have twice the normal effect aboard a ship with this special rule. Further, when you introduce a supporting character, you may use one additional Crew Support to grant them an improvement immediately."
            },
            DoubleCrewSupport = true
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.AquariusEscort,
            Description = new List<string>
            {
                "The Aquarius escort is a small starship embedded in a docking slip at the aft of the Odyssey. The Aquarius is an independent starship and can travel at warp, though its endurance is limited, and it is not designed to go on extended missions. When deployed, the Aquarius can be an NPC ally starship or can be commanded by a player at the gamemaster’s discretion. Deploying the Aquarius class functions the same way as launching a small craft, though it does not take up any of the ship’s Small Craft Capacity.",
                "As it exists as part of its parent ship, the Aquarius class does not have a separate Crew Support rating. It also does not have talents, though it can be improved with character advancement.)"
            },
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.ClassifiedDesign,
            Description = new List<string>
            {
                "As the Crossfield class is a highly experimental spaceframe, Starfleet outfitted all ships of this class with the Technical Testbed mission profile."
            },
            MustTakeMissionProfile = MissionProfileName.TechnicalTestbed
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.CompactVessel,
            Description = new List<string>
            {
                "This spaceframe has a Scale of 2, but it does not count as a small craft. It has no small craft capability of its own, and cannot launch or receive shuttlepods, shuttlecraft, or any comparable craft."
            },
            NoSmallCraftCapacity = true
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.EncounterTheStrange,
            Description = new List<string>
            {
                "Each adventure, the gamemaster begins with +2 Threat. In addition, the ship always has an additional Directive for each mission: Understand the Inexplicable."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.ExperimentalVessel,
            Description = new List<string>
            {
                "When the ship is created, apply two additional refits to the ship. In addition, whenever the ship assists a task attempt, the ship’s die increases its complication range by 2 (to 18–20). A milestone refit can remove this complication range increase, representing the ship’s crew working out the problems in the prototype design."
            },
            ExtraRefits = 2
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.FarFromHome,
            Description = new List<string>
            {
                "The ship’s Crew Support and Small Craft Capacity are each reduced by 1. New supporting characters created may increase one of their departments by 1, and all the ship’s small craft increase one system by 1 (chosen when the small craft is prepared for launch)."
            },
            CrewSupportModifier = -1,
            SmallCraftReadinessModifier = -1,
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.FourNacelleStability,
            Description = new List<string>
            {
                "The vessel’s configuration of four warp nacelles can be used to produce a stable and long-lasting warp field. The Difficulty of any task attempted to go to warp, or to maintain warp speed despite hazards, damage, or anomalies, is reduced by 1, to a minimum of 1."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.GrapplerCable,
            Description = new List<string>
            {
                "The ship utilizes a physical cable with a magnetic hook at the end, in place of the graviton-based tractor beams used by ships in later eras. This functions as a tractor beam, but if the target breaks free, roll a d20: if you roll above the ship’s Weapons system, the cable is damaged, and cannot be used until repaired. Repairing the cable is treated as repairing a breach."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.LandingGear,
            Description = new List<string>
            {
                "The vessel is equipped to land safely on a planetary surface, and can return to space afterward. To land a ship requires Reserve Power be rerouted to Structure, and then requires someone at the helm to attempt a Control + Conn task with a Difficulty equal to the ship’s Scale, assisted by the ship’s Structure + Conn. This can Succeed at Cost. Success means the ship lands on the planet’s surface. Taking off requires the same task attempt, but the Difficulty is reduced by 2."
            },
            CrewSupportModifier = 1
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.LargerCrew,
            Description = new List<string>
            {
                "The ship’s Crew Support is increased by 1."
            },
            CrewSupportModifier = 1
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.MissionOfMercy,
            Description = new List<string>
            {
                "The first time in a scene when an enemy makes an attack against this ship, the gamemaster must spend 1 Threat. The hope ship must add 1 Threat the first time in any scene it makes an attack."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.MissionPod,
            Description = new List<string>
            {
                "All vessels of this class are fitted with a mission pod, which provides two of the ship's starting talents as well as adjustments to the ship's system and department ratings. All ships start with a number of talents equal to its Scale.",
                "The mission pod can be changed as if it were a single talent; replacing it takes 12–24 hours at a starbase or other facility.",
                "Certain spaceframes can be fitted with a mission pod, chosen from the list below. The talents provided by the pod may not be swapped out, but the entire mission pod (and all of its benefits) may be swapped out as if it were a single talent.",
                "If the selected mission pod provides a talent the spaceframe already has (either from its starting allotment of talents or from its mission profile), replace it with another talent (so long as it meets the listed requirements for the talent, if any)."
            },
            ChooseMissionPod = true
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.PeakPerformance,
            Description = new List<string>
            {
                "Select one of the ship’s systems. Whenever a task assisted by this system succeeds, the ship scores 1 bonus Momentum. Bonus Momentum cannot be saved."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.PolarizedHullPlating,
            Description = new List<string>
            {
                "Vessels of this spaceframe lack deflector shields common to many other ships, and instead rely upon polarization of the hull plating to resist damage. The ship’s Shields track instead represents the state of the ship’s polarized hull. The ship’s Shields are equal to its Structure, with no additional modifiers. However, these do not count as shields for the purposes of blocking transporter use."
            },
            StructureOnlyForShields = true
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.PreferentialTargeting,
            Description = new List<string>
            {
                "Using its sensitive scientific equipment, a Columbia can locate and exploit weaknesses in an enemy ship’s defenses. When a Columbia-class ship causes a breach to an enemy ship, the crew may spend 3 Momentum to immediately attack again with a different weapon."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.PrestigiousPosting,
            Description = new List<string>
            {
                "When a new supporting character is first introduced, apply a single improvement to them immediately, like a milestone."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.Prototype,
            Description = new List<string>
            {
                "The cloaking device employed on this vessel has some notable limitations. The vessel cannot travel at warp while cloaked, and the difficulty of the task roll to activate the cloak increases to 3."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.QuantumSlipstreamBurstDrive,
            Description = new List<string>
            {
                "This experimental drive allows the ship to enter quantum slipstream for 30 minutes at a time, moving the ship up to 150 light-years before shutting down. The drive requires 12 hours to reset. As experimental technology, this drive may require extensive maintenance and be prone to failure. This is an independent system, so the crew may operate the warp drive in between slipstream bursts."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.ReadyForBattle,
            Description = new List<string>
            {
                "During the first round of ship combat, the gamemaster must spend 1 additional Threat to allow an enemy ship to take the first turn."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.Reliable,
            Description = new List<string>
            {
                "Whenever the ship rolls to assist a task attempt, the group may spend 1 Momentum to ignore any complications rolled on the ship’s die."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.SaucerSeperation,
            Description = new List<string>
            {
                "Vessels of this class have the capability to detach their saucer section in an emergency. Once the saucer has detached, the two sections of the ship cannot be reconnected outside of a drydock. Ship’s systems are halved (round up) for the saucer and the secondary hull when separated, the saucer is unable to enter warp speeds or launch small craft, and each section is considered a separate vessel with Scale 1 less than the original vessel; the secondary hull is commanded from main engineering. The saucer can land on a planetary surface with emergency landing gear."
            },
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.SaucerSeperationAndReconnection,
            Description = new List<string>
            {
                "The ship is designed so the saucer section can be separated from the engineering section to operate as two distinct ships. Each section has the same systems, talents, and weapons, but their Scale is 1 lower than that of the original vessel (recalculate anything derived from Scale). Further, if the ship suffered any breaches prior to separating, ongoing effects of those breaches apply equally to both sections. The saucer section, which usually contains the crew quarters and recreation areas, does not have the capacity to go to warp. The secondary hull is commanded from main engineering.",
                "Separating is a major action attempted from the bridge (Operations panel) or main engineering, requiring a Control + Conn task with a Difficulty of 3, assisted by the ship’s Structure + Engineering. Reconnecting takes a major action, but the process is automated and requires no task attempt. Separating and reconnecting cannot be completed if the ship (or either part of it) has suffered one or more breaches to Structure."
            },
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.SpecializedShuttlebay,
            Description = new List<string>
            {
                "Akira-class vessels are built with a shuttlebay running the length of the saucer section, allowing small craft to depart from the prow and return safely via the aft. Any friendly small craft within Close range may count the ship as providing Cover (+1 Difficulty on attacks targeting them). Any small craft launching from the bay may take one additional helm minor action at no additional cost after they launch."
            },
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.TheLastGeneration,
            Description = new List<string>
            {
                "Select one of the ship’s systems. When you attempt a task assisted by that system, if the Difficulty is 2 or lower, you may reroll the ship’s assist die; If the Difficulty is 3 or higher, increase the task’s complication range by 1."
            }
        },
        new StarshipSpecialRule
        {
            Name = StarshipSpecialRuleName.UpgradedSystem,
            Description = new List<string>
            {
                "When the ship is created, you may select one ship talent granted by the ship’s spaceframe and replace it with a different talent. In addition, select one system: that system may be increased up to three times by refits rather than only twice."
            },
            MajorRefit = true
        },
    };
}
