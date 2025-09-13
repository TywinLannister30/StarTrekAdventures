using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public static class StarshipWeaponSelector
{
    public static StarshipWeapon GetWeapon(string name)
    {
        return StarshipWeapons.First(x => x.Name == name);
    }

    public static WeaponQuality GetWeaponQuality(string name)
    {
        return StarshipWeaponQualities.First(x => x.Name == name);
    }

    internal static List<StarshipWeapon> GetAllWeapons()
    {
        return StarshipWeapons;
    }

    private static readonly List<WeaponQuality> StarshipWeaponQualities = new()
    {
        new WeaponQuality
        {
            Name = WeaponQualityName.Area,
            Description = new List<string>
            {
                "This weapon impacts a wider area and can affect several targets at once. When you succeed at an attack, additional targets in the same zone may be hit by spending 1 Momentum for each additional target (Repeatable). This attack may Succeed at Cost."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.AreaOrSpread,
            Description = new List<string>
            {
                "Choose Are or Spread when you fire this weapon",
                "Area => This weapon impacts a wider area and can affect several targets at once. When you succeed at an attack, additional targets in the same zone may be hit by spending 1 Momentum for each additional target (Repeatable). This attack may Succeed at Cost.",
                "Spread => Attacks with this weapon reduce the cost of the Devastating Attack Momentum spend to 1. This is Repeatable.",
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Calibration,
            Description = new List<string>
            {
                "This weapon needs to be calibrated before firing. The weapon cannot be fired unless a Prepare minor action is performed before the Attack major action in the same turn."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Cumbersome,
            Description = new List<string>
            {
                "This weapon is difficult to bring to bear against a target, increasing the Difficulty of an attack made using it by 1. If this weapon is a torpedo, it cannot be fired as part of a salvo."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Dampening,
            Description = new List<string>
            {
                "This attack drains the target’s reserve power, causing widespread disruption. If the target has Reserve Power available, it loses Reserve Power."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Depleting,
            Description = new List<string>
            {
                "This attack strips away the protective layers of deflector shields. The attack cannot cause the ship to be shaken, but the Momentum cost to increase damage is reduced to 1."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Devastating,
            Description = new List<string>
            {
                "Tasks to repair breaches caused by this weapon increase in Difficulty by 1."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Hidden1,
            Description = new List<string>
            {
                "This weapon system is concealed from scans. When the weapon is hidden, it cannot be detected unless a specific scan is attempted; this scan is a task with a Difficulty of 1."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.HighYield,
            Description = new List<string>
            {
                "This weapon inflicts massive damage to enemy vessels. If the attack inflicts one or more breaches to a system, it inflicts one additional breach (or steps up the Potency of a breach inflicted by 1—attacker’s choice)."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Intense,
            Description = new List<string>
            {
                "When making an attack with this weapon, you may increase the damage by 1 by spending 1 Momentum, rather than 2. This is Repeatable."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Jamming,
            Description = new List<string>
            {
                "This weapon sends out a scattering field, disrupting the target’s sensors or communications systems. Until the end of the current round, the target increases the Difficulty for all tasks assisted by Communications and Sensors by 1."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Persistent,
            Description = new List<string>
            {
                "When this weapon hits, you may spend 1–3 Momentum. At the end of each round, the target suffers half the weapon’s damage rating (round up) again. This effect lasts for a number of rounds equal to the Momentum spent."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Piercing,
            Description = new List<string>
            {
                "The weapon is effective at cutting through layers of protection. When this weapon makes an attack, any Resistance the target has is ignored."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Slowing,
            Description = new List<string>
            {
                "Until the end of the current round, characters aboard the target vessel cannot use the Keep the Initiative Momentum spend."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Spread,
            Description = new List<string>
            {
                "Attacks with this weapon reduce the cost of the Devastating Attack Momentum spend to 1. This is Repeatable."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Versatile1,
            Description = new List<string>
            {
                "If an attack with this weapon is successful, it gains 1 point of bonus Momentum. Bonus Momentum cannot be saved."
            }
        },
        new WeaponQuality
        {
            Name = WeaponQualityName.Versatile2,
            Description = new List<string>
            {
                "If an attack with this weapon is successful, it gains 2 points of bonus Momentum. Bonus Momentum cannot be saved."
            }
        },
    };

    private static readonly List<StarshipWeapon> StarshipWeapons = new()
    {
        // ENERGY WEAPONS
        new StarshipWeapon
        {
            Name = StarshipWeaponName.AntiprotonBeamArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.AntiprotonBeamBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.AntiprotonBeamCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.AntiprotonBeamSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.DisruptorArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Intense)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.DisruptorBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Intense)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.DisruptorCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Intense)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.DisruptorSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Intense)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.ElectromagneticArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ElectromagneticBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ElectromagneticCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ElectromagneticSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.FreeElectronLaserArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.FreeElectronLaserBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>()
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.FreeElectronLaserCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>()
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.FreeElectronLaserSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.GravitonArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Devastating),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.GravitonBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Devastating),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.GravitonCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Devastating),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.GravitonSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Devastating),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.IonicArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.IonicBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.IonicCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.IonicSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Dampening),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaseArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaseBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaseCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaseSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhasedPoleronBeamArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Intense),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhasedPoleronBeamBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Intense),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhasedPoleronCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Intense),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhasedPoleronSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Intense),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaserArrays,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Versatile2)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaserBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Versatile2)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaserCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Versatile2)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhaserSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Versatile2)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.ProtonBeamArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Persistent)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ProtonBeamBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Persistent)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ProtonBeamCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Persistent)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ProtonBeamSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Persistent)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.PulseArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PulseBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PulseCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PulseSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Versatile1)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.PulsePhaserCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Spread),
                GetWeaponQuality(WeaponQualityName.Versatile2)
            }
        },

        new StarshipWeapon
        {
            Name = StarshipWeaponName.TetryonBeamArray,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 0,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.AreaOrSpread),
                GetWeaponQuality(WeaponQualityName.Depleting)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.TetryonBeamBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Depleting)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.TetryonBeamCannons,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Depleting)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.TetryonBeamSpinalLance,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Depleting)
            }
        },

        // TORPEDOES
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ChronitonTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Slowing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.GravimetricTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 5,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.HighYield),
                GetWeaponQuality(WeaponQualityName.Piercing)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.NeutronicTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 4,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Dampening)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.NuclearTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Medium,
            Damage = 3,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Intense)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhotonTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhotonicTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 2,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PlasmaTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 5,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Persistent)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PolaronTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Piercing),
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PositronTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 5,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Cumbersome),
                GetWeaponQuality(WeaponQualityName.Dampening)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.QuantumTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 4,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.HighYield),
                GetWeaponQuality(WeaponQualityName.Intense)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.SpatialTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Medium,
            Damage = 2
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.TetryonicTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 2,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Depleting),
                GetWeaponQuality(WeaponQualityName.HighYield),
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.TransphasicTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 4,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Devastating),
                GetWeaponQuality(WeaponQualityName.HighYield)
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.TricobaltTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 6,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality(WeaponQualityName.Area),
                GetWeaponQuality(WeaponQualityName.Calibration),
                GetWeaponQuality(WeaponQualityName.Cumbersome)
            }
        },
    };
}
