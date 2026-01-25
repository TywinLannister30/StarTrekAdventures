using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class TalentSelector : ITalentSelector
{
    public Talent ChooseTalent(Character character, string traitName = null)
    {
        var weightedTalentsList = new WeightedList<Talent>();

        foreach (var talent in Talents)
        {
            if (!string.IsNullOrEmpty(traitName))
            {
                if (talent.TraitRequirement != traitName || !talent.AnyTraitRequirement.Any(r =>string.Equals(r, traitName, StringComparison.OrdinalIgnoreCase)))
                {
                    continue;
                }
            }

            if (CanTakeTalent(character, talent))
                weightedTalentsList.AddEntry(talent, talent.Weight);
        }

        return weightedTalentsList.GetRandom();
    }

    private static bool CanTakeTalent(Character character, Talent talent)
    {
        var chance = Util.GetRandom(100);
        var gmPermission = talent.GMPermission && chance == 1;

        if (character.Talents.Any(x => x.Name == talent.Name))
            return false;

        if (!talent.MayBeSelected)
            return false;

        if (!string.IsNullOrEmpty(talent.TraitRequirement))
        {
            if (!gmPermission && !character.Traits.Any(x => x == talent.TraitRequirement))
                return false;
        }

        if (talent.AnyTraitRequirement != null)
        {
            if (!gmPermission && !character.Traits.Any(x => talent.AnyTraitRequirement.Contains(x)))
                return false;
        }

        if (talent.AllTraitsRequirement != null)
        {
            if (!gmPermission && !talent.AllTraitsRequirement.All(x => character.Traits.Contains(x)))
                return false;
        }

        if (!string.IsNullOrEmpty(talent.GenderRequirement) && character.Gender != talent.GenderRequirement)
        {
            return false;
        }

        if (!string.IsNullOrEmpty(talent.FocusRequirement))
        {
            if (!character.Focuses.Any(x => x == talent.FocusRequirement))
                return false;
        }

        if (!string.IsNullOrEmpty(talent.TalentRequirement))
        {
            if (!character.Talents.Any(x => x.Name == talent.TalentRequirement))
                return false;
        }

        if (talent.MayNotTakeWithTalents != null && talent.MayNotTakeWithTalents.Count != 0)
        {
            if (character.Talents.Any(ct => talent.MayNotTakeWithTalents.Contains(ct.Name)))
                return false;
        }

        if (talent.DepartmentRequirements != null)
        {
            if (talent.DepartmentRequirements.Operator == Operator.None || talent.DepartmentRequirements.Operator == Operator.And)
            {
                if (character.Departments.Command < talent.DepartmentRequirements.Command ||
                    character.Departments.Conn < talent.DepartmentRequirements.Conn ||
                    character.Departments.Engineering < talent.DepartmentRequirements.Engineering ||
                    character.Departments.Medicine < talent.DepartmentRequirements.Medicine ||
                    character.Departments.Science < talent.DepartmentRequirements.Science ||
                    character.Departments.Security < talent.DepartmentRequirements.Security)
                    return false;
            }

            if (talent.DepartmentRequirements.Operator == Operator.Or)
            {
                var allowed = false;

                if (talent.DepartmentRequirements.Command > 1 && (character.Departments.Command > talent.DepartmentRequirements.Command) ||
                    talent.DepartmentRequirements.Conn > 1 && (character.Departments.Conn > talent.DepartmentRequirements.Conn) ||
                    talent.DepartmentRequirements.Engineering > 1 && (character.Departments.Engineering > talent.DepartmentRequirements.Engineering) ||
                    talent.DepartmentRequirements.Medicine > 1 && (character.Departments.Medicine > talent.DepartmentRequirements.Medicine) ||
                    talent.DepartmentRequirements.Science > 1 && (character.Departments.Science > talent.DepartmentRequirements.Science) ||
                    talent.DepartmentRequirements.Security > 1 && (character.Departments.Security > talent.DepartmentRequirements.Security))
                    allowed = true;

                if (!allowed)
                    return false;
            }
        }

        if (talent.AttributeRequirements != null)
        {
            if (character.Attributes.Control < talent.AttributeRequirements.Control ||
                character.Attributes.Daring < talent.AttributeRequirements.Daring ||
                character.Attributes.Fitness < talent.AttributeRequirements.Fitness ||
                character.Attributes.Insight < talent.AttributeRequirements.Insight ||
                character.Attributes.Presence < talent.AttributeRequirements.Presence ||
                character.Attributes.Reason < talent.AttributeRequirements.Reason)
                return false;
        }

        if (!string.IsNullOrEmpty(talent.MayNotTakeWithRole))
        {
            if (character.Roles.Count == 0) return false;

            if (character.Roles.Any(x => x.Name == talent.MayNotTakeWithRole))
                return false;
        }

        if (talent.AnyRoleRequirement != null)
        {
            if (character.Roles.Count == 0) return false;

            if (!character.Roles.Any(r => talent.AnyRoleRequirement.Contains(r.Name)))
                return false;
        }

        if (talent.RequiresPsychologyFocus)
        {
            if (character.Focuses.Count == 0) return false;
            
            foreach (var focus in character.Focuses)
            {
                if (FocusHelper.IsPsychologyFocus(focus)) return true;
            }
        }

        if (talent.IsEsoteric && character.SpeciesAbility.CanTakeEsotericTalents)
            return true;

        if (string.IsNullOrEmpty(talent.TraitRequirement) && talent.AnyTraitRequirement == null && talent.GMPermission && !gmPermission)
            return false;

        return true;
    }

    public Talent GetTalent(string name)
    {
        return Talents.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<Talent> GetAllTalents()
    {
        return Talents;
    }

    public NpcSpecialRule GetTalentAsSpecialRule(string name)
    {
        var talent = GetTalent(name);

        return new NpcSpecialRule
        {
            Name = talent.Name + " (Talent)",
            Description = talent.Description.ToList(),
            ProtectionModifier = talent.ProtectionModifier,
        };
    }

    private static readonly List<Talent> Talents = GetAllTalentsList();

    private static List<Talent> GetAllTalentsList()
    {
        var allTalents = new List<Talent>();
        allTalents.AddRange(GetGeneralTalents());
        allTalents.AddRange(GetSpeciesAndCultureTalents());
        allTalents.AddRange(GetAugmentAndCyberneticTalents());
        allTalents.AddRange(GetEsotericTalents());
        allTalents.AddRange(GetExperienceTalents());
        allTalents.AddRange(GetCommandTalents());
        allTalents.AddRange(GetConnTalents());
        allTalents.AddRange(GetEngineeringTalents());
        allTalents.AddRange(GetSecurityTalents());
        allTalents.AddRange(GetScienceTalents());
        allTalents.AddRange(GetMedicineTalents());
        return allTalents;
    }

    private static List<Talent> GetGeneralTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Back-up Plans",
                AttributeRequirements = new CharacterAttributes { Control = 9 },
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you or an ally fail a task (so long as you are present in the scene), you may add 1 point to the group’s Momentum pool."
                }
            },
            new()
            {
                Name = "Bold (Command)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Command task, and you buy one or more d20s by adding Threat, you may re-roll a single d20. You may not select this talent if you have Cautious (Command)."
                },
                MayNotTakeWithTalents = { "Cautious (Command)" }
            },
            new()
            {
                Name = "Bold (Conn)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Conn task, and you buy one or more d20s by adding Threat, you may re-roll a single d20. You may not select this talent if you have Cautious (Conn)."
                },
                MayNotTakeWithTalents = { "Cautious (Conn)" }
            },
            new()
            {
                Name = "Bold (Engineering)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Engineering task, and you buy one or more d20s by adding Threat, you may re-roll a single d20. You may not select this talent if you have Cautious (Engineering)."
                },
                MayNotTakeWithTalents = { "Cautious (Engineering)" }
            },
            new()
            {
                Name = "Bold (Medicine)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Medicine task, and you buy one or more d20s by adding Threat, you may re-roll a single d20. You may not select this talent if you have Cautious (Medicine)."
                },
                MayNotTakeWithTalents = { "Cautious (Medicine)" }
            },
            new()
            {
                Name = "Bold (Science)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Science task, and you buy one or more d20s by adding Threat, you may re-roll a single d20. You may not select this talent if you have Cautious (Science)."
                },
                MayNotTakeWithTalents = { "Cautious (Science)" }
            },
            new()
            {
                Name = "Bold (Security)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Commadn task, and you buy one or more d20s by adding Threat, you may re-roll a single d20. You may not select this talent if you have Cautious (Security)."
                },
                MayNotTakeWithTalents = { "Cautious (Security)" }
            },
            new()
            {
                Name = "Calm and Logical",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Reason = 11 },
                Description = new List<string>
                {
                    "When you gain a trait which represents a mood or emotional state, you may suppress that trait (ignoring its effect) for the duration of a single task or a single turn in combat by suffering 1 Stress."
                }
            },
            new()
            {
                Name = "Cautious (Command)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Command task, and you buy one or more d20s by spending Momentum, you may re-roll a single d20. You may not select this talent if you have Bold (Command)."
                },
                MayNotTakeWithTalents = { "Bold (Command)" }
            },
            new()
            {
                Name = "Cautious (Conn)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Conn task, and you buy one or more d20s by spending Momentum, you may re-roll a single d20. You may not select this talent if you have Bold (Conn)."
                },
                MayNotTakeWithTalents = { "Bold (Conn)" }
            },
            new()
            {
                Name = "Cautious (Engineering)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Engineering task, and you buy one or more d20s by spending Momentum, you may re-roll a single d20. You may not select this talent if you have Bold (Engineering)."
                },
                MayNotTakeWithTalents = { "Bold (Engineering)" }
            },
            new()
            {
                Name = "Cautious (Security)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Security task, and you buy one or more d20s by spending Momentum, you may re-roll a single d20. You may not select this talent if you have Bold (Security)."
                },
                MayNotTakeWithTalents = { "Bold (Security)" }
            },
            new()
            {
                Name = "Cautious (Science)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Science task, and you buy one or more d20s by spending Momentum, you may re-roll a single d20. You may not select this talent if you have Bold (Science)."
                },
                MayNotTakeWithTalents = { "Bold (Science)" }
            },
            new()
            {
                Name = "Cautious (Medicine)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a Medicine task, and you buy one or more d20s by spending Momentum, you may re-roll a single d20. You may not select this talent if you have Bold (Medicine)."
                },
                MayNotTakeWithTalents = { "Bold (Medicine)" }
            },
            new()
            {
                Name = "Close-Knit Crew",
                Weight = 1,
                Description = new List<string>
                {
                    "When a scene begins, if there are fewer points of Momentum in the group pool than there are characters in the scene who have this talent, immediately add 1 Momentum to the group pool."
                }
            },
            new()
            {
                Name = "Collaboration (Command)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever an ally attempts a Command task, you may spend 1 Momentum (Immediate) to allow them to use your Command rating and one of your relevant focuses."
                }
            },
            new()
            {
                Name = "Collaboration (Conn)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever an ally attempts a Conn task, you may spend 1 Momentum (Immediate) to allow them to use your Conn rating and one of your relevant focuses."
                }
            },
            new()
            {
                Name = "Collaboration (Engineering)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever an ally attempts a Engineering task, you may spend 1 Momentum (Immediate) to allow them to use your Engineering rating and one of your relevant focuses."
                }
            },
            new()
            {
                Name = "Collaboration (Security)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever an ally attempts a Security task, you may spend 1 Momentum (Immediate) to allow them to use your Security rating and one of your relevant focuses."
                }
            },
            new()
            {
                Name = "Collaboration (Science)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever an ally attempts a Science task, you may spend 1 Momentum (Immediate) to allow them to use your Science rating and one of your relevant focuses."
                }
            },
            new()
            {
                Name = "Collaboration (Medicine)",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever an ally attempts a Medical task, you may spend 1 Momentum (Immediate) to allow them to use your Medical rating and one of your relevant focuses."
                }
            },
            new()
            {
                Name = "Constantly Watching",
                Weight = 1,
                Description = new List<string>
                {
                    "At the start of an action scene, the gamemaster must spend an additional 2 Threat to have an NPC take the first turn. You may also re-roll 1d20 on any task attempted to locate a hidden enemy or danger."
                }
            },
            new()
            {
                Name = "Dauntless",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever another character attempts to intimidate or threaten you, you may suffer 2 Stress to ignore their attempt."
                }
            },
            new()
            {
                Name = "Evasion",
                Weight = 1,
                Description = new List<string>
                {
                    "When someone is searching for you, you’ll take any opportunity to evade them. When an enemy suffers a complication on a task attempt to detect or locate you, you may immediately move one zone without them noticing you."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Extra Effort",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Fitness = 9 },
                Description = new List<string>
                {
                    "When you attempt a task, you may reduce the Difficulty of the task by 1, to a minimum of 0. However, once the task is completed, you immediately take Stress equal to the original Difficulty of the task."
                }
            },
            new()
            {
                Name = "Indefatigable",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Fitness = 11 },
                Description = new List<string>
                {
                    "When you fail a task, and attempt that task again during the same scene, reduce the Difficulty of the second attempt (and any subsequent attempts if you still fail) by 1."
                }
            },
            new()
            {
                Name = "Go to Ground",
                Weight = 1,
                Description = new List<string>
                {
                    "Exploration often puts you in danger, and you know how to keep yourself safe. When you attempt a task to hide from an enemy, the first bonus d20 you purchase is free as long as you remain prone and do not move. In combat, if you are the target of a ranged attack while in Cover, you may gain one bonus success on your opposed task, but if you do so, you may not counterattack."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Gut Feeling",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Insight = 11 },
                Description = new List<string>
                {
                    "When the gamemaster spends Threat to introduce reinforcements or to cause a Reversal, they must spend 2 additional Threat to do so. This is 2 extra Threat in total, not per reinforcement."
                }
            },
            new()
            {
                Name = "Head on a Swivel",
                Weight = 1,
                Description = new List<string>
                {
                    "You’re always on the lookout for trouble, and ready to duck when it shows up. When you’re the target of a ranged attack, and you are not in Cover, you may suffer 1 Stress to react to the attack. If you do so, you may immediately move to any Cover within your current zone, or you may drop prone and count as being in Cover against the current attack."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Just a Scratch",
                Weight = 1,
                Description = new List<string>
                {
                    "You have a knack for getting out of trouble with only minor scrapes and scratches. Once per scene, when you would suffer an Injury, you may avoid that Injury by adding to Threat instead of suffering Stress. The amount of Threat added is the same as the amount of Stress you would have suffered."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = TalentName.LifeLessons,
                Weight = 0,
                GMPermission = true,
                Description = new List<string>
                {
                    "Wisdom is the aftereffect of experience, and you’ve become adept at using your experiences to guide others. Whenever you use one of your values to gain or spend Momentum, and make a call back to a previous adventure in which you used that value, you may immediately add 3 Momentum to the group pool.",
                    "During Step 5 of lifepath character creation, if you select the Veteran option, you may select this talent instead of the Veteran talent."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Make Youre Own Luck",
                Weight = 1,
                Description = new List<string>
                {
                    "You don’t rely on chance or fortune to guide you. When you attempt a task, after rolling, you may suffer 1 Stress to change any one die to be equal to the target number you used on the roll (guaranteeing one success). You may do this only once per task, and if you do this, you cannot re-roll any dice on that task roll.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Mercurial",
                Weight = 1,
                Description = new List<string>
                {
                    "Your mood is quick to change. When you attempt a task and you are affected by any traits that represent emotions such as Fear, Doubt, or Panic, you may suffer 1 Stress to remove one of those traits before you make the task roll.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Methodical Planning",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Reason = 9 },
                Description = new List<string>
                {
                    "When an ally attempts a task which benefits from a trait you created which represents your plan or strategy, then you may Assist that ally’s task even if you are not present. In combat, this assistance does not require you to use your task to Assist that ally."
                }
            },
            new()
            {
                Name = "No Hesitation",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Daring = 9 },
                Description = new List<string>
                {
                    "At the start of any round in an action scene, you may add 1 Threat to take the first turn, regardless of who would otherwise have acted first."
                }
            },
            new()
            {
                Name = "No Pain, No Gain",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Daring = 11 },
                Description = new List<string>
                {
                    "When you fail a task (but not an opposed task) which used your Daring, you may always choose to Succeed at Cost."
                }
            },
            new()
            {
                Name = "Objective Focused",
                Weight = 1,
                Description = new List<string>
                {
                    "Once you have an objective in sight, little can deter you from pursuing it. Once per adventure, at the start of an action scene, you may define an immediate goal by adding 2 Threat. This goal must relate to the mission and your duties, such as reaching a particular location or character, obtaining an important item, or similar. During the scene, you may re-roll one d20 on any task attempt which would bring you closer to achieving your goal.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Persistent",
                Weight = 1,
                Description = new List<string>
                {
                    "You don’t let trivial things like failure deter you, and you’d rather succeed messily than fail cleanly. When you attempt a task, you may choose to suffer a single automatic complication in exchange for gaining one automatic success.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Personal Effects",
                Weight = 1,
                Description = new List<string>
                {
                    "You possess some significant and uncommon item or device which is not standard issue, but which is nevertheless useful for missions. You may select this talent multiple times, gaining a different item each time."
                },
                MainCharacterOnly = true,
            },
            new()
            {
                Name = "Preperation",
                Weight = 1,
                Description = new List<string>
                {
                    "You thrive when there’s a clear plan of action. When you attempt a task, and there are one or more traits which would affect the task positively, you may re-roll one d20.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Prestigious Career",
                Weight = 1,
                MainCharacterOnly = true,
                CharacterCreationOnly = true,
                Description = new List<string>
                {
                    "You’ve had an impressive career, and it has earned you accolades and good standing. You begin play with a Reputation rating of 4, or you may begin play with a single award with a cost of 3 or less without needing to meet the conditions.",
                    "You may replace this talent with another without losing the benefits of it, but only if you can spend three or more Acclaim (from a successful Reputation roll) at the end of that mission."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Protector",
                Weight = 2,
                AttributeRequirements = new CharacterAttributes { Daring = 11 },
                Description = new List<string>
                {
                    "You put the safety of your crew and comrades first, and will push yourself further to defend them. If an ally in the same scene as you is Defeated, you immediately recover up to 3 Stress as you push yourself harder to defend them.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Quick Survey",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Insight = 9 },
                Description = new List<string>
                {
                    "At the start of a scene, you may immediately ask one question, as if you had spent 1 Momentum on the Obtain Information Momentum Spend. The answer can only provide information that you could obtain with your own senses: you cannot gain information from equipment in such a short time."
                }
            },
            new()
            {
                Name = "Ransack",
                Weight = 2,
                AttributeRequirements = new CharacterAttributes { Daring = 9 },
                Description = new List<string>
                {
                    "Sometimes it pays to search an area quickly and messily rather than methodically. When you attempt a task to search an area, you may add 2 Threat to reduce the Difficulty by 1 (to a minimum of 0), and you halve how long it takes to search that area.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Reassuring",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Presence = 9 },
                Description = new List<string>
                {
                    "When you succeed at a task using your Presence, you may spend Momentum to reassure your allies, so long as they are able to hear you. You may spend 1 Momentum (Repeatable) to allow one ally who can see and hear you to recover 1 Stress. That ally may not recover more than 3 Stress from one use of this talent."
                }
            },
            new()
            {
                Name = "Rivalry",
                Weight = 1,
                Description = new List<string>
                {
                    "You have a fierce rivalry with another character, and you constantly push yourself to outdo them. Select one other Main Character in the group. Whenever they add 1 or more Threat to purchase bonus d20s, you recover 1 Stress for each die they purchase.",
                    "You may select this talent multiple times, selecting a different character each time. You may not select the same character for both Rivalry and Supportive."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Second Wind",
                Weight = 1,
                Description = new List<string>
                {
                    "You may spend Determination at the start of your turn to remove the Defeated state, and to recover up to half of your maximum Stress. The normal requirements for spending a point of Determination still apply."
                }
            },
            new()
            {
                Name = "Self-Reliant",
                Weight = 1,
                AttributeRequirements = new CharacterAttributes { Control = 11 },
                Description = new List<string>
                {
                    "Whenever you succeed at a task where you did not purchase additional dice by spending Momentum or adding to Threat, you generate bonus Momentum equal to the task’s Difficulty. Bonus Momentum cannot be saved."
                }
            },
            new()
            {
                Name = "Shared Joy",
                Weight = 1,
                Description = new List<string>
                {
                    "When you take a break to recover Stress (see page 278 of the core rulebook) and engage in an activity related to your pastime, you may invite an ally to join you. If you do so, you both may regain up to 10 Stress (instead of the normal 8), and immediately add 2 points to the group Momentum pool due to boosted morale.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Show-Off",
                Weight = 2,
                AttributeRequirements = new CharacterAttributes { Presence = 9 },
                Description = new List<string>
                {
                    "You tend to show off, sometimes doing things the hard way just to demonstrate that you can. When you attempt a task, you may choose to increase the Difficulty by 1. If you succeed, you gain 2 bonus Momentum. Bonus Momentum cannot be saved.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Studious",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you spend 1 or more Momentum to Obtain Information, you may ask one additional question (in total, not per Momentum spent on Obtain Information)."
                }
            },
            new()
            {
                Name = "Supportive",
                Weight = 1,
                Description = new List<string>
                {
                    "You have a close bond with another character, and will support them through any hardship. Select one other Main Character in the group. Whenever you spend Momentum to recover their Stress, you reduce the Momentum cost to 1 (allowing you to recover 1 of their Stress by spending 1 Momentum).",
                    "You may select this talent multiple times, selecting a different character each time. You may not select the same character for both Rivalry and Supportive."
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Suppressive Fire",
                Weight = 1,
                Description = new List<string>
                {
                    "You know a few shots from a phaser can keep the enemy’s head down, even if they’re off-target. When you miss with a ranged attack, you may add 1 Threat to add a Suppressed trait (or similar effect) on the target. The target can only remove this trait if they are in Cover.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Swift",
                Weight = 2,
                AttributeRequirements = new CharacterAttributes { Fitness = 9 },
                Description = new List<string>
                {
                    "You’re quick on your feet. When you take the Movement minor action or the Sprint major action, you may spend 1 Momentum (Immediate) to move up to one additional zone.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Technical Expertise",
                Weight = 1,
                Description = new List<string>
                {
                    "Whenever you attempt a task assisted by the ship’s Computers or Sensors, you may re-roll one d20 in your pool, or you may allow the ship to re-roll its d20."
                }
            },
            new()
            {
                Name = "Tough",
                Weight = 1,
                Description = new List<string>
                {
                    "Your maximum Stress is increased by 2."
                },
                StressModifier = 2
            },
            new()
            {
                Name = "True North",
                Weight = 1,
                Description = new List<string>
                {
                    "You rarely lose your way. When on a planet, or within a ship or space station, you always retain an accurate sense of your direction (on a planet, you always know which direction is north; on a ship, you can tell which way is forward; on a station, you can tell which way is the center), and the Difficulty of any task for you to determine your location is reduced by 2, to a minimum of 0, just by observing visible landmarks or other signs.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Voice of Authority",
                Weight = 2,
                AttributeRequirements = new CharacterAttributes { Presence = 11 },
                Description = new List<string>
                {
                    "When you Assist someone, and use your Presence to do so, you may add 2 Threat to treat your assistance die as if it had rolled a 1 instead of rolling it."
                }
            },
            new()
            {
                Name = "Walk it Off",
                Weight = 2,
                AttributeRequirements = new CharacterAttributes { Fitness = 11 },
                Description = new List<string>
                {
                    "You don’t let injuries bother you. The first time each adventure you avoid an Injury, the Injury’s severity is treated as 1: the injury was just a flesh wound, and not worth your attention.",
                },
                Source = BookSource.ExplorationGuide
            },
            new()
            {
                Name = "Well Informed",
                Weight = 1,
                Description = new List<string>
                {
                    "You have contacts everywhere and you listen to news and rumors from far and wide. At the start of a scene, you may add 1 Threat to ask the gamemaster two questions about the situation or location, as if you had spent Momentum on the Obtain Information spend. The answers you receive will be knowledge you’ve gained from your contacts and the news and rumors you’ve heard."
                }
            },
        };
    }

    private static List<Talent> GetSpeciesAndCultureTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Proud and Honorable",
                TraitRequirement = SpeciesName.Andorian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Whenever you attempt a task to resist being coerced into breaking a promise, betraying your allies, or otherwise acting dishonorably, you may add Threat to immediately succeed at the task. The amount of Threat you add is equal to the task’s Difficulty."
                }
            },
            new()
            {
                Name = "The Ushaan",
                TraitRequirement = SpeciesName.Andorian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You are experienced in the tradition of honor-dueling known as the Ushaan. When you make a Melee Attack, or are targeted by a Melee Attack, and buy one or more d20s by adding to Threat, you may re-roll any number of dice in your dice pool for the task. Further, you own an Ushaan-tor, a razor-sharp ice-miner’s tool used in these duels. The Ushaan-tor is a blade, and it counts as standard issue for you."
                }
            },
            new()
            {
                Name = "Biosynthetic Construction",
                AnyTraitRequirement = new List<string> { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid },
                Weight = 20,
                MayNotTakeWithTalents = { "Duranium Polyalloy Construction" },
                Description = new List<string>
                {
                    "Though you are an android, your construction is almost indistinguishable from that of a living creature. You gain one additional species trait: this is the species you appear to be. To determine that you are an android, an observer must examine you closely with a tricorder or similar tool, and succeed at a Reason + Engineering or Reason + Medicine task with a Difficulty of 3. Your injuries may be healed using either Engineering or Medicine. You may not take the Duranium Polyalloy Construction talent."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Duranium Polyalloy Construction",
                AnyTraitRequirement = new List<string> { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid },
                Weight = 20,
                MayNotTakeWithTalents = { "Biosynthetic Construction" },
                ProtectionModifier = 1,
                Description = new List<string>
                {
                    "Your physical form has been constructed from extremely durable materials, and your resilience and physical capabilities are formidable. You have +1 Protection against all attacks (this stacks with the Protection gained from your species ability). In addition, you add 1 automatic success to all task rolls using your Fitness. You may not take the Biosynthetic Construction talent."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Acute Senses",
                TraitRequirement = SpeciesName.Aenar,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The Aenar have honed their senses to the point that they are able to respond to stimuli just as well as, if not superior to, those who possess the ability to see. When attempting a task to detect something which is hidden from conventional senses, or which would normally be difficult to perceive, you may re-roll 1d20."
                }
            },
            new()
            {
                Name = "Chosen Speaker",
                TraitRequirement = SpeciesName.Aenar,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Among Aenar communities, leaders and mediators are chosen as and when the need arises, nominating an individual to serve as Speaker. You’ve been chosen for this role often and are adept at using your senses and your telepathy to aid communication. When attempting a task to communicate telepathically with a willing being, you may re-roll 1d20."
                }
            },
            new()
            {
                Name = "Airborne Advantage",
                AnyTraitRequirement = new List<string> { SpeciesName.Aurelian, SpeciesName.AurelianNovolare },
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You’re quick to take advantage of the fact that most other sapient species are stuck on the ground and seldom look up. When you make an attack against an enemy who is below you, you may reroll 1d20, and you score 1 bonus Momentum if your attack succeeds. Bonus Momentum cannot be saved."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "An Eye on the Horizon",
                AnyTraitRequirement = new List<string> { SpeciesName.Aurelian, SpeciesName.AurelianNovolare },
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The Aurelians’ keen eyesight allows them to discern distant details when flying overhead. This mindset often influences Aurelians in other ways, giving them a tendency to try and anticipate problems a long way off. Each time you or another player character in the same scene as you attempt a task roll where the complication range has been increased, you may spend 1 Momentum to negate that complication range increase: the complication range of that task reverts to normal (i.e., a complication arises on a result of 20)."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Strong Pagh",
                TraitRequirement = SpeciesName.Bajoran,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You believe profoundly in the Prophets, and you rely upon that faith to see you through hardship. Whenever you attempt a task to resist being coerced or threatened, you may take Stress equal to the Difficulty of the task to automatically succeed."
                }
            },
            new()
            {
                Name = "Orb Experience",
                TraitRequirement = SpeciesName.Bajoran,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have received a vision from the Bajoran Prophets, through one of the Orbs. This rare experience, though confusing at first, has shaped your life and outlook. You have one additional value, which represents some prophecy or insight into the future gained from your vision. Furthermore, once per session, when that value is used, you gain twice the normal benefit: if you spend Determination, you may gain two benefits listed, while if you would gain Determination, you gain 2 points instead of 1."
                }
            },
            new()
            {
                Name = "Expert Quartermaster",
                TraitRequirement = SpeciesName.Barzan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The Barzan people have long had to make do with less, and this has taught them to be especially considerate of all resources at their command. When attempting a task to salvage resources, materials, or components from existing items, you may reroll 1d20. Further, once per session, when you obtain equipment with an opportunity cost, you may reduce that cost by 1, to a minimum of 0."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Strive and Sacrifice",
                TraitRequirement = SpeciesName.Barzan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You push yourself harder when your effort makes the difference between your kin or crew succeeding or failing. When you assist an ally, you may suffer 1 Stress to reroll your assistance die."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Meticulous Analysis",
                TraitRequirement = SpeciesName.Benzite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you succeed at a task to scan or study unidentified phenomena, you may spend 2 Momentum to immediately make an additional Difficulty 0 task roll using the Reason + same department, and the same focus. You may not purchase additional dice on this task roll, and any successes you generate immediately become Momentum added to your previous task’s result."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Thorough and Methodical",
                TraitRequirement = SpeciesName.Benzite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You’re careful in everything you do, and do not stray from the proper way of doing things lightly. When you attempt a task using Reason, and purchase one or more dice by spending Momentum, you may pick a single die in your dice pool and treat it as if it had rolled equal to your target number for that task (and is thus a success) instead of rolling it. However, you may not spend any Momentum to reduce the amount of time the task took to perform. You cannot use this talent’s benefit if you are the first character to act during a round in combat."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Open Book",
                TraitRequirement = SpeciesName.Betazoid,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When a character enters a scene, you may spend 1 Momentum (Immediate) to immediately ask the gamemaster one question about that character’s current emotions or surface thoughts. You cannot do this for characters immune to telepathy."
                }
            },
            new()
            {
                Name = "Abrupt Insights",
                TraitRequirement = SpeciesName.Betazoid,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your insight into the minds of others can give you an edge when interacting with them, though not everyone is comfortable having someone else speak their mind. When you attempt a task as part of a social conflict, you can increase the complication range by 1, 2, or 3; if you succeed, you generate bonus Momentum equal to the complication range increase. Bonus Momentum may not be saved."
                }
            },
            new()
            {
                Name = "Strength of the Elders",
                TraitRequirement = SpeciesName.Betelgeusian,
                Weight = 10,
                Description = new List<string>
                {
                    "Betelgeusians are descended from predators who used speed and ferocity to overwhelm their prey. In modern times, Betelgeusian martial traditions emphasize swift, precise strikes to overwhelm a foe. A Betelgeusian may use Fitness + Security rather than Daring + Security to make melee attacks. In addition, the injuries inflicted by their melee attacks increase in Severity by 1."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Verbal Warfare",
                TraitRequirement = SpeciesName.Betelgeusian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Engaging in debate is one of the highest forms of expression in Betelgeusian culture, and a Betelgeusian who deigns to engage someone in argument is considered to be giving them a great gift. When you win an opposed task during a social conflict, you generate 2 bonus Momentum. Bonus Momentum cannot be saved."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Born Near a Warp Core",
                TraitRequirement = SpeciesName.Bolian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Bolian traditions say that a child born near an active warp core has an improved, more positive, disposition. Optimism and an upbeat attitude certainly lends credence to this tradition, allowing the Bolian to weather misfortune. When you suffer a complication from a task, roll a d20; if the result is equal to or under your Presence rating, ignore the complication. You may ignore one complication per scene in this way."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Warm Welcome",
                TraitRequirement = SpeciesName.Bolian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "A cheerful, outgoing personality is the perfect thing to put diplomatic guests at ease. Whenever you assist another character on a social task, the ally being assisted may use your Presence rating instead of their own. Further, you may reduce the Threat cost to assist for that task by 1, to a minimum of 0."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Collective Insights",
                TraitRequirement = TraitName.Borg,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You still have extensive knowledge from your time in the Borg Collective, though your knowledge may be accompanied by horrific memories of your experiences as a drone. Once per session, when you attempt a task, you may suffer 1 Stress to gain one additional focus of your choice for the remainder of the current session. The focus should reflect some knowledge that the Borg Collective would have assimilated, and thus should not be any subject which the Borg would deem irrelevant.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "The Pursuit of Perfection",
                TraitRequirement = TraitName.Borg,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "While you are free from the Collective, some aspects of Borg existence still resonate with you; the pursuit of perfection is worthy, but only your own terms. When you make a task roll, you may suffer 1 Stress to reroll any die which would cause a complication. You may do this on as many dice as you like on each task roll.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Cold Warrior",
                TraitRequirement = SpeciesName.Breen,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your use of a refrigeration suit is a great asset. When you attempt a task to conceal yourself from technological forms of detection, you may select one d20 and treat it as though you had rolled a 1, as your refrigeration suit masks your thermal signature and disrupts other signals you may give off."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Disregard for Hardship",
                TraitRequirement = SpeciesName.Breen,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You are ruthless and determined, and hold little regard for the pain it takes to achieve your goals. Whenever you use a value or Directive positively, recover 4 Stress. You may regain Stress in this way even if you are Fatigued."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Ablative Hide",
                TraitRequirement = SpeciesName.Brikar,
                Weight = 10,
                Description = new List<string>
                {
                    "Your hide is especially dense and resilient, allowing you to endure severe impacts; further, even against severe impacts that could hurt you, surface layers of your rocky hide flake away, diffusing the blow. Your Protection is increased to 3, and your maximum Stress is increased by 3.",
                },
                ProtectionModifier = 1,
                StressModifier = 3,
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Massive",
                TraitRequirement = SpeciesName.Brikar,
                Weight = 10,
                Description = new List<string>
                {
                    "You’ve grown larger and rockier with age. Whenever you attempt a Fitness-related task, you add one automatic success due to your sheer size and physical presence. You also increase the Severity of all melee attacks by 1. Additionally, you carry a Gravity Compensator (equipment trait) to aid your movement, and if this is lost or damaged, you suffer difficulties moving around easily in non-Brikar gravity levels.",
                },
                TraitGained = "Gravity Compensator (equipment)",
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Entangled Consciousness",
                TraitRequirement = SpeciesName.Bynar,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your mind and that of your partner are so connected that you can draw on their expertise almost without effort. When you attempt a task, you may spend 1 Momentum (Immediate) to use one of your partner’s focuses instead of one of your own. Alternatively, you may spend 2 Momentum (Immediate) to use one of your partner’s talents for the remainder of the scene.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Synchronistic Operation",
                TraitRequirement = SpeciesName.Bynar,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You work in perfect concert with your partner. When you attempt a task and your partner assists you (or vice versa), each of you may reroll one d20. Further, if you are task leader and your partner is assisting (or vice versa), then the assistant’s successes still count even if the task leader scores no successes of their own.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Disarming Nature",
                TraitRequirement = SpeciesName.Caitian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Some Caitians are extremely social beings, adept at putting others at ease. Whenever you attempt a task to make another creature relax or trust you, you may reduce the Difficulty by 1. If this is part of an extended task, your Impact is increased by 1.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Feral Aggression",
                TraitRequirement = SpeciesName.Caitian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Some Caitians tend towards a territorial manner, reacting to threats with anger, and pain with defiance. You gain 1 Protection, and whenever you suffer a trait that represents pain or fear, you may add 1 Threat to remove that trait immediately.",
                },
                ProtectionModifier = 1,
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Regimented Mind",
                TraitRequirement = SpeciesName.Cardassian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you spend Momentum to Obtain Information, you may reduce the Difficulty of one task later in the same scene by 1, so long as that task relates to the information gained."
                }
            },
            new()
            {
                Name = "The Ends Justify the Means",
                TraitRequirement = SpeciesName.Cardassian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you spend Determination because of a Directive, you may select two of the benefits for spending Determination, rather than one."
                }
            },
            new()
            {
                Name = "Song of the Ocean",
                TraitRequirement = SpeciesName.Cetacean,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your innate echolocation capabilities—sometimes called biosonar—are especially well-honed and precise. When attempting to detect fine details of your environment, notice the movement of other objects or creatures, or navigate a complex path through that environment, or communicate with other aquatic creatures capable of echolocation, you ignore all normal penalties for distance: you can perceive and communicate clearly up to 100 kilometers away.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Three-Dimensional Thinking",
                TraitRequirement = SpeciesName.Cetacean,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You possess a knack for navigating in three-dimensional spaces which terrestrial species tend to lack, and you’ve trained to adapt that capability to starship navigation. Whenever you attempt a task to pilot or navigate a starship (normally using Conn), and suffer any complications, you may spend 1 Momentum (Immediate, Repeatable) to ignore a complication.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Anatomical Expertise",
                TraitRequirement = SpeciesName.Chameloid,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You’re well-versed in the anatomical strengths and weaknesses of different species, as only someone who has worn many skins can. When you create a trait that represents knowing a particular anatomical or physiological weakness possessed by a specific species, the Difficulty of the task to create that trait is reduced by 1, or the Momentum cost of that trait is reduced by 1.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Rapid Shift",
                TraitRequirement = SpeciesName.Chameloid,
                Weight = 10,
                Description = new List<string>
                {
                    "You are especially swift and efficient at shapeshifting, and no longer suffer Stress to assume another form. Further, you do not require a minor action to shapeshift, but you may only assume a new form at most twice per round when action order is being used.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Altered Changeling",
                TraitRequirement = SpeciesName.Changeling,
                Weight = 10,
                Description = new List<string>
                {
                    "Through torturous experimentation and exposure to thelomium-847, the nature of your morphogenic matrix has been altered. When you adopt the form of a living being, you may mimic the form of a specific individual, taking their appearance and personality to a degree that it is nearly impossible for others to determine your nature, even with blood tests or extensive bio-screening, and you may retain that form indefinitely. Increase the Potency of the trait you gain when you assume that form by 2. However, it costs 2 Stress for you to change form, and you are no longer immune to exposure to vacuum.",
                },
                MayNotTakeWithTalents = { "Morphogenic Mastery" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Morphogenic Mastery",
                TraitRequirement = SpeciesName.Changeling,
                Weight = 10,
                Description = new List<string>
                {
                    "When you assume an alternate form, you may mimic the form of a specific individual, taking their appearance and personality sufficiently that even close friends may not be able to discern the truth: increase the Potency of the trait you gain when you assume that form by 1. You are no longer required to revert to a liquid state to rest.",
                },
                MayNotTakeWithTalents = { "Altered Changeling" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Deltan Pheromones",
                TraitRequirement = SpeciesName.Deltan,
                Weight = 10,
                Description = new List<string>
                {
                    "You emit aphrodisiac pheromones which can influence or distract others. When dealing with creatures affected by your pheromones, you gain 3 bonus Momentum on all tasks to persuade them, but you increase the complication range of that task roll by 2, as their behavior can become unpredictable. Bonus Momentum cannot be saved. Most species are affected, but gamemaster’s discretion applies as to which species may be resistant or affected. Deltans without this talent are assumed to regularly take biochemical suppressants to counteract their pheromones.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Empathic Touch",
                TraitRequirement = SpeciesName.Deltan,
                Weight = 10,
                Description = new List<string>
                {
                    "You’ve practiced your empathic abilities, and you can influence the emotions of others in close proximity, and can even relieve physical pain. When you attempt a task to try and persuade, provoke, or manipulate a living creature, you may suffer 2 Stress to create or remove an emotion-related trait from them before you roll. Further, if you spend Momentum to recover an ally’s Stress, the cost is reduced to 1 as long as you’re touching them.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Cultural Flexibility",
                TraitRequirement = SpeciesName.Denobulan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You are at ease when meeting new cultures, and you adapt to unfamiliar social structures easily. When you attempt a task to learn about an unfamiliar culture, or to act in an appropriate manner when interacting with members of such a culture, you may re-roll 1d20."
                }
            },
            new()
            {
                Name = "Parent Figure",
                TraitRequirement = SpeciesName.Denobulan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have a large family, with many children, nieces, and nephews, and you’ve learned how to coordinate even the most unruly and fractious of groups when necessary. When attempting or assisting a task, and two or more other characters are involved in the task, the first complication generated on the task—either by the character attempting the task, or one of the assistants—may be ignored."
                }
            },
            new()
            {
                Name = "The Long View",
                TraitRequirement = SpeciesName.Edosian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Due to their extremely long lifespans, Edosians often accumulate a wealth of knowledge. When you select this talent, gain two additional focuses.",
                },
                AdditionalFocuses = 2,
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Multi-Tasking",
                TraitRequirement = SpeciesName.Edosian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have much greater ease with performing multiple simultaneous tasks. You may perform one additional minor action per turn for free.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Geospatial Awareness",
                TraitRequirement = SpeciesName.Efrosian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The Efrosians are believed to have evolved a keen sense of direction from a need to navigate the blinding snowstorms of their homeworld. Whether this is true or not, you have an especially keen sense of spatial awareness. When attempting to determine a course or path through an unknown territory—whether on a planetary surface, within an artificial environment (such as a ship, city, or space station), or when navigating through space, you may always reroll 1d20, and you may ignore the first complication suffered.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Oral Scholar",
                TraitRequirement = SpeciesName.Efrosian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Efrosians pass on much of their knowledge through oral practices or by rote. Whenever you spend 1 or more Momentum to Obtain Information after a successful task using one of your focuses, you may ask one additional question for free.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Listener",
                TraitRequirement = SpeciesName.ElAurian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Even among a species known for listening to others, you’re practiced at gleaning insights from the smallest interactions. Once per scene, when you have observed or conversed with another person, you may spend 1 Momentum (Immediate) to ask one question about them, as per Obtain Information. This question must be about their mental state, emotions, or a dilemma they are currently grappling with. Further, if a character spends a breather or break rest talking to you about their problems, they recover 1 additional Stress.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Touched the Nexus",
                TraitRequirement = SpeciesName.ElAurian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "In 2293, you and 46 other El-Aurians aboard the S.S. Lakul were rescued from an extradimensional energy ribbon known as the Nexus by the U.S.S. Enterprise-B. While you were physically pulled from the Nexus by the Enterprise’s transporters, an echo of you still lingers within the Nexus: a tiny piece of yourself left behind which you remain aware of. This has heightened your awareness of changes in time and space: when you use your Transtemporal Awareness ability, the first question you ask is free, and you may purchase up to two additional questions by adding Threat.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Enhanced Thrusters",
                TraitRequirement = SpeciesName.Exocomp,
                Weight = 10,
                Description = new List<string>
                {
                    "You have upgraded your motive systems to help you maneuver more effectively. When you move across difficult terrain or obstacles, you may reduce the Momentum cost of that terrain by 1, to a minimum of 0. Further, you may suffer Stress—representing depleting your own internal power supply—to cross difficult terrain or obstacles instead of spending Momentum.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Extra Power Supply",
                TraitRequirement = SpeciesName.Exocomp,
                Weight = 10,
                Description = new List<string>
                {
                    "You’ve installed a supplementary power supply to help you remain functional for longer and perform more challenging tasks. Your Maximum Stress is increased by your Engineering rating.",
                },
                AddDepartmentToStress = DepartmentName.Engineering,
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Greed is Eternal",
                TraitRequirement = SpeciesName.Ferengi,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When engaged in negotiations—including in social conflict— that have the potential for you to profit personally, you may add 1 Threat to re-roll your dice pool."
                }
            },
            new()
            {
                Name = "Never Place Friendship Above Profit",
                TraitRequirement = SpeciesName.Ferengi,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you assist someone else (including using the Direct action), and one or more complications occur, you may add 1 Threat to avoid suffering any ill-effect from that complication (other characters involved are affected normally)."
                }
            },
            new()
            {
                Name = "Communal",
                TraitRequirement = SpeciesName.Grazerite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You’re used to communal effort, and you work well in coordination with others. Whenever you assist another character, you always count as having an applicable focus. If you do have an applicable focus, you may reroll your assistance die.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Horn-Sense",
                TraitRequirement = SpeciesName.Grazerite,
                Weight = 10,
                Description = new List<string>
                {
                    "A small minority of Grazerites are born with a genetic variance that causes their horns to be hollow. This gives them a highly sensitive organ that can detect subtle changes in air pressure, sound, and all manner of vibrations. When you attempt a task that involves the detection or analysis of sound or vibrations of any kind, the first additional d20 you purchase is free.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Expanded Programming",
                TraitRequirement = SpeciesName.Hologram,
                Weight = 10,
                Description = new List<string>
                {
                    "Your program has been expanded considerably, and even includes interests beyond the scope of your original programming. You may select up to two additional focuses. In addition, you may select a pastime.",
                },
                AdditionalFocuses = 2,
                GainPastime = true,
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Mobile Emitter",
                TraitRequirement = SpeciesName.Hologram,
                Weight = 10,
                Description = new List<string>
                {
                    "You have a device that allows you a degree of autonomy from fixed holo-emitters. Most of these mobile emitters are bulky, awkward pieces of equipment with a limited amount of power, making them useful only for short periods and emergencies, but the technology is improving. While you have your mobile emitter, you can move freely in places that lack holo-emitters. However, the device is vulnerable, which reduces your Protection by 1.",
                },
                ProtectionModifier = -1,
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Old as Dirt",
                TraitRequirement = SpeciesName.Horta,
                Weight = 10,
                Description = new List<string>
                {
                    "Horta can live to be thousands of years old, and while few have any experiences of the wider universe prior to first contact with them in 2267, their potential for accumulated wisdom is considerable. When you attempt a task for which you have an applicable focus, you may spend Determination to automatically succeed at that task roll, as long as the task’s Difficulty is lower than the department you would use on that roll (for example, if you attempt a task using Science, and you have Science rating of 4, you may spend Determination to auto-succeed at the task if it has a Difficulty of 3 or less).",
                },
                Source = BookSource.SpeciesSourcebook
            },
             new()
            {
                Name = "Tunnel-Wise",
                TraitRequirement = SpeciesName.Horta,
                Weight = 10,
                Description = new List<string>
                {
                    "All Horta can sense the chemical and mineral composition of the rocks and other objects around them, using a mixture of olfactory and vibrational senses. You’ve honed your senses to a masterful degree, allowing you to discern oddities, impurities, and other abnormal phenomena. Your sense of smell and your vibrational senses can discern fine details that other living creatures cannot detect without the use of high-tech scanners, and when you attempt to discern hidden or obscured details while within a subterranean environment, you may reroll 1d20.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Resolute",
                TraitRequirement = SpeciesName.Human,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your Maximum Stress increases by an amount equal to your Command rating."
                },
                AddDepartmentToStress = DepartmentName.Command
            },
            new()
            {
                Name = "Spirit of Discovery",
                TraitRequirement = SpeciesName.Human,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have an additional option you may pick when you spend Determination: you may immediately add 3 Momentum to the group pool."
                }
            },
            new()
            {
                Name = "Augmented Immunity",
                AllTraitsRequirement = new List<string> { SpeciesName.Illyrian, TraitName.Augment },
                Weight = 20,
                Description = new List<string>
                {
                    "Your immune system has been altered to burn out toxins and diseases. Whenever you would be affected by toxins or diseases, you may add 1 Threat to immediately eliminate the infectious agent and ignore the effect. You visibly glow when this occurs."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "The Shroud",
                TraitRequirement = SpeciesName.JemHadar,
                Weight = 10,
                Description = new List<string>
                {
                    "You have honed the Jem’Hadar ability to conceal yourself from the enemy. Using the Prepare minor action, you may shroud yourself, becoming nearly invisible. You gain the Shrouded trait. While shrouded, tasks to detect or locate you increase in Difficulty accordingly, and you cannot be the target of an attack unless the attacker has found some other way to detect you. This ends when you make an attack or when you take another Prepare minor action to end the effect. You cannot use this ability when deprived of ketracel-white."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Victory is Life!",
                TraitRequirement = SpeciesName.JemHadar,
                Weight = 10,
                Description = new List<string>
                {
                    "During a scene, whenever you defeat an enemy or achieve a specific objective commanded by your superior (or a mission Directive), recover 3 Stress instantly. The gamemaster may veto any objectives they deem too trivial or exploitable."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Out of Necessity",
                TraitRequirement = SpeciesName.Kellerun,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You are willing to take whatever action is necessary to achieve the best outcome, even if that action might be dangerous or destructive in the short term. Once per mission, when you take an action that would cause escalation (such as using lethal force on an attack), you may insist that the action is necessary: if you do so, you ignore the normal escalation for that action as long as the action itself was successful. You may also reroll 1d20 on any task roll to try and use intimidation or threats to force an enemy to back down from a fight."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Pragmatic Professional",
                TraitRequirement = SpeciesName.Kellerun,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The niceties of leadership and teamwork concern you less than the outcome of your endeavors. When you attempt a task with assistance from another character, or assist another character’s task, any character involved in the task may suffer 1 Stress to reroll 1d20."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Predator’s Insight",
                AllTraitsRequirement = { SpeciesName.Kelpien, TraitName.PostVaharai },
                Weight = 10,
                Description = new List<string>
                {
                    "You have a heightened awareness that has been honed to allow you to discern the flaws and vulnerabilities in your prey. Whenever you succeed at a task to study or scrutinize a person or starship, you reduce the cost to create a trait—which must represent some weakness you’ve identified—by 1."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Threat Awareness",
                AllTraitsRequirement = { SpeciesName.Kelpien, TraitName.PreVaharai },
                Weight = 10,
                Description = new List<string>
                {
                    "You are keenly aware of every potential threat around you, and you act accordingly. At the start of each scene, if the total number of points in the Threat pool exceeds twice the number of players, add 1 Momentum to the group pool."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Killer's Instinct",
                TraitRequirement = SpeciesName.Klingon,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "So familiar are you with the intent to kill that you can even see it in others when you look them in the eyes. When you make a Deadly Attack, reduce the amount you add to Threat to 0. In addition, when an enemy attempts to make a Deadly Attack against you, you may add 1 Threat to increase the Difficulty of their Attack by 1, as you react to their intent."
                }
            },
            new()
            {
                Name = "To Battle!",
                TraitRequirement = SpeciesName.Klingon,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you buy additional dice for a melee attack using Threat, you increase the Severity of your melee attack by 1."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Warrior's Spirit",
                TraitRequirement = SpeciesName.Klingon,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you make a Melee Attack, or are targeted by a Melee Attack, and you buy one or more d20s by adding Threat, you may re-roll the dice pool for your task roll. Further, you own either a mek’leth (a blade) or a bat’leth (a heavy blade) at your discretion, which counts as standard issue for you."
                }
            },
            new()
            {
                Name = "Culinary Comforts",
                TraitRequirement = SpeciesName.Klowahkan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You cannot let the culinary traditions of your people sit idle, so you combine them with your duties where possible. You have the Ship’s Cook or Ship’s Chef role, in addition to any other role. Further, the amount of Stress you and your allies recover when you cook is increased by 2."
                },
                SpecificExtraRole = { RoleName.ShipsCook, RoleName.ShipsChef },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "The Spice of Life",
                TraitRequirement = SpeciesName.Klowahkan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You are eager to explore all that life has to offer, in all its varieties, and you prize yourself on being versatile enough to embrace those different experiences. Each time you use a particular attribute + department combination for the first time during the current mission, add 1 Momentum to the group pool before you roll."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "From a Place of Strength",
                TraitRequirement = SpeciesName.Ktarian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Ktarians are loath to enter into negotiations, or any other situation, unless they feel they are at an advantage. Once per scene, when you attempt a task, you may select one trait that currently benefits you on that task; you may increase that trait’s Potency by 1 for the duration of that task."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Relentless",
                TraitRequirement = SpeciesName.Ktarian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Ktarians are known to face adversity with resolve, adapting to and enduring whatever obstacles arise in their path. Whenever you gain or spend Determination, recover 2 Stress."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Bait for the Carrion Reaver",
                TraitRequirement = SpeciesName.Kwejian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "“Never return from a hunt without enough bait for the carrion reaver” is an old Kwejian saying, cautioning hunters against greed or recklessness that might lead other trouble—such as predators—back to a community. At the end of a scene, you may spend up to 3 Momentum from the group pool to remove the same number of Threat points, as you watch out for potential perils and take precautions against them."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Natural Bond",
                TraitRequirement = SpeciesName.Kwejian,
                TalentRequirement = TalentName.Empathy,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your connection to the natural world is deep and powerful. You may attempt to influence the behavior and actions of animals with your empathic abilities, projecting emotions into them with a Presence + Command task roll; the Difficulty is determined by the gamemaster, based on how complex an influence you wish to have, and how cooperative the creature is. You may also attempt to influence plants in a similar way, stimulating particular behaviors and autonomic responses in them."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Kzinti Telepath",
                TraitRequirement = SpeciesName.Kzinti,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You belong to the portion of Kzinti who have limited telepathic abilities. This functions as per the Telepathy talent (page 156 of the core rulebook), but each time you attempt to read the thoughts of another creature, you suffer 1 Stress. Further, when you attempt to read the mind of an enemy, they may suffer 2 Stress (or, for NPCs, spend 2 Threat) to force you out of their mind by concentrating on thoughts, imagery, and feelings which disgust you: commonly, this is the memory of eating fruits and vegetables, as these are inedible and unpalatable to Kzinti."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Predatory Posture",
                TraitRequirement = SpeciesName.Kzinti,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your size, fangs, and body language all contribute to an aura of danger and menace which you can wield as well as any weapon. You may adopt a predatory stance, hunched and looming menacingly over others, during any scene by adding 2 Threat. For the remainder of the scene, you may reroll 1d20 on any task roll to threaten, coerce, or intimidate others, and when you make a Deadly Attack, you reduce the amount you add to Threat to 0."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Ancient Expertise",
                TraitRequirement = SpeciesName.Lanthanite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "While all Lanthanites pick up a lot of eclectic knowledge over their long lives, some devote themselves to mastering some of that knowledge. Select one department with a rating of 4 or 5. Whenever you attempt a task roll using that department but do not have an applicable focus, you may spend 1 Momentum to count as having an applicable focus for that task roll."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Esoteric Experiences",
                TraitRequirement = SpeciesName.Lanthanite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You’d be surprised at the weird things someone learns over a couple of millennia of life. When you attempt a task roll which uses any department with a rating of 1 or 2, you may add 2 Threat to pick a different department and any one focus you possess and explain how that unlikely combination actually applies to the current situation. If the gamemaster is convinced, you may use that department and focus."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Into the Breach",
                TraitRequirement = SpeciesName.Lurian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Life is not worth living to a Lurian if there is not some risk involved. Always willing to dare greater than others, the Lurian finds that the real thrill lurks just beyond the edge of danger and that is what they should strive for even if their comrades do not. When you succeed at a task roll using Daring, you generate 1 bonus Momentum. Bonus Momentum cannot be saved."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Put Your Hearts into It",
                TraitRequirement = SpeciesName.Lurian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "There’s no point in doing something unless you’re going to give it your all. When you succeed on a task where you purchased three additional dice, you score 3 bonus Momentum. Bonus Momentum cannot be saved."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Containment Suit",
                TraitRequirement = SpeciesName.Medusan,
                Weight = 25,
                Description = new List<string>
                {
                    "You have replaced your containment pod with a fully mobile containment suit, which allows you to interact with corporeal beings without harming them. You gain a Containment Suit trait. Your suit has two arms and two legs, allowing you to move around and operate technology as a humanoid would, and it is sealed in such a way that others are not exposed to your form."
                },
                TraitGained = "Containment Suit",
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Intuitive Navigator",
                TraitRequirement = SpeciesName.Medusan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Medusans are noted for having refined interstellar navigation to a fine art; their electromagnetic forms allowing them to perceive and interact with space in ways that corporeal life cannot. When you attempt to plot a starship course, you may reduce the Difficulty of the task roll by 2, to a minimum of 0. If the Difficulty is reduced to 0, you also gain 2 bonus Momentum on a successful task. Bonus Momentum cannot be saved."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Lifelike Conveyance",
                TraitRequirement = SpeciesName.Nanokin,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your conveyance is especially realistic, and can pass as a natural member of whatever species it was constructed to resemble. Any attempt to discern that it is artificial requires a task with a Difficulty of 4, even with technological means (as the interior is shielded against sensors). When you take this talent, select a single species for the conveyance to resemble: the conveyance allows you to function as if you had all the physical capabilities of a member of that species. However, your mental faculties are unaffected, and if you behave in a manner unexpected for a typical member of that species, you may draw attention which causes people to scrutinize your conveyance further.",
                    "In addition, an improved autopilot means the conveyance can attempt tasks with a Difficulty of 1 or higher, though it cannot purchase additional d20s by itself."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Inner Workings",
                TraitRequirement = SpeciesName.Nanokin,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have a unique perspective on technology, from being inside that technology. When away from your conveyance, and able to access the inner workings of a device, you may reroll 1d20 on any Engineering task to operate, sabotage, repair, or alter that technology."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Pack Hunter",
                TraitRequirement = SpeciesName.Nausicaan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "There is strength in being able to command others to crush your foes. When you or an ally attacks an enemy who has already been attacked by you or an ally during this current round, the attacker may reroll 1d20 in their dice pool."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Let No Challenge Stand",
                TraitRequirement = SpeciesName.Nausicaan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your pride cannot allow a challenge to go unmet. When you attempt a task to intimidate or attack a character who has intimidated or attacked you previously in the current scene, the first bonus die you purchase is free. While an enemy is present in an action scene who has attempted to threaten or attack you, you must add 1 Threat at the end of each of your turns where you do not attempt to retaliate against them."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Fresh Perspective",
                TraitRequirement = SpeciesName.Ocampa,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Your species’ unique life cycle gives you a distinct perspective that more jaded minds may overlook. Whenever an ally fails a task roll using a focus which you also share, you may add 1 Threat to create a trait which represents the benefits of your perspective."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Quick Learner",
                TraitRequirement = SpeciesName.Ocampa,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You learn quickly from watching others work. When you attempt a task which you have seen another ally attempt during this adventure, the first d20 you purchase is free."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Pheromones",
                TraitRequirement = SpeciesName.Orion,
                GenderRequirement = Gender.Female.ToString(),
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You are capable of emitting pheromones which can render Orion males (and others) suggestible. These pheromones affect several other species—including Humans—in a similar way. When dealing with males of a species affected by these pheromones, you gain 2 bonus Momentum on all tasks to persuade or command them. However, female members of species affected often suffer headaches because of the pheromones, increasing the complication range of tasks to interact with them by 1. Vulcans are known to be unaffected, while Denobulans experience a different effect and become drowsy. The gamemaster’s discretion applies as to which species are affected, which are immune, and which suffer unexpected effects, but most species are affected similarly to Humans and Orions."
                }
            },
            new()
            {
                Name = "That Wasn't Me",
                TraitRequirement = SpeciesName.Orion,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The Orions are known as one of the most untrustworthy species in the Galaxy, next to the Ferengi, and yet people are willing to do business with them or are often tricked or misled by them. You’ve learned the subtle interplay of social interactions, reputations, and plausible denials that allow others to trust you despite what they’ve heard about ‘those other Orions’. When another character attempts a task to determine if they can trust you, you may spend 2 Momentum if you are sincere, or add 2 Threat if you’re attempting to deceive them. Either way, the character does not need to make a task roll: you convince them you are trustworthy."
                }
            },
            new()
            {
                Name = "Cruel",
                TraitRequirement = TraitName.QuchHa,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have a tendency towards ruthlessness and cruelty, and the reputation to match, always seeking to undermine those you wish to destroy before you deal the final blow. When you attempt a task to identify the weaknesses or flaws of an enemy, or matters they are particularly sensitive or protective about, you may reduce the Difficulty by 1. If the enemy has a trait which reflects this weakness (such as an advantage you’ve created, or a complication they’re suffering from), you may reroll a single d20 on the next attack or Persuasion task you attempt against them."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Guile and Cunning",
                TraitRequirement = SpeciesName.Romulan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you attempt to remain hidden or for your actions to remain unnoticed, you may add 1 Threat to add 1 to the Difficulty of any task to detect you or reveal the nature of your actions."
                }
            },
            new()
            {
                Name = "Wary",
                TraitRequirement = SpeciesName.Romulan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you attempt a task to detect an enemy or hazard, you may re-roll one d20."
                }
            },
            new()
            {
                Name = "Learn from the Past",
                TraitRequirement = SpeciesName.Tamarian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "The Children of Tama use stories from their past and their mythology to teach lessons for the future. When you succeed at a task to research or recall historical events, you generate 1 bonus Momentum. Bonus Momentum cannot be saved.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Storyteller",
                TraitRequirement = SpeciesName.Tamarian,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "Tamarian teachers use stories to pass on knowledge to others. These Tamarians are experts at weaving body language, words, and music into lessons that motivate and inspire. When you take a break rest with one or more other characters, roll 1d20. When you take a breather rest with one or more other characters, roll 2d20. For each of these dice that roll equal to or under your Presence, add 1 Momentum to the group pool.",
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Incisive Scrutiny",
                TraitRequirement = SpeciesName.Tellarite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you succeed at a task using Control or Insight, you may ask one question, as if you had spent Momentum to Obtain Information."
                }
            },
            new()
            {
                Name = "Asking the Right Questions",
                TraitRequirement = SpeciesName.Tellarite,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "When you attempt a task that relates to information you’ve received from Obtain Information questions in the current scene, you may re-roll 1d20."
                }
            },
            new()
            {
                Name = "Joined",
                TraitRequirement = SpeciesName.Trill,
                GMPermission = true,
                Weight = 10,
                Symbiote = true, 
                MayNotTakeWithTalents = { "Former Initiate" },
                Description = new List<string>
                {
                    "You are bonded with a symbiont and have lifetimes of memories to draw upon. You gain an additional character trait, which is the name of the symbiont; this reflects potential advantages of being Joined, as well as the ability to perform rites and rituals to awaken past hosts’ memories, and the vulnerabilities inherent in the connection. Furthermore, up to twice per adventure, you may declare that a past Host had experience or expertise in a particular field: you gain an additional focus when you do this, which remains for the rest of the adventure."
                }
            },
            new()
            {
                Name = "Former Initiate",
                TraitRequirement = SpeciesName.Trill,
                GMPermission = true,
                Weight = 10,
                MayNotTakeWithTalents = { "Joined" },
                Description = new List<string>
                {
                    "You joined the Initiate Program, hoping to be chosen by the Symbiosis Commission to become Joined. As there are far more Initiates than there are symbionts, you were one of many who failed, but the capabilities of even a failed Initiate are highly sought after by Starfleet and other organizations. When you attempt a task using Control or Reason, and you spend Determination to set a die as a 1, you may also re-roll your dice pool after the roll. You cannot select this talent if you have the Joined talent."
                }
            },
            new()
            {
                Name = "Kohlinar",
                TraitRequirement = SpeciesName.Vulcan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have undergone the ritual journey to purge all emotion, allowing you to dispassionately observe and dissect your emotional responses and render them powerless. When you ignore emotions using your Mental Discipline Species Ability, you may avoid emotional traits by taking 1 Stress instead of 2, and you no longer increase the potency of emotional traits when Fatigued."
                }
            },
            new()
            {
                Name = "Mind Meld",
                TraitRequirement = SpeciesName.Vulcan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You’ve undergone training in telepathic techniques that allow the melding of minds through physical contact. This always requires a task (normally Control + Sciences) with a Difficulty of at least 1, which can be opposed by an unwilling participant. If successful, you link minds with the participant, sharing thoughts and memories. Momentum may be spent to gain more information or perform deeper telepathic exchanges. This link goes both ways, and it is a tiring and potentially hazardous process. Complications can result in taking Stress, pain, disorientation, or lingering emotional or behavioral difficulties."
                }
            },
            new()
            {
                Name = "Nerve Pinch",
                TraitRequirement = SpeciesName.Vulcan,
                GMPermission = true,
                Weight = 10,
                Description = new List<string>
                {
                    "You have learned numerous techniques for the stimulation and control of nerve impulses—collectively called neuropressure. Some applications of neuropressure can be used to incapacitate assailants swiftly and non-lethally. The nerve pinch counts as a Melee Attack which inflicts Stun Injuries with a Severity of 3 and the Intense quality. You may use Science or Medicine instead of Security when attempting a Nerve Pinch Attack."
                }
            },
        };
    }

    private static List<Talent> GetAugmentAndCyberneticTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Analytical Recall",
                AnyTraitRequirement = new List<string> { TraitName.Augment, TraitName.Cyborg },
                Weight = 20,
                Description = new List<string>
                {
                    "You record everything you perceive, and can recall it with such clarity you can analyze every detail later. You may spend 1 Momentum (and a major action if in combat) to attempt a Reason + Science task with a Difficulty of 0 to replay old memories; Momentum spent may be used to Obtain Information as you analyze details you might have missed before."
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Augmented Ability (Control)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You gain the Extraordinary Control 1 special rule, granting one automatic success on all tasks using Control. When you use this ability, increase the complication range by 2 for that task."
                }
            },
            new()
            {
                Name = "Augmented Ability (Daring)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You gain the Extraordinary Daring 1 special rule, granting one automatic success on all tasks using Daring. When you use this ability, increase the complication range by 2 for that task."
                }
            },
            new()
            {
                Name = "Augmented Ability (Fitness)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You gain the Extraordinary Fitness 1 special rule, granting one automatic success on all tasks using Fitness. When you use this ability, increase the complication range by 2 for that task."
                }
            },
            new()
            {
                Name = "Augmented Ability (Insight)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You gain the Extraordinary Insight 1 special rule, granting one automatic success on all tasks using Insight. When you use this ability, increase the complication range by 2 for that task."
                }
            },
            new()
            {
                Name = "Augmented Ability (Presence)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You gain the Extraordinary Presence 1 special rule, granting one automatic success on all tasks using Presence. When you use this ability, increase the complication range by 2 for that task."
                }
            },
            new()
            {
                Name = "Augmented Ability (Reason)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You gain the Extraordinary Reason 1 special rule, granting one automatic success on all tasks using Reason. When you use this ability, increase the complication range by 2 for that task."
                }
            },
            new()
            {
                Name = "Durability",
                AnyTraitRequirement = new List<string> { TraitName.Augment, TraitName.Cyborg },
                Weight = 20,
                Description = new List<string>
                {
                    "Whether through genetic engineering or cybernetic implants, you’re more durable than most people. You gain Protection 2."
                },
                ProtectionModifier = 2
            },
            new()
            {
                Name = "Heightened Senses (Sight)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "When you select this talent, select a single sense: sight, hearing, smell, taste, or touch. When you attempt a task to perceive or detect something using that sense, reduce the Difficulty by 2, to a minimum of 0. You may also attempt to detect things using that sense which a normal Human could not naturally detect."
                },
                MayNotTakeWithTalents = new List<string> { "Heightened Senses (Hearing)", "Heightened Senses (Smell)", "Heightened Senses (Taste)", "Heightened Senses (Touch)" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Heightened Senses (Hearing)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "When you select this talent, select a single sense: sight, hearing, smell, taste, or touch. When you attempt a task to perceive or detect something using that sense, reduce the Difficulty by 2, to a minimum of 0. You may also attempt to detect things using that sense which a normal Human could not naturally detect."
                },
                MayNotTakeWithTalents = new List<string> { "Heightened Senses (Sight)", "Heightened Senses (Smell)", "Heightened Senses (Taste)", "Heightened Senses (Touch)" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Heightened Senses (Smell)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "When you select this talent, select a single sense: sight, hearing, smell, taste, or touch. When you attempt a task to perceive or detect something using that sense, reduce the Difficulty by 2, to a minimum of 0. You may also attempt to detect things using that sense which a normal Human could not naturally detect."
                },
                MayNotTakeWithTalents = new List<string> { "Heightened Senses (Hearing)", "Heightened Senses (Sight)", "Heightened Senses (Taste)", "Heightened Senses (Touch)" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Heightened Senses (Taste)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "When you select this talent, select a single sense: sight, hearing, smell, taste, or touch. When you attempt a task to perceive or detect something using that sense, reduce the Difficulty by 2, to a minimum of 0. You may also attempt to detect things using that sense which a normal Human could not naturally detect."
                },
                MayNotTakeWithTalents = new List<string> { "Heightened Senses (Hearing)", "Heightened Senses (Smell)", "Heightened Senses (Sight)", "Heightened Senses (Touch)" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Heightened Senses (Touch)",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "When you select this talent, select a single sense: sight, hearing, smell, taste, or touch. When you attempt a task to perceive or detect something using that sense, reduce the Difficulty by 2, to a minimum of 0. You may also attempt to detect things using that sense which a normal Human could not naturally detect."
                },
                MayNotTakeWithTalents = new List<string> { "Heightened Senses (Sight)", "Heightened Senses (Smell)", "Heightened Senses (Taste)", "Heightened Senses (Hearing)" },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Neural Interface",
                TraitRequirement = TraitName.Cyborg,
                Weight = 20,
                Description = new List<string>
                {
                    "You have a cybernetic device implanted directly into your brain, allowing you to interface with computers and similar technologies with their thoughts. Initiating or breaking the link between your mind and a computer system takes a minor action, and while you are connected, you may reroll one d20 on any task using that computer (including a ship’s Computer system). However, if the computer (or the ship containing it) is damaged, you immediately suffer a Deadly 4 Injury with the Piercing quality."
                }
            },
            new()
            {
                Name = "Rapid Comprehension",
                AnyTraitRequirement = new List<string> { TraitName.Augment, TraitName.Cyborg },
                Weight = 20,
                Description = new List<string>
                {
                    "Your mind processes information swiftly, allowing you to learn even advanced concepts very quickly. Once per scene, when you ask questions with Obtain Information, or create a trait that represents researched information, you may spend 1 Momentum (Immediate) to select an additional focus related to those questions or that trait. You gain the benefits of the new focus for the remainder of the current scene."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Regenerative Healing",
                TraitRequirement = TraitName.Augment,
                Weight = 20,
                Description = new List<string>
                {
                    "You have a cybernetic device that replaces one of your senses—most commonly sight or hearing. You gain the Artificial Sense trait, which represents the ways that your senses differ from those of other members of your species. Further, when you attempt a task to locate something hidden or concealed, or to detect details not normally perceptible to that sense, you may re-roll a single d20."
                },
                Source = BookSource.SpeciesSourcebook
            },
            new()
            {
                Name = "Sensory Replacement (Sight)",
                TraitRequirement = TraitName.Cyborg,
                Weight = 20,
                Description = new List<string>
                {
                    "You have a cybernetic device that replaces one of your senses—most commonly sight or hearing. You gain the Artificial Sense trait, which represents the ways that your senses differ from those of other members of your species. Further, when you attempt a task to locate something hidden or concealed, or to detect details not normally perceptible to that sense, you may re-roll a single d20."
                },
                TraitGained = "Artificial Sight"
            },
            new()
            {
                Name = "Sensory Replacement (Hearing)",
                TraitRequirement = TraitName.Cyborg,
                Weight = 20,
                Description = new List<string>
                {
                    "You have a cybernetic device that replaces one of your senses—most commonly sight or hearing. You gain the Artificial Sense trait, which represents the ways that your senses differ from those of other members of your species. Further, when you attempt a task to locate something hidden or concealed, or to detect details not normally perceptible to that sense, you may re-roll a single d20."
                },
                TraitGained = "Artificial Hearing"
            },
            new()
            {
                Name = "Synthetic Physiology",
                TraitRequirement = TraitName.Cyborg,
                Weight = 20,
                Description = new List<string>
                {
                    "Much of your body has been reconstructed with cybernetics. You have Protection 1, which increases by 1 against Stun attacks. Further, when you attempt a task using Fitness, you may suffer 1 Stress to reroll a single d20. Tasks to heal your Injuries use Engineering instead of Medicine."
                },
                ProtectionModifier = 1,
                Source = BookSource.TechnicalManual
            },
        };
    }

    private static List<Talent> GetEsotericTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = TalentName.Empathy,
                GMPermission = true,
                Weight = 20,
                Description = new List<string>
                {
                    "You can sense the emotions of most living beings nearby, and can communicate telepathically with other empaths and telepaths, as well as those with whom you are extremely familiar. You cannot choose not to sense the emotions of those nearby, except for those who are resistant to telepathy. It may require effort and a task to pick out the emotions of a specific individual in a crowd, or to block out the emotions of those nearby. Increase the Difficulty of this task if the situation is stressful, if there are a lot of beings present, if the target has resistance to telepathy, and other relevant factors."
                },
                IsEsoteric = true
            },
            new()
            {
                Name = "Extrasensory Perception",
                GMPermission = true,
                Weight = 20,
                Description = new List<string>
                {
                    "You have an ability to perceive things beyond the normal limits of humanoid senses, allowing you to gain knowledge of people, places, and objects beyond your ability to sense them conventionally. This is known as extrasensory perception, or ESP. It is not directly under your control but instead tends to come in the form of accurate guesses, strong feelings, or flashes of insight. Such sensitivity often leaves you vulnerable to psychic dangers as well. At any point during play, you may ask the gamemaster for hints or insights about the current situation, and the gamemaster may similarly offer you information about the current situation that you would not normally be able to determine. Each hint adds 1 Threat, and you may always refuse to accept the hints offered."
                },
                IsEsoteric = true
            },
            new()
            {
                Name = "Psychokinesis",
                GMPermission = true,
                Weight = 20,
                Description = new List<string>
                {
                    "You can manipulate and control objects using only the power of the mind. You may exert a psychic force upon an object within Close range equivalent to the force that you would normally be able to exert physically, though this takes concentration and cannot be done violently."
                },
                IsEsoteric = true
            },
            new()
            {
                Name = TalentName.TelepathicProjection,
                TalentRequirement = "Telepathy",
                Weight = 20,
                Description = new List<string>
                {
                    "Your telepathic ability is more potent than most, and you are accustomed to projecting your thoughts into other minds. You can send your thoughts into the minds of other creatures—other than those immune to telepathy—even if those creatures are not telepathic themselves. You can ‘hear’ their responses by reading their minds. You are also capable of using this ability offensively, overwhelming a target’s mind with pain-inducing psychic noise. This requires a Presence + Security task with a Difficulty of 2 (increasing by 1 for each range category beyond Close); success inflicts a Stun or Deadly Injury with Severity 3 and the Piercing effect."
                },
                IsEsoteric = true
            },
            new()
            {
                Name = TalentName.Telepathy,
                TraitRequirement = SpeciesName.Deltan,
                GMPermission = true,
                Weight = 20,
                Description = new List<string>
                {
                    "You can sense the surface thoughts and emotions of most living beings nearby, and can communicate telepathically with other empaths and telepaths, as well as those with whom you are extremely familiar. You cannot choose not to sense the emotions or read the surface thoughts of those nearby, except for those resistant to telepathy. It requires effort and a task to pick out the emotions or thoughts of a specific individual in a crowd, to search a creature’s mind for specific thoughts or memories, or to block out the minds of those nearby. Increase the Difficulty if the situation is stressful, if there are many beings present, if the target target is resistant to telepathy, etc."
                },
                IsEsoteric = true
            },
        };
    }

    private static List<Talent> GetExperienceTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = TalentName.UntappedPotential,
                Weight = 0,
                Description = new List<string>
                {
                    "Select one of your attributes when you receive this talent. You’re inexperienced, but talented and with a bright future. You may not have or increase any attribute to above 11, or any department to above 4 while you have this talent (and may have to adjust attributes and departments accordingly at the end of character creation).",
                    "Whenever you succeed at a task for which you bought one or more additional dice (by any means), roll a d20 after the roll. If you roll equal to or less than the chosen attribute, gain 1 bonus Momentum; if you roll higher, add 1 Threat instead. While you possess this talent, you cannot gain any higher rank than Lieutenant (junior grade), or a higher enlisted rate than Petty Officer."
                }
            },
            new()
            {
                Name = TalentName.Veteran,
                Weight = 0,
                Description = new List<string>
                {
                    "You’re wise and experienced, and draw upon inner reserves of willpower and determination in a measured and considered way. Whenever you spend Determination, roll a d20. If you roll equal to or less than your Control rating, you immediately regain that point of Determination. If you are Starfleet or military, you hold a rank of at least lieutenant commander, or an enlisted rate of at least chief petty officer.",
                }
            },
        };
    }

    private static List<Talent> GetCommandTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Advanced Team Dynamics",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                AnyRoleRequirement = new List<string> { RoleName.CommandingOfficer, RoleName.ExecutiveOfficer },
                Weight = 4,
                Description = new List<string>
                {
                    "The first time you introduce a supporting character in a mission, that supporting character may take one additional option to improve the supporting character.",
                },
                MainCharacterOnly = true
            },
            new()
            {
                Name = "Advisor",
                DepartmentRequirements = new DepartmentRequirements { Command = 2 },
                Weight = 2,
                Description = new List<string>
                {
                    "Whenever you Assist another character using your Command, the assisted character may re-roll one d20.",
                }
            },
            new()
            {
                Name = "Bargain",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you use Negotiation to make an offer to someone during social conflict, you may re-roll a single d20 on your next Persuade task to convince that person. If the social conflict with that person involves an extended task, your Impact is increased by 1.",
                }
            },
            new()
            {
                Name = "Bolster",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you succeed at any task using your Command during an action scene, you may spend Momentum to recover Stress suffered by your allies. When you spend 1 Momentum (Repeatable), one ally who can see and hear you recovers 1 Stress. You may affect multiple allies, but each ally affected may only recover 1 Stress in this way each time this talent is used.",
                }
            },
            new()
            {
                Name = "Call Out Targets",
                DepartmentRequirements = new DepartmentRequirements { Command = 3, Security = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "When you Assist a character in an Attack, the assisted character generates 2 bonus Momentum if their Attack succeeds. Bonus Momentum cannot be saved.",
                }
            },
            new()
            {
                Name = "Call to Action",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "In a conflict, you may use the Prepare minor action to grant one ally who you can communicate with a minor action of their choice, which they perform immediately.",
                }
            },
            new()
            {
                Name = "Cold Reading",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you succeed at a task during social conflict, you generate 1 bonus Momentum which must be used for the Obtain Information Momentum spend to gain knowledge about one of the people you’re interacting with. If the social conflict with that person involves an extended task, you may ignore any Resistance the extended task has.",
                }
            },
            new()
            {
                Name = "Command & Control",
                DepartmentRequirements = new DepartmentRequirements { Command = 4, Engineering = 2, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "You’re well-versed in the ways technology can keep you in contact with your officers and allow you to aid them from afar. During combat, when you create a trait for an ally that represents a plan, strategy, or some valuable information, you may spend 1 Momentum to duplicate that trait and give a copy to a different ally. You must be able to communicate with both allies receiving these traits. If you use this talent while aboard ship, you may be assisted by the ship’s Communications + Command.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Coordinated Efforts",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you Assist another character during an extended task, the character you Assist increases their Impact by 1.",
                }
            },
            new()
            {
                Name = "Decisive Leadership",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "In a conflict, once per round, you or your allies may Keep the Initiative for free.",
                }
            },
            new()
            {
                Name = "Defuse the Tension",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you attempt a task to persuade someone not to resort to violence, the first d20 you purchase for that task is free.",
                }
            },
            new()
            {
                Name = "Fleet Commander",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 3,
                Description = new List<string>
                {
                    "You are skilled at commanding multiple ships at once. Commanding a vessel during a fleet action allows you to re-roll 1d20 on any task to grant a bonus to your vessel or group. In addition, your flagship may use your Command rating instead of its own.",
                },
                Source = BookSource.CommandDivision1stEdition
            },
            new()
            {
                Name = "Follow my Lead",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you succeed at a task during combat or another perilous situation, you may spend Determination. If you do, choose a single ally who can hear you. The next task that ally attempts counts as having assistance from you, using your Presence + Command. On this task, do not roll your assistance die: it counts as having already rolled a 1.",
                }
            },
            new()
            {
                Name = "Multi-Discipline",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                MayNotTakeWithRole = RoleName.CommandingOfficer,
                Weight = 3,
                Description = new List<string>
                {
                    "You may select one additional Role Benefit, which may not be Commanding Officer.",
                },
                ExtraRole = true
            },
            new()
            {
                Name = "Plan of Action",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever an ally succeeds at a task that was made possible, or had a reduced Difficulty, because of a trait you created, and that trait represented a plan, strategy, or course of action, they generate 2 bonus Momentum. Bonus Momentum cannot be saved.",
                }
            },
            new()
            {
                Name = "Precautions",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Once per scene, when an ally suffers an Injury or the ship suffers a Breach, prevent that Injury or Breach; describe what precaution you took to prevent the issue.",
                }
            },
            new()
            {
                Name = "Project Manager",
                DepartmentRequirements = new DepartmentRequirements { Command = 3, Engineering = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "You are used to overseeing engineering teams in technical projects. When you begin a technical project (typically a challenge or extended task), you may nominate a number of other characters up to your Command rating to be part of your team. While they are working on that project, they ignore the normal Momentum or Threat cost for assisting, and increase their Impact by 1 when working on an extended task.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Supervisor",
                Weight = 1,
                Description = new List<string>
                {
                    "The ship’s Crew Support increases by 1. This increase is cumulative if multiple main characters select it.",
                }
            },
            new()
            {
                Name = "Teacher",
                DepartmentRequirements = new DepartmentRequirements { Command = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you create a trait for an ally that represents your guidance or advice, that ally may re-roll one d20 on a single task they attempt which benefits from that trait.",
                }
            },
            new()
            {
                Name = "Time Management",
                DepartmentRequirements = new DepartmentRequirements { Command = 4 },
                Weight = 3,
                Description = new List<string>
                {
                    "During any Challenge, Extended Task or other activity under time pressure, the character may attempt a Control + Command Task with a Difficulty 3. If this Task succeeds, reduce the total number of intervals the Players have taken by 1; for every 2 Momentum spent (Repeatable) reduce by a further 1. The character has managed to minimize lost time. If the Task fails, add one additional interval as the character’s efforts actually waste time.",
                },
                Source = BookSource.CommandDivision1stEdition
            },
        };
    }

    private static List<Talent> GetConnTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Attack Run",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you take the Attack Pattern major action, enemy Attacks against you do not reduce in Difficulty due to that action.",
                }
            },
            new()
            {
                Name = "Covering Advance",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you succeed at a task to maneuver your ship, you may spend 2 Momentum to provide cover for allied ships. When an enemy vessel next makes an Attack, before the beginning of your next turn, if you are the closest ship to that attacker but they do not target you, the difficulty of their Attack is equal to your ship’s Scale.",
                }
            },
            new()
            {
                Name = "Efficient Evasion",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you attempt an Evasive Action major action for the second or subsequent time in a row during a scene, you add 1 Momentum to the group pool.",
                }
            },
            new()
            {
                Name = "Fix 'em and Fly 'em",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3, Engineering = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "You may reroll one d20 on any Engineering task to perform repairs or any ship or small craft you have piloted. You may reroll one d20 on any Conn task to pilot any ship or small craft you have repaired.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Flight Controller",
                AnyRoleRequirement = new List<string> { RoleName.FlightController },
                Weight = 3,
                Description = new List<string>
                {
                    "When you take the Assist action while at the helm of the ship, you or the ally you assist may re-roll 1d20.",
                },
                Source = BookSource.CommandDivision1stEdition
            },
            new()
            {
                Name = "Fly-By",
                DepartmentRequirements = new DepartmentRequirements { Conn = 2 },
                Weight = 2,
                Description = new List<string>
                {
                    "Whenever you use the Swift Action Momentum spend, you do not increase the Difficulty of the second task if one of the tasks you attempt is to pilot a vessel.",
                }
            },
            new()
            {
                Name = "Glancing Impact",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you succeed at the Evasive Action major action, increase the Resistance of the ship you are piloting by 2; this bonus lasts until the start of your next turn.",
                }
            },
            new()
            {
                Name = "Hands-on Pilot",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3, Engineering = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "When you perform the Warp, Evasive Action, or Attack Pattern major actions, the ship may count its focus range as double the relevant department rating (i.e., if the ship has a Conn of 3, it will score a critical success on any roll of 6 or less). However, when anyone else pilots the ship, increase the complication range by 1.",
                }
            },
            new()
            {
                Name = "Hot Rod Shuttle",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4, Engineering = 4, Operator = Operator.And },
                Weight = 8,
                Description = new List<string>
                {
                    "You have customized one of the ship’s small craft as a personal project. You have a number of points equal to your Conn score, which you may spend to improve the small craft: each point spent adds 1 to one of its systems or departments. Additionally, select one starship talent of your choice for use on the small craft.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Inertia",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you use the Impulse minor action, you may spend 1 Momentum to move one additional zone so long as you used the Impulse minor action or Warp major action in your previous turn.",
                }
            },
            new()
            {
                Name = "Multi-Tasking",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you attempt the Override major action while at a bridge station that includes one or both helm or navigator positions, you may use your Conn department instead of the department usually required for that task.",
                }
            },
            new()
            {
                Name = "Pathfinder",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you attempt a task to plot a course through unknown territory, reduce the Difficulty of the task by 1, 2, or 3, to a minimum of 1. For each point by which you reduce the Difficulty, increase the complication range of that task.",
                }
            },
            new()
            {
                Name = "Precise Evasion",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you use the Evasive Action major action, the ship does not suffer the increased Difficulty for Attacks normally caused by Evasive Action.",
                }
            },
            new()
            {
                Name = "Precision Maneuvering",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you attempt a task that requires precise or careful maneuvering, or where there is a risk of colliding with another object, you may re-roll 1d20.",
                }
            },
            new()
            {
                Name = "Push the Limits",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you attempt a Conn task that has increased in Difficulty due to environmental conditions or damage to the engines, you may add 1 Threat to ignore the difficulty increase.",
                }
            },
            new()
            {
                Name = "Spacewalk",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever the Difficulty of a task would be increased due to low- or zero-gravity, ignore that Difficulty increase. If a task that was normally possible would be made impossible because of low- or zero-gravity, you may attempt the task at +1 Difficulty instead.",
                }
            },
            new()
            {
                Name = "Starship Expert",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you take a Conn task to identify a type of starship, or to try to understand an unknown form of starship, you gain 1 bonus Momentum, which may only be used on the Obtain Information Momentum spend, or to pay part of the cost of the Create Trait Momentum spend (where the trait must represent some form of known or observed weakness in the ship being studied).",
                }
            },
            new()
            {
                Name = "Strafing Run",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you take the Attack Pattern task and then Keep the Initiative, the cost to Keep the Initiative is reduced to 0. If the character taking the next turn makes an Attack, they may re-roll one d20.",
                }
            },
            new()
            {
                Name = "Thread the Needle",
                DepartmentRequirements = new DepartmentRequirements { Conn = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you perform the Impulse minor action or Warp major action when piloting a starship, enemy Attacks from ships with a greater Scale than yours increase in difficulty by +1. If attacked by a ship with a Scale that is double or more the Scale of your ship, then you increase the Difficulty by 2 instead.",
                }
            },
            new()
            {
                Name = "Visit Every Star",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3, Science = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "You gain an additional focus, and one of your focuses (either the one gained from this talent, or an existing one) must relate to Astronavigation, Stellar Cartography, or a similar field of space science. Further, when you succeed at a navigation-related task, you gain 1 bonus Momentum due to your knowledge and familiarity. Bonus Momentum cannot be saved.",
                },
                GainRandomFocus = new List<string> { Focus.Astronavigation, Focus.StellarCartography }
            },
            new()
            {
                Name = "Zero-G Combat",
                DepartmentRequirements = new DepartmentRequirements { Conn = 3, Security = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "In combat, when you make an Attack while in a zero-gravity or micro-gravity environment, you may use the higher of your Conn or Security departments for the task, and you ignore any difficulty increases caused by the lack of gravity. In addition, enemies who lack similar training increase the Difficulty of Attacks against you by 1.",
                }
            },
        };
    }

    private static List<Talent> GetEngineeringTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Custom Tools",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "You’ve supplemented your normal toolkits with custom devices of your own design. You gain the Custom Tools equipment trait, which is added to your standard issue equipment. This stacks with the effects of your standard engineer’s toolkit, and adds 1 to your Impact on extended tasks related to technology. You cannot transfer this trait to other characters—they don’t know how to use your tools—and if this trait is lost, you may regain it for free at the start of any scene where you’re near a replicator.",
                },
                TraitGained = "Custom Tools",
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Demolitionist",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4, Security = 3, Operator = Operator.And },
                Weight = 7,
                Description = new List<string>
                {
                    "When you attempt an Engineering task to create, set, or defuse an explosive device, you may reroll one d20, and you can ignore the first complication on an Engineering task involving explosives in each scene. In addition, whenever you make an attack with a weapon with the Grenade weapon quality, it gains the Accurate quality.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Experimental Device",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                MainCharacterOnly = true,
                Weight = 3,
                Description = new List<string>
                {
                    "You have designed and constructed a new piece of equipment that is either a brand-new invention or is heavily modified from its original to the point of being barely recognizable. In either case, the device performs a function that you determine when you select this talent, which you must agree with the gamemaster. You gain an equipment trait to represent the item and the uses which you can turn it to; if it is a modified version of an existing piece of technology, it counts as that device, but the equipment trait’s Potency is increased by 1. If the device has an Escalation cost normally, increase that cost by 1. Whenever you attempt a task using the device, the complication range is increased by 2. This talent may be selected multiple times, creating a different experimental device for each selection.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "Exploit Engineering Flaw",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3, Conn = 3, Operator = Operator.And },
                Weight = 3,
                Description = new List<string>
                {
                    "When an ally succeeds at the task roll for a Scan for Weakness major action, you may add 1 Threat to highlight an identified engineering flaw in the opponent’s ship, as long as you’re able to communicate with both the ally taking the Scan for Weakness action and the ally making the attack. You immediately create a trait which represents an engineering flaw in the target ship.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "I Know my Ship",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you attempt a task to determine the source of a technical problem with your ship, the first bonus d20 you purchase is free.",
                }
            },
            new()
            {
                Name = "I'm Giving it all She's Got!",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Once per scene, when the ship has no Reserve Power remaining at the start of your turn, you may add 2 Threat to gain Reserve Power.",
                }
            },
            new()
            {
                Name = "In the Nick of Time",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3, Science = 3, Operator = Operator.Or },
                Weight = 6,
                Description = new List<string>
                {
                    "Whenever you succeed at an Engineering or Science task as part of an extended task, you increase your Impact by 1.",
                }
            },
            new()
            {
                Name = "Jury-Rig",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you attempt an Engineering task to perform repairs, you may reduce the Difficulty by 2, to a minimum of 0. If you do this, however, then the repairs are only temporary and will last only a single scene before they fail again; you may increase this duration by one scene by spending 1 Momentum (Repeatable). Jury-rigged repairs can only be applied once, and the Difficulty to repair a device that has been Jury-rigged increases by 1.",
                }
            },
            new()
            {
                Name = "Maintenance Specialist",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "You may ignore the first complication rolled on any Engineering task. Further, when you create any equipment trait, any character who uses that piece of equipment in a task may ignore the first complication rolled.",
                }
            },
            new()
            {
                Name = "Meticulous",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3 },
                AttributeRequirements = new CharacterAttributes { Control = 10 },
                Weight = 3,
                Description = new List<string>
                {
                    "During a timed challenge or extended task, before rolling, you may take one die and treat it as if it had already rolled a 1, but if you do, the task will take one additional interval.",
                }
            },
            new()
            {
                Name = "Miracle Worker",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 5 },
                Weight = 5,
                Description = new List<string>
                {
                    "Whenever you succeed at an Engineering task to overcome an extended task, you may increase your Impact by 1 by spending 1 Momentum instead of 2.",
                }
            },
            new()
            {
                Name = "More Power!",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you use the Reroute Power major action, you may spend 2 Momentum to give Reserve Power to two systems, rather than one.",
                }
            },
            new()
            {
                Name = "Past the Redline",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                AttributeRequirements = new CharacterAttributes { Daring = 11 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you use advanced technology, including attempting a task assisted by the ship, you may choose to increase the complication range by 1, 2, or 3. If you succeed, then you gain bonus Momentum equal to the amount by which the complication range was increased. Bonus Momentum cannot be saved.",
                }
            },
            new()
            {
                Name = "Percussive Maintenance",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you attempt a Control + Engineering task, you may add 1 Threat to use your Daring instead of your Control. If you do this, and the task succeeds, then you may reduce the time taken by 1 interval without spending Momentum.",
                }
            },
            new()
            {
                Name = "Procedural Compliance",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3, Conn = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "When you attempt an Engineering task, you may remove one d20 from your dice pool before rolling. If you do so, you gain one automatic success on your task.",
                }
            },
            new()
            {
                Name = "Repair Team Leader",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3, Command = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "You are trained to direct and lead damage repair teams during emergencies, giving them your guidance and expert knowledge of the ship’s systems. If you succeed at the Damage Control major action you may spend 2 Momentum (Repeatable) to repair one additional Breach.",
                }
            },
            new()
            {
                Name = "Right Tool for the Job",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you acquire an engineering tool with an Opportunity Cost, that equipment trait of that tool gains +1 Potency (typically this will result in Potency 2). If the tool is used in an extended task, whoever is using that tool increases their Impact by 1.",
                }
            },
            new()
            {
                Name = "Rocks into Replicators",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4, Science = 2, Operator = Operator.And },
                Weight = 3,
                Description = new List<string>
                {
                    "Starfleet engineers are famed for being able to build or create nearly anything needed from the most basic of available components. Once per mission, you may take one or more pieces of equipment you possess and destroy them to jury-rig another device, which must have an equal or lower Opportunity Cost than the total cost of all the items destroyed (Standard Issue items are counted as having an Opportunity Cost of 1 for this purpose). Any task roll using this newly created piece of technology increase their complication range by 2, and any complication suffered will render the device useless. The gamemaster has the final say on what can be created using this talent.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "Saboteur",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you make an Attack against a structure, machine, or stationary vehicle while in personal combat (i.e., you aren’t using a ship’s weapons to make the Attack), you may use your Engineering instead of your Security to resolve the Attack.",
                }
            },
            new()
            {
                Name = "Transporter Chief",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "You’re well-versed in the operation of transporter systems and can often get them to function in extreme circumstances or to achieve outcomes that few could manage. Such efforts are never without risk, given the delicacy of the technology. When you attempt a task to use, repair, or modify a transporter, you may add 2 Threat to reduce the Difficulty of the task by 2, to a minimum of 0.",
                }
            },
            new()
            {
                Name = "Wrote the Book",
                DepartmentRequirements = new DepartmentRequirements { Engineering = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "You know starships so well that you might as well have written the technical manuals yourself. In fact, you probably did write some of them. When you spend Determination on an Engineering task, if the task succeeds, double any Momentum you generate.",
                },
                Source = BookSource.TechnicalManual
            },
        };
    }

    private static List<Talent> GetSecurityTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Ambush Tactics",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you succeed at an Attack against an enemy who is unaware of your presence, or who is suffering from a trait or complication which represents a weakness or vulnerability, increase the Severity of the Attack by 2.",
                }
            },
            new()
            {
                Name = "Applied Force",
                DepartmentRequirements = new DepartmentRequirements { Security = 4 },
                AttributeRequirements = new CharacterAttributes { Fitness = 9 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you make a Melee Attack, you may use Fitness instead of Daring. In addition, you add 1 to the Severity of your Unarmed Attacks.",
                }
            },
            new()
            {
                Name = "Calibrated Munitions",
                DepartmentRequirements = new DepartmentRequirements { Security = 4, Engineering = 3, Operator = Operator.And },
                Weight = 7,
                Description = new List<string>
                {
                    "You’ve spent many duty hours carefully tuning and refining the ship’s weapon systems. When you use the Calibrate Weapons minor action, the weapon’s damage on your next attack increases by 2 instead of 1. In addition, when you fire a weapon with the Calibration quality, increase its damage by 1.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Close Protection",
                DepartmentRequirements = new DepartmentRequirements { Security = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you make a successful Attack, you may spend 1 Momentum to protect a single ally within Close range. The next Attack against that ally before the start of your next turn increases in Difficulty by 1.",
                }
            },
            new()
            {
                Name = "Criminal Minds",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "By imagining you are a suspect, and thinking in the same way, you gain insight into a criminal’s thought processes or actions. Whenever you succeed at a Reason task roll to interpret evidence about a crime, you generate 1 bonus Momentum, which may only be used to Obtain Information. Bonus Momentum cannot be saved.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "Crisis Management",
                DepartmentRequirements = new DepartmentRequirements { Security = 3, Command = 3, Operator = Operator.Or },
                Weight = 3,
                Description = new List<string>
                {
                    "The Momentum cost to use the Direct major action is removed.",
                }
            },
            new()
            {
                Name = "Deadeye Marksman",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                AttributeRequirements = new CharacterAttributes { Control = 10 },
                Weight = 3,
                Description = new List<string>
                {
                    "You’ve spent time at the target range every day, working on your aim. When you take the Aim minor action, you reduce the Difficulty of your next attack by 1, in addition to the normal effects of the Aim minor action.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "Defensive Training (Melee)",
                DepartmentRequirements = new DepartmentRequirements { Security = 2 },
                Weight = 2,
                Description = new List<string>
                {
                    "Melee Attacks against you increase in Difficulty by 1.",
                },
                MayNotTakeWithTalents = { "Defensive Training (Ranged)" }
            },
            new()
            {
                Name = "Defensive Training (Ranged)",
                DepartmentRequirements = new DepartmentRequirements { Security = 2 },
                Weight = 2,
                Description = new List<string>
                {
                    "Ranged Attacks against you increase in Difficulty by 1.",
                },
                MayNotTakeWithTalents = { "Defensive Training (Melee)" }
            },
            new()
            {
                Name = "Fire at Will",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "If you make an Attack, you may use the Swift Action Momentum spend for 1 Momentum rather than 2, but the second major action you take must also be an Attack.",
                }
            },
            new()
            {
                Name = "Full Spread - Maximum Yield!",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "You’re skilled in setting up torpedo attacks. When you make an attack with torpedoes, and declare that it is a salvo, you gain 2 bonus Momentum, which may only be used to pay extra targets hit by the Area quality, or for the Devastating Attack Momentum spend when using the Spread quality.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "Get Down!",
                DepartmentRequirements = new DepartmentRequirements { Security = 2 },
                Weight = 2,
                Description = new List<string>
                {
                    "You and any allies within Close range gain +1 Protection while in Cover.",
                }
            },
            new()
            {
                Name = "Hunker Down",
                DepartmentRequirements = new DepartmentRequirements { Security = 2 },
                Weight = 3,
                Description = new List<string>
                {
                    "Making good use of your surroundings for protection is one of the hallmarks of a skilled soldier. Whenever you take cover, you may count the Potency of any location trait that represents that cover by +1.",
                },
                Source = BookSource.OperationsDivision1stEdition
            },
            new()
            {
                Name = "Interrogation",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you succeed at a task to coerce someone to reveal information in a social conflict, you may ask one question for free, as per the Obtain Information Momentum spend.",
                }
            },
            new()
            {
                Name = "Lead Investigator",
                DepartmentRequirements = new DepartmentRequirements { Security = 3, Conn = 3, Operator = Operator.Or },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you attempt a task to retrieve or analyze evidence of a crime, you may re-roll 1d20. When you spend one or more Momentum to Obtain Information to ask questions about a crime scene or evidence, you may ask one additional question.",
                }
            },
            new()
            {
                Name = "Martial Artist",
                DepartmentRequirements = new DepartmentRequirements { Security = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Your Unarmed Strike Attack may be used to inflict Deadly Injuries as well as Stun Injuries.",
                }
            },
            new()
            {
                Name = "Mean Right Hook",
                DepartmentRequirements = new DepartmentRequirements { Security = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Your Unarmed Strike Attack gains the Intense quality.",
                }
            },
            new()
            {
                Name = "Pack Tactics",
                DepartmentRequirements = new DepartmentRequirements { Security = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you Assist another character during combat, the character you assisted gains 1 bonus Momentum if they succeed.",
                }
            },
            new()
            {
                Name = "Piercing Salvo",
                DepartmentRequirements = new DepartmentRequirements { Security = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you make a Torpedo Attack, you may spend 2 Momentum (Immediate) to add the Piercing quality.",
                }
            },
            new()
            {
                Name = "Precision Targeting",
                DepartmentRequirements = new DepartmentRequirements { Security = 3, Conn = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "You can more easily pick out and target specific systems when making an Attack against an enemy vessel. When you make an Attack with starship weapons that targets a specific ship system, you may re-roll a d20.",
                }
            },
            new()
            {
                Name = "Quick to Action",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "During the first round of any combat, you and your allies may ignore the normal cost to Keep the Initiative.",
                }
            },
            new()
            {
                Name = "Steady Hands",
                DepartmentRequirements = new DepartmentRequirements { Security = 3 },
                AttributeRequirements = new CharacterAttributes { Control = 9 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you take the Aim minor action before a Ranged Attack, you add 1 to the Attack’s Severity, in addition to the other effects of aiming.",
                }
            },
            new()
            {
                Name = "Tactical Countermeasures",
                DepartmentRequirements = new DepartmentRequirements { Security = 3, Engineering = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "You have studied the weapon systems commonly used across the Galaxy, and you know the best ways to counter them. When you take the Modulate Shields major action during starship combat, you increase the ship’s Resistance by an amount equal to your Security rating.",
                    "During personal combat, if you create a trait that represents creating or modifying a force field, energy field, or dampening field, then all allies protected by that field gain +1 Protection against a single type of energy weapons (phasers, disruptors, plasma weapons, etc.)."
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Well-Maintained Arsenal",
                DepartmentRequirements = new DepartmentRequirements { Security = 3, Engineering = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "One of your duties is to maintain the weapons used by the ship’s personnel, and you take that duty very seriously. Each scene, any character using a weapon from the ship’s weapons lockers may ignore the first complication rolled when making an attack or attempting another task using that weapon. Further, when you attempt a task to create a trait that represents modifying, calibrating, or modulating a weapon, reduce the Difficulty by 1. This covers any standard issue weapons, or any obtained by paying the Opportunity Cost aboard ship, excluding those gained from other talents.",
                },
                Source = BookSource.TechnicalManual
            },
        };
    }

    private static List<Talent> GetScienceTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Applied Research",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Once per scene, when you attempt a task which relates to information you received earlier that scene from an Obtain Information question, the first bonus die you purchase is free.",
                }
            },
            new()
            {
                Name = "Baffling Briefing",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                AttributeRequirements = new CharacterAttributes { Presence = 9 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you engage in a social conflict using deception, you may use Science in place of Command so long as their technical knowledge is used to mislead their opponent.",
                }
            },
            new()
            {
                Name = "Computer Expertise",
                DepartmentRequirements = new DepartmentRequirements { Science = 2 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you attempt a task that involves the programming or study of a computer system, the first bonus d20 you purchase is free.",
                }
            },
            new()
            {
                Name = "Dedicated Focus",
                DepartmentRequirements = new DepartmentRequirements { Science = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When this talent is taken, choose one of your focuses. When attempting a task where that focus applies, you score a critical success for any die which rolls equal to or under twice the relevant department.",
                },
                ChooseFocus = true
            },
            new()
            {
                Name = "Did the Reading",
                DepartmentRequirements = new DepartmentRequirements { Science = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you attempt a task, you may spend 1 Momentum (Immediate) to use Science on that task instead of the department you would normally use. In addition, you count as having an applicable focus for that task. Each time after the first in a single scene that you use this ability, the Momentum cost increases by 1: this is cumulative.",
                }
            },
            new()
            {
                Name = "Expedition Expert",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                AttributeRequirements = new CharacterAttributes { Fitness = 9 },
                Weight = 3,
                Description = new List<string>
                {
                    "Prior to participating in an away team mission, you may make additional preparations by spending 2 Momentum (Immediate). During the expedition, any member of the away team may re-roll a single d20 on any task to navigate the terrain or circumvent a hazard or obstacle. The away team may re-roll a total number of dice in this way equal to your Science rating.",
                }
            },
            new()
            {
                Name = "Intense Scrutiny",
                DepartmentRequirements = new DepartmentRequirements { Science = 3, Engineering = 3, Operator = Operator.Or },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you succeed at a task using Reason or Control as part of an extended task, you ignore any Resistance on that extended task.",
                }
            },
            new()
            {
                Name = "Lab Rat",
                DepartmentRequirements = new DepartmentRequirements { Science = 3, Engineering = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "When attempting an extended task while using a laboratory, increase your Impact by 1.",
                }
            },
            new()
            {
                Name = "Learn from Failure",
                DepartmentRequirements = new DepartmentRequirements { Science = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you fail at a Science task, you may add 3 Threat to create a trait which represents knowledge or insights gained from the failure. The cost of this is reduced by 1 for each success you scored on the failed task.",
                }
            },
            new()
            {
                Name = "Mental Repository",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                AttributeRequirements = new CharacterAttributes { Reason = 10 },
                Weight = 3,
                Description = new List<string>
                {
                    "Using extensive mental conditioning, you have access to memories with unprecedented clarity and accuracy. You may treat Obtain Information as if it were an Immediate Momentum spend, but the answers to these questions can only come from information you would already know and remember.",
                }
            },
            new()
            {
                Name = "On the Shoulders of Giants",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "Science is a collaborative process, built upon the foundations laid by others. Whenever you attempt a Science task and you can benefit from a trait created by another character, you may reroll one d20. If the trait is a piece of specialized equipment or an applicable scientific theory, then you also generate 1 bonus Momentum if the task succeeds. Bonus Momentum cannot be saved.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Rapid Analysis",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                AttributeRequirements = new CharacterAttributes { Daring = 9 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you succeed at a Science task, the cost of the Reduce Time Momentum option is reduced to 1.",
                }
            },
            new()
            {
                Name = "Rapid Hypothesis",
                DepartmentRequirements = new DepartmentRequirements { Science = 5 },
                Weight = 5,
                Description = new List<string>
                {
                    "Once per scene, when you ask two or more questions using Obtain Information, you may immediately create a trait representing your theoretical understanding of the subject of those questions.",
                }
            },
            new()
            {
                Name = "Student of War",
                DepartmentRequirements = new DepartmentRequirements { Science = 4, Security = 3, Operator = Operator.And },
                Weight = 7,
                Description = new List<string>
                {
                    "You have conducted extensive research into numerous kinds of conflict and has devoted your academic career to the study of war. While this knowledge may be purely theoretical, such information, when placed into the hands of more capable combatants, can be truly devastating. When you Assist a character making an Attack or taking the Guard action in combat, they may re-roll one d20.",
                }
            },
            new()
            {
                Name = "Temporal Mechanic",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                FocusRequirement = Focus.TemporalMechanics,
                Weight = 2,
                Description = new List<string>
                {
                    "Long study into the facets of temporal mechanics has given you an intuitive understanding of the space-time continuum and the various phenomena that can distort it. Once per scene, when confronted with an anomaly that affects the flow of time and space, you may select one d20 in your dice pool before attempting a Task roll relating to the phenomenon. When you make that task roll, if the die rolls an odd number, you generate one bonus Momentum if you succeed (bonus Momentum may not be saved). If you roll an even number on that die, you add 1 Threat instead.",
                },
                Source = BookSource.ScienceDivision1stEdition
            },
            new()
            {
                Name = "Testing a Theory",
                DepartmentRequirements = new DepartmentRequirements { Science = 2 },
                Weight = 2,
                Description = new List<string>
                {
                    "When you attempt a task using Engineering or Science, the first bonus d20 you purchase is free, so long as you succeeded at a previous task covering the same scientific or technological field earlier in the same adventure. If you created a trait that represents a hypothesis about an unknown phenomenon, you may also re-roll one d20 on tasks related to that hypothesis.",
                }
            },
            new()
            {
                Name = "The Power of Math",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "You can perform complex math equations quickly in your head, and even your rough estimates are startlingly precise. Whenever you attempt a task which requires precise calculations, you do not suffer any Difficulty increase for lacking tools, and the first d20 you purchase is free.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Theory into Practice",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                Weight = 6,
                Description = new List<string>
                {
                    "When you succeed at a task using Engineering or Science where you gain the additional d20 from the Testing a Theory talent, or which benefits from a trait that represents a hypothesis you’ve made, you generate 2 bonus Momentum. Bonus Momentum may not be saved.",
                },
                TalentRequirement = "Testing a Theory"
            },
            new()
            {
                Name = "Unconventional Thinking",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                AttributeRequirements = new CharacterAttributes { Insight = 9 },
                Weight = 2,
                Description = new List<string>
                {
                    "During any Challenge or Extended Task to adapt technology or study an unfamiliar phenomenon, you may propose an “Outside the Box” hypothesis—some strange, seemingly bizarre suggestion—and add 2 Threat to create a trait related to that hypothesis. Each time this trait is used to benefit you or your allies, add 1 Momentum to the group pool.",
                },
                Source = BookSource.ScienceDivision1stEdition
            },
            new()
            {
                Name = "Walking Encyclopedia",
                DepartmentRequirements = new DepartmentRequirements { Science = 3 },
                AttributeRequirements = new CharacterAttributes { Reason = 9 },
                Weight = 2,
                Description = new List<string>
                {
                    "Once per session, when you attempt a task, you may spend 2 Momentum (Immediate) to gain an additional focus for the remainder of the session, due to your breadth of knowledge. However, any task using that focus increases its complication range by 1, as you are not a true expert on that subject.",
                }
            },
        };
    }

    private static List<Talent> GetMedicineTalents()
    {
        return new List<Talent>
        {
            new()
            {
                Name = "Bedside Manner",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Command = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "When you succeed at a Medicine task to heal an Injury, you may immediately remove a trait from the patient, even if that trait was unrelated to the Injury being treated. In addition, when you attempt a Reputation Check, add one additional positive influence.",
                }
            },
            new()
            {
                Name = "Chief of Staff",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Command = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "When you Assist another character attempting a Medicine task, each assisting character may re-roll their assistance die.",
                }
            },
            new()
            {
                Name = "Combat Medic",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Security = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "When attempting a Medicine task during combat, you may pick one trait which increases the Difficulty of the task and ignore it.",
                }
            },
            new()
            {
                Name = "Combat Stimulants",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "You carry, and can formulate, a potent cocktail of stimulants, adrenaline, and pain inhibitors which can increase the recipient’s aggression, physical ability, and resistance to pain for a short time. You can administer a dose of stimulants to yourself or another character in Reach as a minor action. When administered, the recipient immediately recovers Stress equal to twice your Medicine score, and gains the Combat Stimulants trait for the rest of the current scene. While they have this trait, they gain +1 Protection, and may reroll one d20 on any task using Daring. However, at the end of the scene, the character suffers enough Stress to become Fatigued.",
                },
                Source = BookSource.TechnicalManual
            },
            new()
            {
                Name = "Cutting Edge Medicine",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "Whenever you attempt a Medicine task with a Difficulty of 3 or higher, you may spend up to 3 Momentum (Immediate) to reduce the Difficulty by the number of Momentum spent, to a minimum Difficulty of 1. However, as these latest advances are often experimental, the complication range of the task increases by 1 for each Momentum spent.",
                }
            },
            new()
            {
                Name = "Cyberneticist",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Engineering = 3, Operator = Operator.And },
                Weight = 6,
                Description = new List<string>
                {
                    "When you attempt a task to work on, install, or remove a cybernetic device from a patient, the first bonus d20 you purchase is free.",
                }
            },
            new()
            {
                Name = "Diagnostic Expertise",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you succeed at a Medicine task to identify and diagnose the nature of a medical problem, you may ask one question—as per Obtain Information—for every additional d20 you bought by spending Momentum.",
                }
            },
            new()
            {
                Name = "Doctor's Orders",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you attempt a task to coordinate others, or to coerce someone into taking or refraining from a specific course of action, you may use your Medicine department instead of Command.",
                }
            },
            new()
            {
                Name = "Don't you Die on Me!",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 5 },
                Weight = 5,
                Description = new List<string>
                {
                    "When a character is killed, you may spend Determination to make one attempt to revive them. If they were killed instantly by an Attack, then this may only be attempted within that scene. If the character suffered an Injury and died because they didn’t receive medical treatment in time, this may be attempted before the end of the subsequent scene. This requires a Daring + Medicine task, with a Difficulty of 3. If successful, the character is brought back from the brink of death, though they will remain Defeated for the remainder of the adventure. Failure means that your efforts were unsuccessful and the character dies.",
                }
            },
            new()
            {
                Name = "Fellowship Speciality",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When you succeed at a Medicine task where that focus applies, the cost of the Create Trait Momentum spend is reduced to 1.",
                },
                ChooseFocus = true
            },
            new()
            {
                Name = "Field Medicine",
                Weight = 1,
                Description = new List<string>
                {
                    "When attempting a Medicine task, you may ignore any increase in Difficulty or complication range for working without the proper tools or equipment.",
                }
            },
            new()
            {
                Name = "First Response",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you attempt the First Aid task during combat, the first die you purchase is free. Further, you may always Succeed at Cost, with each complication you suffer adding 1 to the Difficulty of healing the patient’s Injury subsequently.",
                }
            },
            new()
            {
                Name = "Healing Hands",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                AttributeRequirements = new CharacterAttributes { Control = 9 },
                Weight = 3,
                Description = new List<string>
                {
                    "Whenever you attempt a task to remove any injury complications, you may re-roll 1d20.",
                },
                Source = BookSource.ScienceDivision1stEdition
            },
            new()
            {
                Name = "Heart, Body and Mind",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Command = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "Whenever you succeed at a Medicine task, and you spend Momentum to recover an ally’s Stress, it costs you only 1 Momentum per Stress recovered. If you have any other talents which let you recover an ally’s Stress, any affected ally recovers one more Stress than they would otherwise.",
                },
                Source = BookSource.ScienceDivision1stEdition
            },
            new()
            {
                Name = "I'm a Doctor, not A...",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 5,
                Description = new List<string>
                {
                    "When you select this talent, choose one of your departments, with which you have a score of 1. When you attempt a task using the selected department, and you spend a point of Determination on that task, you may use your Medicine score instead of that department. The normal limits of spending Determination apply.",
                },
                Source = BookSource.ScienceDivision1stEdition
            },
            new()
            {
                Name = "Insightful Guidance",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Command = 2, Operator = Operator.And },
                Weight = 5,
                Description = new List<string>
                {
                    "Whenever you Assist a character in a social conflict, using your knowledge of psychology or emotional states, that character is considered to have a beneficial trait (Psychological Profile) in addition to the normal benefits provided by your Assist.",
                }
            },
            new()
            {
                Name = "Positive Reinforcement",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                AttributeRequirements = new CharacterAttributes { Presence = 9 },
                AnyRoleRequirement = new List<string> { RoleName.ShipsCounselor },
                Weight = 6,
                Description = new List<string>
                {
                    "Once per mission, you may attempt a Presence + Medicine task with a Difficulty of 3, while providing emotional or mental treatment for another character. Success creates a character trait for your patient that lasts until the end of the mission: Boosted Confidence. In addition to the normal effects of the trait, that character can reroll their dice pool, as if they’d spent Determination, once before the end of the mission. If the task the character used their reroll on fails, they lose the trait created by this talent.",
                }
            },
            new()
            {
                Name = "Practice Makes Perfect",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                AttributeRequirements = new CharacterAttributes { Reason = 8 },
                Weight = 3,
                Description = new List<string>
                {
                    "After you have succeeded in a Medicine task, the Difficulty of any other Medicine tasks attempted that scene to treat or heal the same kind of Injury, poison, disease, or other ailment is reduced by 1.",
                }
            },
            new()
            {
                Name = "Psychoanalyst",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you use Medicine during a social conflict, you may increase the complication range of your task by 1, 2, or 3. For each step of complication range increased, you may ask a single question as if you’d spent Momentum on Obtain Information. Any Complications generated from this task results in the individual you are interacting with becoming offended or upset with being “analyzed.”",
                },
                RequiresPsychologyFocus = true
            },
            new()
            {
                Name = "Quick Study",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3, Science = 3, Operator = Operator.Or },
                Weight = 3,
                Description = new List<string>
                {
                    "When attempting a task that will involve an unfamiliar practice, technique, or medical procedure, or which is to treat an unfamiliar species, ignore any Difficulty or complication range increase stemming from your unfamiliarity.",
                }
            },
            new()
            {
                Name = "Stimulant Shot",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you perform the First Aid task to revive a Defeated ally, you may add 1 Threat to let that ally recover Stress equal to your Medicine rating. A character may only benefit from this talent once per adventure.",
                }
            },
            new()
            {
                Name = "Surgery Savant",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 4 },
                Weight = 4,
                Description = new List<string>
                {
                    "When attempting a Medicine task during an extended task relating to surgery, your Impact is increased by 1.",
                }
            },
            new()
            {
                Name = "Triage",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "When you attempt a task to identify specific Injuries or illnesses, or to determine the severity of a patient’s condition, you may spend 1 Momentum (Repeatable) to diagnose one additional patient.",
                }
            },
            new()
            {
                Name = "Transformative Treatments",
                DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
                Weight = 3,
                Description = new List<string>
                {
                    "You are especially talented when it comes to disguising a person as a member of another species, whether using targeted epigenetic treatments, plastic surgery, or other methods. When you succeed at a Medicine task to disguise a character as a member of a different species (creating a trait), you may spend 1 Momentum to increase the potency of that trait by 1.",
                },
                Source = BookSource.TechnicalManual
            },
        };
    }
}
