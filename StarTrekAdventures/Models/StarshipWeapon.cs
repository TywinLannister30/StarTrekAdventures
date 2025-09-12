using StarTrekAdventures.Helpers;
using System.Text.Json.Serialization;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class StarshipWeapon
{
    public string Name { get; set; }

    public string Effect { get; set; }

    [JsonIgnore]
    public StarshipWeaponType Type { get; set; }

    [JsonIgnore]
    public StarshipWeaponRange Range { get; set; }

    [JsonIgnore]
    public int Damage { get; set; }

    [JsonIgnore]
    public bool DamageBasedOnScale { get; set; }

    public ICollection<WeaponQuality> Qualities { get; set; }
   
    [JsonIgnore]
    public bool IsTractorBeam { get; set; }

    public void SetEffect(Starship starship = null)
    {
        if (starship == null)
        {
            if (IsTractorBeam)
            {
                Effect = $"Strength {Damage}";
            }
            else
            {
                string baseEffect = $"{Type}, {Range}, Damage";

                if (DamageBasedOnScale)
                {
                    baseEffect += " equal to ship's scale";
                    if (Damage > 0) baseEffect += $" +{Damage}";
                }
                else
                {
                    baseEffect += $" {Damage}";
                }

                if (Qualities != null && Qualities.Count != 0)
                {
                    baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
                }

                Effect = baseEffect;
            }
        }
        else
        {
            if (IsTractorBeam)
            {
                Effect = $"Strength {Damage + starship.Talents.Sum(x => x.TractorBeamModifier)}";
            }
            else
            {
                var damage = Damage + (DamageBasedOnScale ? starship.Scale : 0) + starship.Systems.Weapons.ToBonus();

                if (Type == StarshipWeaponType.Energy)
                    damage += starship.Talents.Sum(x => x.EnergyWeaponDamageModifier);

                string baseEffect = $"{Type}, {Range}, Damage {damage}";

                if (Qualities != null && Qualities.Count != 0)
                {
                    baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
                }

                Effect = baseEffect;
            }
        }
    }
}
