using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public static class WeaponSelector
{
    public static Weapon GetWeapon(string name)
    {
        return Weapons.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public static WeaponQuality GetWeaponQuality(string name)
    {
        return WeaponQualities.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    internal static List<Weapon> GetAllWeapons()
    {
        return Weapons;
    }

    private static readonly List<WeaponQuality> WeaponQualities = new()
    {
        new WeaponQuality
        {
            Name = "Accurate",
            Description = new List < string >
            {
                "If you perform the Aim minor action before making an attack with this weapon, you may re-roll up to two d20s in your dice pool, rather than only one."
            }
        },
        new WeaponQuality
        {
            Name = "Area",
            Description = new List < string > 
            { 
                "When you succeed at an attack, additional targets in the same zone may be hit by spending 1 Momentum for each additional target (Repeatable). This attack may Succeed at Cost." 
            }
        },
        new WeaponQuality
        {
            Name = "Charge",
            Description = new List < string > 
            { 
                "If you perform the Prepare minor action before attacking with this weapon, you may add one of the following qualities to the attack: Area, Intense, or Piercing. If you choose Area, the attack’s severity is reduced by 1.",
                "Area => When you succeed at an attack, additional targets in the same zone may be hit by spending 1 Momentum for each additional target (Repeatable). This attack may Succeed at Cost.",
                "Intense => When making an attack with this weapon, you may increase the severity by spending 1 Momentum, rather than 2 (Repeatable).",
                "Piercing => A successful attack with this weapon ignores the target's Protection rating.",
            }
        },
        new WeaponQuality
        {
            Name = "Hidden 1",
            Description = new List < string > 
            { 
                "You can use a minor action to conceal this weapon. Any search for the weapon requires an Insight or Reason + Security task with a Difficulty of 1." 
            }
        },
        new WeaponQuality
        {
            Name = "Intense",
            Description = new List < string > 
            { 
                "When making an attack with this weapon, you may increase the severity by spending 1 Momentum, rather than 2 (Repeatable)." 
            }
        },
        new WeaponQuality
        {
            Name = "Piercing",
            Description = new List < string > 
            { 
                "A successful attack with this weapon ignores the target's Protection rating." 
            }
        },
        new WeaponQuality
        {
            Name = "Vulcan Nerve Pinch",
            Description = new List < string >
            {
                "You may use Science or Medicine instead of Security when attempting a Nerve Pinch Attack."
            }
        },
    };

    private static readonly List<Weapon> Weapons = new()
    {
        new Weapon
        {
            Name = WeaponName.UnarmedStrike,
            Type = WeaponType.Melee,
            Injury = InjuryType.Stun,
            Severity = 2,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>(),
            Costs = new List<string>()
        },

        new Weapon
        {
            Name = WeaponName.BatLeth,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 3,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>(),
            Costs = new List<string> { "Opportunity 1" }
        },
        new Weapon
        {
            Name = WeaponName.Dagger,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 2,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Hidden 1")
            },
            Costs = new List<string> { "Opportunity 1" }
        },
        new Weapon
        {
            Name = WeaponName.DisruptorPistol,
            Type = WeaponType.Ranged,
            Injury = InjuryType.Deadly,
            Severity = 4,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Intense"),
            },
            Costs = new List<string> { "Not Available" }
        },
        new Weapon
        {
            Name = WeaponName.DisruptorRifle,
            Type = WeaponType.Ranged,
            Injury = InjuryType.Deadly,
            Severity = 5,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Accurate"),
                GetWeaponQuality("Intense"),
            },
            Costs = new List<string> { "Not Available" }
        },
        new Weapon
        {
            Name = WeaponName.DkTahgDagger,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 2,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Hidden 1")
            },
            Costs = new List<string> { "Opportunity 1" }
        },
        new Weapon
        {
            Name = WeaponName.PhaserType1,
            Type = WeaponType.Ranged,
            Injury = InjuryType.StunOrDeadly,
            Severity = 3,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Hidden 1"),
                GetWeaponQuality("Charge"),
            },
            Costs = new List<string> { "Standard Issue" }
        },
        new Weapon
        {
            Name = WeaponName.PhaserType2,
            Type = WeaponType.Ranged,
            Injury = InjuryType.StunOrDeadly,
            Severity = 4,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Charge")
            },
            Costs = new List<string> { "Standard Issue" }
        },
        new Weapon
        {
            Name = WeaponName.VulcanNervePinch,
            Type = WeaponType.Melee,
            Injury = InjuryType.Stun,
            Severity = 3,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Intense"),
                GetWeaponQuality("Vulcan Nerve Pinch")
            },
            Costs = new List<string>()
        },
    };
}
