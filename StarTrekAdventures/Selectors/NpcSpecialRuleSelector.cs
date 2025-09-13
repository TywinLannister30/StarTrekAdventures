using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class NpcSpecialRuleSelector
{
    public static NpcSpecialRule GetSpecialRule(string name)
    {
        return NpcSpecialRules.First(x => x.Name == name);
    }

    private static readonly List<NpcSpecialRule> NpcSpecialRules = new()
    {
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
            Name = NpcSpecialRuleName.ImmuneToPain,
            Description = new List<string>
            {
                "The creature is incapable of feeling pain, continuing undeterred despite the most horrific Injury. The creature ignores all Stun Injuries, and cannot be Defeated by an attack which inflicts a Stun Injury."
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
    };
}
