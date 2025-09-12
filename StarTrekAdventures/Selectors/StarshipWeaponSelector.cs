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
            Name = "Area or Spread",
            Description = new List<string>
            {
                "Choose Are or Spread when you fire this weapon",
                "Area => This weapon impacts a wider area and can affect several targets at once. When you succeed at an attack, additional targets in the same zone may be hit by spending 1 Momentum for each additional target (Repeatable). This attack may Succeed at Cost.",
                "Spread => Attacks with this weapon reduce the cost of the Devastating Attack Momentum spend to 1. This is Repeatable.",
            }

        },
        new WeaponQuality
        {
            Name = "Calibration",
            Description = new List<string>
            {
                "This weapon needs to be calibrated before firing. The weapon cannot be fired unless a Prepare minor action is performed before the Attack major action in the same turn."
            }
        },
        new WeaponQuality
        {
            Name = "Cumbersome",
            Description = new List<string>
            {
                "This weapon is difficult to bring to bear against a target, increasing the Difficulty of an attack made using it by 1. If this weapon is a torpedo, it cannot be fired as part of a salvo."
            }
        },
        new WeaponQuality
        {
            Name = "Dampening",
            Description = new List<string>
            {
                "This attack drains the target’s reserve power, causing widespread disruption. If the target has Reserve Power available, it loses Reserve Power."
            }
        },
        new WeaponQuality
        {
            Name = "High Yield",
            Description = new List<string>
            {
                "This weapon inflicts massive damage to enemy vessels. If the attack inflicts one or more breaches to a system, it inflicts one additional breach (or steps up the Potency of a breach inflicted by 1—attacker’s choice)."
            }
        },
        new WeaponQuality
        {
            Name = "Intense",
            Description = new List<string>
            {
                "When making an attack with this weapon, you may increase the damage by 1 by spending 1 Momentum, rather than 2. This is Repeatable."
            }
        },
        new WeaponQuality
        {
            Name = "Persistent",
            Description = new List<string>
            {
                "When this weapon hits, you may spend 1–3 Momentum. At the end of each round, the target suffers half the weapon’s damage rating (round up) again. This effect lasts for a number of rounds equal to the Momentum spent."
            }
        },
        new WeaponQuality
        {
            Name = "Piercing",
            Description = new List<string>
            {
                "The weapon is effective at cutting through layers of protection. When this weapon makes an attack, any Resistance the target has is ignored."
            }
        },
        new WeaponQuality
        {
            Name = "Spread",
            Description = new List<string>
            {
                "Attacks with this weapon reduce the cost of the Devastating Attack Momentum spend to 1. This is Repeatable."
            }
        },
        new WeaponQuality
        {
            Name = "Versatile 1",
            Description = new List<string>
            {
                "If an attack with this weapon is successful, it gains 1 point of bonus Momentum. Bonus Momentum cannot be saved."
            }
        },
        new WeaponQuality
        {
            Name = "Versatile 2",
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
            Name = StarshipWeaponName.DisruptorBanks,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Medium,
            Damage = 1,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Intense")
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
                GetWeaponQuality("Intense")
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
                GetWeaponQuality("Intense")
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.ElectromagneticCannon,
            Type = StarshipWeaponType.Energy,
            Range = StarshipWeaponRange.Close,
            Damage = 2,
            DamageBasedOnScale = true,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("Dampening"),
                GetWeaponQuality("Piercing"),
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
                GetWeaponQuality("Versatile 1")
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
                GetWeaponQuality("Area or Spread"),
                GetWeaponQuality("Versatile 2")
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
                GetWeaponQuality("Versatile 2")
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
                GetWeaponQuality("Spread"),
                GetWeaponQuality("Versatile 2")
            }
        },

        // TORPEDOES
        new StarshipWeapon
        {
            Name = StarshipWeaponName.PhotonTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Long,
            Damage = 3,
            Qualities = new List<WeaponQuality>
            {
                GetWeaponQuality("High Yield")
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
                GetWeaponQuality("Calibration"),
                GetWeaponQuality("Cumbersome"),
                GetWeaponQuality("Persistent")
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
                GetWeaponQuality("Calibration"),
                GetWeaponQuality("High Yield"),
                GetWeaponQuality("Intense")
            }
        },
        new StarshipWeapon
        {
            Name = StarshipWeaponName.SpatialTorpedoes,
            Type = StarshipWeaponType.Torpedo,
            Range = StarshipWeaponRange.Medium,
            Damage = 2
        },
    };
}
