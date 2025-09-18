using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using System.Xml.Linq;

namespace StarTrekAdventures.Selectors;

public static class SpeciesAbilitySelector
{
    public static SpeciesAbility GetSpeciesAbility(string name)
    {
        return SpeciesAbilities.FirstOrDefault(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public static List<SpeciesAbility> GetAllSpeciesAbilities()
    {
        return SpeciesAbilities;
    }

    internal static NpcSpecialRule GetSpeciesAbilityAsSpecialRule(string abilityName)
    {
        var ability = SpeciesAbilities.FirstOrDefault(x => x.Name.Equals(abilityName, StringComparison.CurrentCultureIgnoreCase));

        return new NpcSpecialRule
        {
            Name = ability.Name + " (Species Ability)",
            Description = new List<string>
            {
                ability.NpcDescription
            },
        };
    }

    private static readonly List<SpeciesAbility> SpeciesAbilities = new()
    {
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.FaithOfTheHeart,
            Description = "When you use one of your values to spend or gain Determination, you may also add 1 Momentum to the group pool.",
            NpcDescription = "When this character uses one of it's values, add 1 Threat if they are an adversary or add 1 to the group’s Momentum pool if they are an ally."
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.MentalDiscipline,
            Description = "While Vulcans have some psychic capabilities, they require training to use it effectively (see the Mind Meld talent). Further, your maximum Stress is based on your Control rather than your Fitness, and you may suffer 2 Stress to avoid suffering any trait that represents an emotional state. However, if you become Fatigued, you increase the Potency of any such emotion-related trait by 1.",
            NpcDescription = "This character's Personal Threat is equal to their Control (if major) or half their control (otherwise), and they may suffer 2 Stress to avoid suffering any trait which represents an emotional state. If they become Fatigued, they increase the potency of any such emotion-related trait by 1.",
            StressBasedOn = AttributeName.Control
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.Sturdy,
            Description = "You gain +1 Protection against Stun Attacks only. Further, when you suffer a complication that represents a physical hindrance or being stunned, dazed, or disoriented, you may take 1 Stress to ignore that complication (and remove any associated trait).",
            NpcDescription = "This character gains +1 Protection against Stun Attacks only. Further, when they suffer a complication that represents a physical hindrance or being stunned, dazed, or disoriented, they may take 1 Stress to ignore that complication (and remove any associated trait)."
        },
    };
}
