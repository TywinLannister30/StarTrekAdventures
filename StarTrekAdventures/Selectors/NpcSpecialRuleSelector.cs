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
            Name = NpcSpecialRuleName.IntensiveTraining,
            Description = new List<string>
            {
                "Members of this group are given considerable training in a wide range of fields. They have a minimum of 1 in all departments: when creating an NPC with this ability, increase any department with a rating of 0 to 1."
            }
        },
    };
}
