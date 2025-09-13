using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class NpcSelector
{
    public static NonPlayerCharacter GetNonPlayerCharacter(string name)
    {
        var selectedNpc = NonPlayerCharacters.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        var npc = new NonPlayerCharacter(selectedNpc);

        foreach (var weapon in npc.Attacks)
            weapon.SetEffect(npc);

        return npc;
    }

    internal static List<NonPlayerCharacter> GetAllNonPlayerCharacters()
    {
        var selectedNpcs = NonPlayerCharacters;

        var npcs = new List<NonPlayerCharacter>();

        foreach (var selectedNpc in selectedNpcs)
        {
            var npc = new NonPlayerCharacter(selectedNpc);

            foreach (var weapon in npc.Attacks)
                weapon.SetEffect(npc);

            npcs.Add(npc);
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

        // ROMULAN NPCS
        new NonPlayerCharacter
        {
            Name = "Romulan Uhlan",
            TypeEnum = NPCType.Minor,
            Description = "A rank-and-file soldier of the Romulan Star Empire.",
            Traits = new List<string>
            {
                "Romulan",
                "Soldier"
            },
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 9, Insight = 8, Presence = 7, Reason = 10 },
            Departments = new Departments { Command = 1, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.Dagger),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                TalentSelector.GetTalentAsSpecialRule("Wary"),
            }
        },
        new NonPlayerCharacter
        {
            Name = "Romulan Centurion",
            TypeEnum = NPCType.Notable,
            Description = "An experienced soldier in the Romulan services.",
            Traits = new List<string>
            {
                "Romulan",
                "Imperial Navy Officer"
            },
            Values = new List<string>
            {
                "I will not fail in my duty to the Empire"
            },
            Focuses = new List<string>
            {
                "Guerilla Tactics", "Paranoia"
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 9, Insight = 9, Presence = 7, Reason = 9 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.Dagger),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Group Ambush",
                    Description = new List<string>
                    {
                        "When the centurion makes an attack against an enemy who is unaware of their presence, they may spend 2 Threat to increase the severity of this and all other attacks made this round by them and their subordinates by 1."
                    }
                },
                TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                TalentSelector.GetTalentAsSpecialRule("Wary"),
            }
        },
        new NonPlayerCharacter
        {
            Name = "Major Verohk, Tal Shiar Agent",
            TypeEnum = NPCType.Major,
            Description = "Verohk is a member of the Romulan Empire’s intelligence arm, the Tal Shiar.",
            Traits = new List<string>
            {
                "Romulan",
                "Agent of the Tal Shiar"
            },
            Values = new List<string>
            {
                "The ends justify the means",
                "Everything I do, I do for Romulus"
            },
            Focuses = new List<string>
            {
                Focus.Deception, Focus.Infiltration, Focus.Interrogation, "Propaganda"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 9, Insight = 10, Presence = 9, Reason = 11 },
            Departments = new Departments { Command = 4, Conn = 2, Engineering = 3, Security = 2, Medicine = 2, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.Dagger),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                new()
                {
                    Name = "Supreme Authority",
                    Description = new List<string>
                    {
                        "Whenever a Romulan under Major Verohk’s command attempts a task to resist persuasion or intimidation, Verohk may spend 1 Threat to allow that Romulan to re-roll, even if Verohk is not present in the scene herself."
                    }
                },
                TalentSelector.GetTalentAsSpecialRule("Wary"),
            }
        },

        // CARDASSIAN NPCS
        new NonPlayerCharacter
        {
            Name = "Cardassian Soldier",
            TypeEnum = NPCType.Minor,
            Description = "Representative of countless Cardassian soldiers protecting Cardassian interests.",
            Traits = new List<string>
            {
                "Cardassian",
                "Soldier"
            },
            PersonalThreat = 0,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 8, Insight = 7, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 1, Conn = 3, Engineering = 1, Security = 2, Medicine = 0, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Healthy Suspicions",
                    Description = new List<string>
                    {
                        "The Cardassian Soldier may buy their first d20 for free when attempting to determine if someone is lying."
                    }
                },
                new()
                {
                    Name = "Loyal",
                    Description = new List<string>
                    {
                        "Whenever a Cardassian assists a task performed by someone they deem their superior, they may reroll their assistance die."
                    }
                },
            }
        },
        new NonPlayerCharacter
        {
            Name = "Cardassian Glinn",
            TypeEnum = NPCType.Notable,
            Description = "An experienced and loyal Cardassian soldier with rank and responsibility to lead others.",
            Traits = new List<string>
            {
                "Cardassian",
                "Military Officer"
            },
            Values = new List<string>
            {
                "Cardassians did not choose to be superior, fate made us this way"
            },
            Focuses = new List<string>
            {
                Focus.MilitaryTactics, Focus.Willpower
            },
            PersonalThreat = 3,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 11, Daring = 8, Fitness = 7, Insight = 8, Presence = 10, Reason = 10 },
            Departments = new Departments { Command = 2, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Healthy Suspicions",
                    Description = new List<string>
                    {
                        "The Cardassian Glinn may buy their first d20 for free when attempting to determine if someone is lying."
                    }
                },
                new()
                {
                    Name = "Expects Success",
                    Description = new List<string>
                    {
                        "Whenever the Cardassian Glinn uses the Direct or Assist task to aid a subordinate, that task may always Succeed at Cost."
                    }
                },
                new()
                {
                    Name = "Loyal",
                    Description = new List<string>
                    {
                        "Whenever a Cardassian Glinn assists a task performed by someone they deem their superior, they may reroll their assistance die."
                    }
                },
            }
        },
        new NonPlayerCharacter
        {
            Name = "Gul Tremak",
            TypeEnum = NPCType.Major,
            Description = "An experienced and loyal Cardassian soldier with rank and responsibility to lead others.",
            Traits = new List<string>
            {
                "Cardassian",
                "Military Officer"
            },
            Values = new List<string>
            {
                "Cardassia expects everyone to do their duty",
                "Knowledge is power, and power is everything"
            },
            Focuses = new List<string>
            {
                Focus.Debate, Focus.MilitaryTactics, Focus.Politics, Focus.Willpower
            },
            PersonalThreat = 8,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 8, Insight = 9, Presence = 12, Reason = 10 },
            Departments = new Departments { Command = 4, Conn = 4, Engineering = 2, Security = 2, Medicine = 1, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Cultured",
                    Description = new List<string>
                    {
                        "When engaged in social conflict, and given an opportunity to speak at length on a subject, Gul Tremak if he purchases any bonus d20s he may re-roll his dice pool."
                    }
                },
                new()
                {
                    Name = "Healthy Suspicions",
                    Description = new List<string>
                    {
                        "Gul Tremak may buy their first d20 for free when attempting to determine if someone is lying."
                    }
                },
                new()
                {
                    Name = "Loyal",
                    Description = new List<string>
                    {
                        "Whenever Gul Tremak assists a task performed by someone they deem their superior, they may reroll their assistance die."
                    }
                },
                new()
                {
                    Name = "Ruthless",
                    Description = new List<string>
                    {
                        "When Gul Tremak makes an attack against an enemy that was not aware of or prepared for an attack, or against an enemy that is defenseless, he may spend 1 Threat to re-roll any number of d20s in his dice pool."
                    }
                },
            }
        },

        // FERENGI NPCS
        new NonPlayerCharacter
        {
            Name = "Ferengi Menial",
            TypeEnum = NPCType.Minor,
            Description = "Representative of a young Ferengi working their way up into the world, or of a Ferengi lacking the lobes for independent success.",
            Traits = new List<string>
            {
                "Ferengi",
                "Underling"
            },
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 7, Fitness = 7, Insight = 10, Presence = 10, Reason = 8 },
            Departments = new Departments { Command = 1, Conn = 2, Engineering = 2, Security = 1, Medicine = 0, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Greed is Eternal"),
            }
        },
        new NonPlayerCharacter
        {
            Name = "Ferengi Salesman",
            TypeEnum = NPCType.Notable,
            Description = "An experienced Ferengi with some latinum and prestige to their name, always looking for the next deal to make themselves wealthier.",
            Traits = new List<string>
            {
                "Ferengi",
                "Merchant"
            },
            Values = new List<string>
            {
                "First Rule of Acquisition: Once you have their money, never give it back"
            },
            Focuses = new List<string>
            {
                Focus.Economics, Focus.Negotiation
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 7, Insight = 9, Presence = 10, Reason = 8 },
            Departments = new Departments { Command = 3, Conn = 1, Engineering = 2, Security = 1, Medicine = 0, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Greed is Eternal"),
                TalentSelector.GetTalentAsSpecialRule("Never Place Friendship Above Profit"),
            }
        },
        new NonPlayerCharacter
        {
            Name = "DaiMon Skel",
            TypeEnum = NPCType.Major,
            Description = "A DaiMon is often either an experienced businessman, with large lobes for business, or a military officer with a ship of their own and the will to use it effectively. The most cunning are both. DaiMon Skel is representative of such an officer.",
            Traits = new List<string>
            {
                "Ferengi",
                "Entrepreneur"
            },
            Values = new List<string>
            {
                "48th Rule of Acquisition: The bigger the smile, the sharper the knife",
                "211th Rule of Acquisition: Employees are the rungs on the ladder to success; don’t hesitate to step on them"
            },
            Focuses = new List<string>
            {
                "Bribery", Focus.Negotiation, Focus.StarshipTactics, Focus.Subterfuge
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 11, Fitness = 8, Insight = 10, Presence = 11, Reason = 9 },
            Departments = new Departments { Command = 4, Conn = 3, Engineering = 3, Security = 3, Medicine = 1, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.EnergyWhip),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Free Advice is Seldom Cheap",
                    Description = new List<string>
                    {
                        "Increase the Difficulty of all social conflict tasks to persuade DaiMon Skel by 2. This Difficulty increase is removed as soon as Skel is offered something in trade."
                    }
                },
                TalentSelector.GetTalentAsSpecialRule("Greed is Eternal"),
                new()
                {
                    Name = "You Can't Make a Deal if You're Dead",
                    Description = new List<string>
                    {
                        "DaiMon Skel will never make a Deadly attack. Further, when attempting a task to make a deal or persuade an enemy he has previously incapacitated, or an enemy who obviously outmatches him, he may add a bonus d20 to the roll for free."
                    }
                },
            }
        },

        // DOMINION NPCS
        new NonPlayerCharacter
        {
            Name = "Jem'Hadar Warrior",
            TypeEnum = NPCType.Minor,
            Description = "One of countless genetically engineered warriors designed to obey and to follow the Founders’ will through their Vorta handlers.",
            Traits = new List<string>
            {
                "Jem'Hadar",
                "Warrior"
            },
            PersonalThreat = 0,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 8, Daring = 10, Fitness = 10, Insight = 9, Presence = 7, Reason = 7 },
            Departments = new Departments { Command = 1, Conn = 2, Engineering = 2, Security = 2, Medicine = 0, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.Blade),
                WeaponSelector.GetWeapon(WeaponName.JemHadarPlasmaRifle),
                WeaponSelector.GetWeapon(WeaponName.KarTakin),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.KarTakin, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Brute Force",
                    Description = new List<string>
                    {
                        "Jem’Hadar add the Intense effect to their Unarmed Strike, and may attack with Deadly force."
                    },
                    UnarmedStrikesCanBeDeadly = true,
                    AddQualitiesToUnarmedStrikes = new List<string> { "Intense" }
                },
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToFear),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToPain),
                new()
                {
                    Name = "The Shroud",
                    Description = new List<string>
                    {
                        "A Jem’Hadar may spend 1 Threat as a minor action to become virtually invisible, increasing the Difficulty of all tasks to observe, locate, or target the Jem’Hadar by 3. This effect ends when the Jem’Hadar makes an Attack, or takes a minor action to end the effect. The Jem’Hadar loses this ability when deprived of ketracel-white."
                    }
                },
            },
        },
        new NonPlayerCharacter
        {
            Name = "Jem'Hadar First",
            TypeEnum = NPCType.Notable,
            Description = "A battle-tested warrior who has seen their share of battle, a Jem’Hadar First is a fearsome opponent on the battlefield.",
            Traits = new List<string>
            {
                "Jem'Hadar",
                "Warrior"
            },
            Values = new List<string>
            {
                "We are now dead; we go into battle to reclaim our lives",
            },
            Focuses = new List<string>
            {
                Focus.CombatTactics, Focus.HandToHandCombat
            },
            PersonalThreat = 3,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 9, Daring = 10, Fitness = 11, Insight = 9, Presence = 8, Reason = 7 },
            Departments = new Departments { Command = 2, Conn = 2, Engineering = 1, Security = 3, Medicine = 1, Science = 0 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.Blade),
                WeaponSelector.GetWeapon(WeaponName.JemHadarPlasmaRifle),
                WeaponSelector.GetWeapon(WeaponName.KarTakin),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.KarTakin, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Brute Force",
                    Description = new List<string>
                    {
                        "Jem’Hadar add the Intense effect to their Unarmed Strike, and may attack with Deadly force."
                    },
                    UnarmedStrikesCanBeDeadly = true,
                    AddQualitiesToUnarmedStrikes = new List<string> { "Intense" }
                },
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToFear),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToPain),
                new()
                {
                    Name = "The Shroud",
                    Description = new List<string>
                    {
                        "A Jem’Hadar may spend 1 Threat as a minor action to become virtually invisible, increasing the Difficulty of all tasks to observe, locate, or target the Jem’Hadar by 3. This effect ends when the Jem’Hadar makes an Attack, or takes a minor action to end the effect. The Jem’Hadar loses this ability when deprived of ketracel-white."
                    }
                },
                new()
                {
                    Name = "Victory is Life",
                    Description = new List<string>
                    {
                        "Whenever a Jem’Hadar First or one of its subordinates inflicts an Injury or achieves an objective, add 1 Threat."
                    }
                },
            },
        },
        new NonPlayerCharacter
        {
            Name = "Taris, Vorta Overseer",
            TypeEnum = NPCType.Major,
            Description = "Vorta act as the mouthpieces for the Founders, the leaders of the Dominion. Vorta oversee the Jem’Hadar and command them through threats and through the warriors’ dependence on ketracel-white. Taris is representative of the genetically-engineered Vorta.",
            Traits = new List<string>
            {
                "Vorta",
                "Diplomat"
            },
            Values = new List<string>
            {
                "I live to serve the Founders",
                "There is nothing I will not do to succeed"
            },
            Focuses = new List<string>
            {
                Focus.Deception, Focus.Diplomacy, Focus.Observation, Focus.Psychology
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 9, Insight = 11, Presence = 12, Reason = 10 },
            Departments = new Departments { Command = 4, Conn = 3, Engineering = 2, Security = 2, Medicine = 2, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "In the Name of the Founders",
                    Description = new List<string>
                    {
                        "When using the Direct or Assist task to command other servants of the Dominion, a Vorta may roll 2d20 instead of 1d20."
                    },
                },
                new()
                {
                    Name = "Manipulative",
                    Description = new List<string>
                    {
                        "If Taris purchases one or more d20s when attempting a task to deceive or intimidate another, she may re-roll her dice pool."
                    }
                },
            },
        },
    };
}
