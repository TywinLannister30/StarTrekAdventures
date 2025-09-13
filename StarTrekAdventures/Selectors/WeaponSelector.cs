using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public static class WeaponSelector
{
    public static Weapon GetWeapon(string name)
    {
        var weaponSelected = Weapons.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        return new Weapon(weaponSelected);
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
            Name = WeaponQualityName.Accurate,
            Description = new List < string >
            {
                "If you perform the Aim minor action before making an attack with this weapon, you may re-roll up to two d20s in your dice pool, rather than only one."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Area,
            Description = new List < string > 
            { 
                "When you succeed at an attack, additional targets in the same zone may be hit by spending 1 Momentum for each additional target (Repeatable). This attack may Succeed at Cost." 
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Charge,
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
            Name = WeaponQualityName.Cumbersome,
            Description = new List < string >
            {
                "You cannot attack with a cumbersome weapon unless you take the Prepare minor action on the same turn."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Debilitating,
            Description = new List < string >
            {
                "The Difficulty to treat or to heal injuries caused by this weapon is increased by 1."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Grenade,
            Description = new List < string >
            {
                "You can attack a target at up to Medium range and have enough grenades for three separate attacks."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Hidden1,
            Description = new List < string > 
            { 
                "You can use a minor action to conceal this weapon. Any search for the weapon requires an Insight or Reason + Security task with a Difficulty of 1." 
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Innacurate,
            Description = new List < string >
            {
                "The weapon is imprecise and clumsy. You do not benefit from the Aim minor action when making an attack with this weapon."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Intense,
            Description = new List < string > 
            { 
                "When making an attack with this weapon, you may increase the severity by spending 1 Momentum, rather than 2 (Repeatable)." 
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Piercing,
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
            Name = WeaponName.AndorianPlasmaRifle,
            Type = WeaponType.Ranged,
            Injury = InjuryType.Deadly,
            Severity = 4,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Accurate),
                GetWeaponQuality(WeaponQualityName.Intense)
            },
            Costs = new List<string> { "Not Available" }
        },
        new Weapon
        {
            Name = WeaponName.AnestheticHypospray,
            Type = WeaponType.Melee,
            Injury = InjuryType.Stun,
            Severity = 3,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Intense)
            },
            Costs = new List<string> { "Opportunity 1" }
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
            Name = WeaponName.Blade,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 3,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>(),
            Costs = new List<string> { "Opportunity 1" }
        },
        new Weapon
        {
            Name = WeaponName.Bludgeon,
            Type = WeaponType.Melee,
            Injury = InjuryType.StunOrDeadly,
            Severity = 3,
            Size = WeaponSize.OneHanded,
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
                GetWeaponQuality(WeaponQualityName.Hidden1)
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
                GetWeaponQuality(WeaponQualityName.Intense),
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
                GetWeaponQuality(WeaponQualityName.Accurate),
                GetWeaponQuality(WeaponQualityName.Intense),
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
                GetWeaponQuality(WeaponQualityName.Hidden1)
            },
            Costs = new List<string> { "Opportunity 1" }
        },
        new Weapon
        {
            Name = WeaponName.EnergyWhip,
            Type = WeaponType.Ranged,
            Injury = InjuryType.Stun,
            Severity = 4,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Intense)
            },
            Costs = new List<string> { "Not available" }
        },
        new Weapon
        {
            Name = WeaponName.HeavyBlade,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 3,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Intense)
            },
            Costs = new List<string> { "Opportunity 1", "Escalation 1" }
        },
        new Weapon
        {
            Name = WeaponName.JemHadarPlasmaPistol,
            Type = WeaponType.Ranged,
            Injury = InjuryType.Deadly,
            Severity = 4,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Debilitating)
            },
            Costs = new List<string> { "Not Available" }
        },
        new Weapon
        {
            Name = WeaponName.JemHadarPlasmaRifle,
            Type = WeaponType.Ranged,
            Injury = InjuryType.Deadly,
            Severity = 5,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Accurate),
                GetWeaponQuality(WeaponQualityName.Debilitating)
            },
            Costs = new List<string> { "Not Available" }
        },
        new Weapon
        {
            Name = WeaponName.KarTakin,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 3,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>(),
            Costs = new List<string> { "Not Available" }
        },
        new Weapon
        {
            Name = WeaponName.Knife,
            Type = WeaponType.Melee,
            Injury = InjuryType.Deadly,
            Severity = 2,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Hidden1)
            },
            Costs = new List<string> { "Opportunity 1" }
        },
        new Weapon
        {
            Name = WeaponName.ParticleRifle,
            Type = WeaponType.Ranged,
            Injury = InjuryType.StunOrDeadly,
            Severity = 4,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Accurate)
            },
            Costs = new List<string> { "Standard Issue" }
        },
        new Weapon
        {
            Name = WeaponName.PhasePistol,
            Type = WeaponType.Ranged,
            Injury = InjuryType.StunOrDeadly,
            Severity = 3,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>(),
            Costs = new List<string> { "Standard Issue" }
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
                GetWeaponQuality(WeaponQualityName.Hidden1),
                GetWeaponQuality(WeaponQualityName.Charge),
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
                GetWeaponQuality(WeaponQualityName.Charge)
            },
            Costs = new List<string> { "Standard Issue" }
        },
        new Weapon
        {
            Name = WeaponName.PhaserType3,
            Type = WeaponType.Ranged,
            Injury = InjuryType.StunOrDeadly,
            Severity = 5,
            Size = WeaponSize.TwoHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Accurate),
                GetWeaponQuality(WeaponQualityName.Charge)
            },
            Costs = new List<string> { "Opportunity 1" , "Escalation 2" }
        },
        new Weapon
        {
            Name = WeaponName.PulseGrenade,
            Type = WeaponType.Ranged,
            Injury = InjuryType.StunOrDeadly,
            Severity = 4,
            Size = WeaponSize.OneHanded,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Area),
                GetWeaponQuality(WeaponQualityName.Grenade)
            },
            Costs = new List<string> { "Opportunity 1" , "Escalation 2" }
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
                GetWeaponQuality(WeaponQualityName.Intense),
                GetWeaponQuality("Vulcan Nerve Pinch")
            },
            Costs = new List<string>()
        },
    };
}
