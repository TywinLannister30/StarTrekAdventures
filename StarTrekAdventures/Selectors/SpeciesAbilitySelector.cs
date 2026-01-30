using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class SpeciesAbilitySelector : ISpeciesAbilitySelector
{
    public SpeciesAbility GetSpeciesAbility(string name)
    {
        return SpeciesAbilities.FirstOrDefault(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<SpeciesAbility> GetAllSpeciesAbilities()
    {
        return SpeciesAbilities;
    }

    public NpcSpecialRule GetSpeciesAbilityAsSpecialRule(string abilityName)
    {
        var ability = SpeciesAbilities.FirstOrDefault(x => x.Name.Equals(abilityName, StringComparison.CurrentCultureIgnoreCase));

        return new NpcSpecialRule
        {
            Name = ability.Name + " (Species Ability)",
            Description = new List<string>
            {
                ability.NpcDescription
            },
            Source = ability.Source
        };
    }

    private static readonly List<SpeciesAbility> SpeciesAbilities = new()
    {
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.BrakLul,
            Description = "You gain 1 Protection which stacks with the benefits of any armor worn. Further, when another character attempts First Aid to heal you, they may re-roll a d20.",
            NpcDescription = "This character gains 1 Protection which stacks with the benefits of any armor worn. Further, when another character attempts First Aid to heal them, they may re-roll a d20.",
            ProtectionBonus = 1
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.BorgImplants,
            Description = "You are a Cyborg, and may select Cybernetic talents. Further, you have the Borg Implants listed. Medicine tasks performed on you increase their Difficulty by 3, as does the complication range of any tasks related to social interaction. You may remove an implant when you receive a milestone, in addition to any other changes you make to your character.",
            NpcDescription = "This character is a Cyborg, and may select Cybernetic talents. Further, they possess the Borg Implants listed. Medicine tasks performed on them increase their Difficulty by 3, as does the complication range of any tasks related to social interaction.",
            Source = BookSource.PicardSeasonOneCrewPack1stEdition
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.FaithOfTheHeart,
            Description = "When you use one of your values to spend or gain Determination, you may also add 1 Momentum to the group pool.",
            NpcDescription = "When this character uses one of it's values, add 1 Threat if they are an adversary or add 1 to the group’s Momentum pool if they are an ally."
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.HealthySuspicions,
            Description = "You may add 1 Threat when interacting with an NPC to ask the gamemaster if that NPC is lying about something. The gamemaster must answer either Yes or No, and this answer must be accurate, but the gamemaster does not have to specify what the NPC is lying about.",
            NpcDescription = "This character may buy their first d20 for free when attempting to determine if someone is lying."
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
            Name = SpeciesAbilityName.Paranoia,
            Description = "When an action scene begins, if the gamemaster wishes an adversary to take the first turn, they must spend 1 Threat more than normal.",
            NpcDescription = "When an action scene begins, if the gamemaster wishes an adversary to take the first turn, they must spend 1 Threat more than normal.",
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.Sturdy,
            Description = "You gain +1 Protection against Stun Attacks only. Further, when you suffer a complication that represents a physical hindrance or being stunned, dazed, or disoriented, you may take 1 Stress to ignore that complication (and remove any associated trait).",
            NpcDescription = "This character gains +1 Protection against Stun Attacks only. Further, when they suffer a complication that represents a physical hindrance or being stunned, dazed, or disoriented, they may take 1 Stress to ignore that complication (and remove any associated trait)."
        },
        new SpeciesAbility
        {
            Name = SpeciesAbilityName.SyntheticLifeForm,
            Description = "You gain +1 Protection against Stun Attacks only. Further, when you suffer a complication that represents a physical hindrance or being stunned, dazed, or disoriented, you may take 1 Stress to ignore that complication (and remove any associated trait).",
            NpcDescription = "This character is not an organic being, and is not as vulnerable to physical harm: it has +1 Protection against Stun attacks. It recovers from injuries with Engineering tasks, rather than Medicine. In addition, it adds 1 automatic success to any task roll which uses it's Reason, due to it's powerful positronic brain.",
            Source = BookSource.SpeciesSourcebook
        },
    };
}
