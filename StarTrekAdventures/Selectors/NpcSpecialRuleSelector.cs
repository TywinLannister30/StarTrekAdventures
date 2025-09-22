using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class NpcSpecialRuleSelector : INpcSpecialRuleSelector
{
    public NpcSpecialRule GetSpecialRule(string name)
    {
        return NpcSpecialRules.First(x => x.Name == name);
    }

    private static readonly List<NpcSpecialRule> NpcSpecialRules = new()
    {
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Amphibious,
            Description = new List<string>
            {
                "This creature can move on the ground or through the water with ease. Complications normally suffered by a creature moving through an environment in which it is not native are ignored. This special rule can apply to any two environments, such as vacuum and magma, or aquatic and air."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.AquaticEnvironment,
            Description = new List<string>
            {
                "The being is at home in the water and has physiological structures that allow them to move through liquids with ease. While underwater (or another liquid), the being can move up to two zones with a minor action. The creature cannot drown while in a liquid environment but may do so in a non-liquid environment."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Camouflaged1,
            Description = new List<string>
            {
                "The Difficulty of any task to locate the being is increased by 1."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Camouflaged2,
            Description = new List<string>
            {
                "The Difficulty of any task to locate the being is increased by 2."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Camouflaged3,
            Description = new List<string>
            {
                "The Difficulty of any task to locate the being is increased by 3."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Coordination,
            Description = new List<string>
            {
                "A group of these creatures can cooperate through communications of some sort, be it sound, sight, or even pheromones. These creatures can create advantages for themselves (complications toward the characters) representing more complex problem-solving and tactics."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.EnergyBased,
            Description = new List<string>
            {
                "The creature’s body is made of coherent energy or radiation. They may also emit energy from their skin. This creature’s Protection is increased by 2 against energy similar to what it is made of. Additionally, any time another creature makes physical contact with the energy-based creature, it inflicts a Deadly Injury with a Severity of 1."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ExtraordinaryControl1,
            Description = new List<string>
            {
                "This creature’s Control us far beyond the normal range for humanoids. A creature with Extraordinary Control 1 gains one success on all tasks using Control."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ExtraordinaryDaring1,
            Description = new List<string>
            {
                "This creature’s Daring us far beyond the normal range for humanoids. A creature with Extraordinary Daring 1 gains one success on all tasks using Daring."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ExtraordinaryFitness1,
            Description = new List<string>
            {
                "This creature’s Fitness us far beyond the normal range for humanoids. A creature with Extraordinary Fitness 1 gains one success on all tasks using Fitness."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ExtraordinaryInsight1,
            Description = new List<string>
            {
                "This creature’s Insight us far beyond the normal range for humanoids. A creature with Extraordinary Insight 1 gains one success on all tasks using Insight."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ExtraordinaryPresence1,
            Description = new List<string>
            {
                "This creature’s Presence us far beyond the normal range for humanoids. A creature with Extraordinary Presence 1 gains one success on all tasks using Presence."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ExtraordinaryReason1,
            Description = new List<string>
            {
                "This creature’s Reason us far beyond the normal range for humanoids. A creature with Extraordinary Reason 1 gains one success on all tasks using Reason."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.FastRecovery,
            Description = new List<string>
            {
                "The creature recovers from stress and injury quickly. At the start of each of its turns, if the creature has one or more Injuries, roll a d20. If you roll equal to or under the creature’s Fitness, the NPC immediately removes an Injury. If the NPC has no more Injuries, it immediately ceases to be Defeated."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Flight,
            Description = new List<string>
            {
                "The creature has the ability to fly through the atmosphere of a planet, or ways of propelling it through the vacuum of space. This creature can move zones horizontally and vertically. In an atmosphere or gravity well, a creature must spend at least a minor action to move each turn or suffer from the effects of falling, but creatures existing in the vacuum of space don’t have this restriction. Flying creatures which are stunned or rendered unconscious fall to the ground."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Formless,
            Description = new List<string>
            {
                "This creature can contort their body, or change their overall shape drastically. They may be able to escape through small areas, or make themselves appear as something entirely different, creating traits to represent the forms they take."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.HyperAgile,
            Description = new List<string>
            {
                "The Difficulty to hit the creature with a ranged attack is increased by 1."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToCold,
            Description = new List<string>
            {
                "The creature is unaffected by effects derived from extreme cold, including Stress or Injuries."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToDisease,
            Description = new List<string>
            {
                "The creature is immune to the effects of disease, and will never suffer the symptoms of any disease. If the creature is exposed to a disease, it may become a carrier—able to spread the disease if it is contagious."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToFear,
            Description = new List<string>
            {
                "The creature is incapable of feeling fear, continuing undeterred despite the greatest terror. The creature cannot be intimidated or threatened."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToHeat,
            Description = new List<string>
            {
                "The creature is unaffected by effects derived from extreme heat, including Stress or Injuries caused by fire."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToPain,
            Description = new List<string>
            {
                "The creature is incapable of feeling pain, continuing undeterred despite the most horrific Injury. The creature ignores all Stun Injuries, and cannot be Defeated by an attack which inflicts a Stun Injury."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToPoison,
            Description = new List<string>
            {
                "The creature is unaffected by all forms of poison, venom, and toxin, and cannot suffer Stress or Injuries from them."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ImmuneToVacuum,
            Description = new List<string>
            {
                "The creature suffers no Injuries from being exposed to hard vacuum, or other extremes of atmospheric pressure, and cannot suffocate."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Incorporeal,
            Description = new List<string>
            {
                "Incorporeal NPCs—also including energy, gaseous, or fluid creatures, and “creatures” composed of a swarm of tiny creatures—are only partially of the physical universe, and they do not fully interact with it physically.",
                "The NPC gains 3 Protection. There may be some form of special energy or radiation-based attack which ignores this Protection, at the gamemaster’s discretion. The NPC may move freely through rough or difficult terrain, but they cannot move through larger or heavier physical barriers."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Initiative2,
            Description = new List<string>
            {
                "The creature is fast enough to act more than once per round. Unless otherwise noted, creatures have Initiative 1; this creature may take 2 turns each round."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.IntensiveTraining,
            Description = new List<string>
            {
                "Members of this group are given considerable training in a wide range of fields. They have a minimum of 1 in all departments: when creating an NPC with this ability, increase any department with a rating of 0 to 1."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.InvulnerableSpecificWeakness,
            Description = new List<string>
            {
                "The creature is impervious to harm and cannot be Injured in any way; Attacks can be attempted, but it cannot suffer Injuries.",
                "The creature has a specific weakness—a weak spot, a certain frequency of energy, a certain material—which can overcome its invulnerability. If this weakness is discovered and employed, then the creature can be Injured by Attacks which exploit that weakness (this also bypasses the effects of the other Invulnerable variations). The gamemaster’s discretion applies as to how the weakness may be discovered."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.InvulnerableStaggered,
            Description = new List<string>
            {
                "The creature is impervious to harm and cannot be Injured in any way; Attacks can be attempted, but it cannot suffer Injuries.",
                "The creature cannot be Injured, but it can be slowed down. If the creature would ever suffer an Injury, it instead loses the ability to perform any actions on its next turn. This effect is not cumulative."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.InvulnerableWrathful,
            Description = new List<string>
            {
                "The creature is impervious to harm and cannot be Injured in any way; Attacks can be attempted, but it cannot suffer Injuries.",
                "The creature grows angry when challenged; each time the creature would be Injured, it instead adds 2 Threat."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.LiquidEnvironment,
            Description = new List<string>
            {
                "The being is at home in the water and has physiological structures that allow them to move through liquids with ease. While underwater (or another liquid), the being can move up to two zones with a minor action. The creature cannot drown while in a liquid environment but may do so in a non-liquid environment."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Machine,
            Description = new List<string>
            {
                "The creature is not a living being, but a machine, or some form of cybernetic organism. It is highly resistant to environmental conditions, reducing the Difficulty of tasks to resist extremes of heat and cost by 2, and it is immune to the effects of suffocation, hard vacuum, starvation, and thirst."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Menacing1,
            Description = new List<string>
            {
                "When a creature with this rule enters a scene, immediately add 1 Threat. This applies whether the NPC is an adversary or an ally."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Mimicry,
            Description = new List<string>
            {
                "The creature has the capability to mimic a certain sense that it has experienced, such as a parrot mimicking speech, or perhaps a shape-shifting creature appearing as a humanoid they’ve encountered before."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.MultiLimbed,
            Description = new List<string>
            {
                "The creature has more than two limbs that it can attack with at once effectively. If it succeeds at an attack, it adds 1 Threat."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Multidimensional,
            Description = new List<string>
            {
                "This creature can move through walls and barriers and avoid simple attacks, as determined by the gamemaster, simply by moving itself out of observable space-time and re-entering it elsewhere."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.NaturalProtection1,
            Description = new List<string>
            {
                "The creature has 1 Protection."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.NightVision,
            Description = new List<string>
            {
                "The creature is unaffected by any traits which represent darkness or poor lighting."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Poisonous,
            Description = new List<string>
            {
                "Any attack against, or by, the creature can have Poisonous as an additional trait."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Ram,
            Description = new List<string>
            {
                "A creature may improve attacks with its horns, claws, or tail to represent gaining momentum through charging forward, spinning, or otherwise putting all it can into the attack. The creature may add the Intense quality to its melee attacks by taking the Prepare minor action before attacking."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Resilient,
            Description = new List<string>
            {
                "Whenever the creature suffers an Injury, roll a d20. If you roll equal to or under the creature’s Fitness, that Injury is not inflicted. Do this before deciding to Avoid Injury."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.SenseSpectrum,
            Description = new List<string>
            {
                "These creatures may “see” with X-rays, or hear sounds far too high pitched to often be considered useful. They may “smell” by sensing subspace particles, or even feel where their prey is through detecting the pattern of time surrounding its target."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Sturdy,
            Description = new List<string>
            {
                "This creature cannot be knocked prone."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ThreatGesture,
            Description = new List<string>
            {
                "The creature can suddenly rear up on its hind legs and tower over its prey, bellow an intimidating roar, suddenly display brightly colored spines, or even spray noxious juices in defense of itself. Once per encounter, the creature may make an opposed task of Presence + Command or Security. Characters that tie or fail that task are knocked prone as they backpedal, are startled, or otherwise pause due to a flight-or-fight response."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.ToolUser,
            Description = new List<string>
            {
                "While not sentient or self-aware, these creatures have a nervous system advanced enough to be able to manipulate the environment somehow in their favor. These creatures can be taught how to use simple devices or tools, or perhaps can learn through observation."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Toxic,
            Description = new List<string>
            {
                "Any attack against, or by, the creature can have Toxic as an additional trait."
            }
        },
        new NpcSpecialRule
        {
            Name = NpcSpecialRuleName.Venomous,
            Description = new List<string>
            {
                "Any attack against, or by, the creature can have Venomous as an additional trait."
            }
        },
    };
}
