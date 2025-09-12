using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class NpcSelector
{
    public static NonPlayerCharacter GetNonPlayerCharacter(string name)
    {
        var npc = NonPlayerCharacters.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        foreach (var weapon in npc.Attacks)
            weapon.SetEffect(npc.EscalationAttacks);

        return npc;
    }

    internal static List<NonPlayerCharacter> GetAllNonPlayerCharacters()
    {
        var npcs = NonPlayerCharacters;

        foreach (var npc in npcs)
        {
            foreach(var weapon in npc.Attacks)
                weapon.SetEffect(npc.EscalationAttacks);
        }

        return npcs;
    }

    private static readonly List<NonPlayerCharacter> NonPlayerCharacters = new()
    {
        // STARFLEET & FEDERATION NPCS
        new NonPlayerCharacter 
        {
            Name = "Starfleet Officer",
            TypeEnum = NPCType.Minor,
            Description = "A typical Starfleet officer.",
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Starfleet Officer"
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 10, Fitness = 8, Insight = 8, Presence = 9, Reason = 9 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 1, Security = 1, Medicine = 1, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType2, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                new() 
                {
                    Name = "Gamemaster's Note",
                    Description = new List<string>
                    {
                        "Add 1 point to two different department ratings to create different types (e.g., +1 to Engineering and Conn for a conn officer)."
                    },
                    HideIfGenerating = true,
                    AddOneToTwoDifferentDepartments = true,
                }
            }
        },
        new NonPlayerCharacter
        {
            Name = "Section 31 Operative",
            TypeEnum = NPCType.Notable,
            Description = "A member of Starfleet’s secret branch of intelligence, Section 31.",
            Traits = new List<string>
            {
                "Federation Species (add 3 points to attributes based on species)",
                "Starfleet Intelligence Operative"
            },
            RandomSpecies = true,
            Values = new List<string>
            {
                "The ends justify the means",
            },
            Focuses = new List<string>
            {
                Focus.Espionage, Focus.Infiltration
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 11, Daring = 8, Fitness = 7, Insight = 10, Presence = 9, Reason = 9 },
            Departments = new Departments { Command = 2, Conn = 1, Engineering = 2, Security = 3, Medicine = 1, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType2, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Adapable",
                    Description = new List<string>
                    {
                        "A Section 31 operative may spend 2 Threat to gain a single focus for the remainder of the scene."
                    }
                },
                new()
                {
                    Name = "Covert",
                    Description = new List<string>
                    {
                        "Whenever required to attempt a task to conceal their activities for Section 31—including to maintain their cover identity—they may roll an additional d20."
                    }
                },
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
            }
        },
        new NonPlayerCharacter
        {
            Name = "Captain T'Mek",
            TypeEnum = NPCType.Major,
            Description = "Starfleet captains command most Starfleet starships and space stations, and are responsible for their crews and for executing Starfleet’s orders. Captain T’Mek is representative of this type of officer.",
            Traits = new List<string>
            {
                "Vulcan",
                "Starfleet Officer",
                "Commanding Officer"
            },
            Values = new List<string>
            {
                "A failure to act can be as dangerous as acting rashly",
                "Wisdom is the beginning of logic, not the end",
            },
            Focuses = new List<string>
            {
                Focus.Astrophysics, Focus.Composure, Focus.Diplomacy, Focus.StarshipTactics
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 12, Daring = 9, Fitness = 9, Insight = 8, Presence = 10, Reason = 11 },
            Departments = new Departments { Command = 4, Conn = 3, Engineering = 2, Security = 2, Medicine = 1, Science = 4 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.VulcanNervePinch),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType2, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Considered Every Outcome",
                    Description = new List<string>
                    {
                        "When she succeeds at a Reason + Command task, T’Mek scores one more Momentum than normal."
                    }
                },
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                TalentSelector.GetTalentAsSpecialRule("Nerve Pinch")
            }
        },
        new NonPlayerCharacter
        {
            Name = "Rear Admiral Thy'Ran",
            TypeEnum = NPCType.Major,
            Description = "Starfleet admirals command Starfleet assets in entire regions or sectors of space, and often act with great latitude as required. Thyran is representative of this type of officer.",
            Traits = new List<string>
            {
                "Andorian",
                "Starfleet Flag Officer",
                "Strategist"
            },
            Values = new List<string>
            {
                "There is no higher calling than to serve",
                "We endure hardship, so that others do not have to",
            },
            Focuses = new List<string>
            {
                Focus.Endurance, Focus.FleetStrategyAndTactics, Focus.Inspiration, Focus.MilitaryHistory
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 11, Fitness = 9, Insight = 9, Presence = 12, Reason = 10 },
            Departments = new Departments { Command = 4, Conn = 3, Engineering = 3, Security = 3, Medicine = 2, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Proud and Honorable"),
                new()
                {
                    Name = "Accomplished Strategist",
                    Description = new List<string>
                    {
                        "Whenever he attempts to create a trait representing a strategy or plan, he may spend 1 Threat to re-roll his dice pool."
                    }
                },
                new()
                {
                    Name = "Counter-Ploy",
                    Description = new List<string>
                    {
                        "Whenever an enemy attempts a task to create a trait representing some manner of strategy or tactic, Thyran may spend 1 Threat to increase the Difficulty by 1. Further, if this task then fails, Thyran may immediately spend one additional Threat to create a trait of his own, representing his own stratagem."
                    }
                },
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining)
            }
        },
        // KLINGON NPCS
        new NonPlayerCharacter
        {
            Name = "Klingon Warrior",
            TypeEnum = NPCType.Minor,
            Description = "A worthy warrior of the Klingon Empire.",
            Traits = new List<string>
            {
                "Klingon",
                "Warrior"
            },
            PersonalThreat = 0,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 7, Daring = 10, Fitness = 10, Insight = 7, Presence = 9, Reason = 8 },
            Departments = new Departments { Command = 1, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DkTahgDagger),
                WeaponSelector.GetWeapon(WeaponName.BatLeth),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
            }
        },
        new NonPlayerCharacter
        {
            Name = "Klingon Veteran",
            TypeEnum = NPCType.Notable,
            Description = "A battle-hardened Klingon warrior.",
            Traits = new List<string>
            {
                "Klingon",
                "Warrior"
            },
            Values = new List<string>
            {
                "Today is a Good Day to Die!"
            },
            Focuses = new List<string>
            {
                Focus.HandToHandCombat, Focus.Resilience
            },
            PersonalThreat = 3,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 8, Daring = 11, Fitness = 10, Insight = 8, Presence = 10, Reason = 7 },
            Departments = new Departments { Command = 2, Conn = 2, Engineering = 1, Security = 3, Medicine = 1, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DkTahgDagger),
                WeaponSelector.GetWeapon(WeaponName.BatLeth),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1), (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Lead by Example",
                    Description = new List<string>
                    {
                        "When the Klingon Officer makes a successful attack, they may spend 2 Threat to assist another Klingon’s next attack with his Daring + Command."
                    }
                },
                TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
            }
        },
        new NonPlayerCharacter
        {
            Name = "Moq'var, son of Koloth",
            TypeEnum = NPCType.Major,
            Description = "Klingon commanders guide their ships through the quadrants, seeking honor and glory for themselves and their crews, and resources to benefit the Empire. Moq’var is representative of this type of officer.",
            Traits = new List<string>
            {
                "Klingon",
                "Commanding Officer"
            },
            Values = new List<string>
            {
                "There is nothing more honorable than victory",
                "To kill the defenseless is not true battle"
            },
            Focuses = new List<string>
            {
                Focus.HandToHandCombat, Focus.Intimidation, Focus.Resilience, Focus.StarshipTactics
            },
            PersonalThreat = 8,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 9, Daring = 12, Fitness = 10, Insight = 9, Presence = 11, Reason = 8 },
            Departments = new Departments { Command = 3, Conn = 3, Engineering = 2, Security = 5, Medicine = 1, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DkTahgDagger),
                WeaponSelector.GetWeapon(WeaponName.BatLeth),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Hardy",
                    Description = new List<string>
                    {
                        "Moq’var is resilient and can shrug off wounds that would down normal combatants. Moq’var’s Personal Threat is increased by +2 (included above)."
                    }
                },
                new()
                {
                    Name = "Lead by Example",
                    Description = new List<string>
                    {
                        "When Moq’var makes a successful attack, they may spend 2 Threat to assist another Klingon’s next attack with his Daring + Command."
                    }
                },
                TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
            }
        },
    };
}
