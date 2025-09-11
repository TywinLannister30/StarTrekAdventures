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

    public ICollection<StarshipWeaponQuality> Qualities { get; set; }
   
    [JsonIgnore]
    public bool IsTractorBeam { get; set; }

    public void SetEffect(Starship starship)
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

            // Append quality names if any
            if (Qualities != null && Qualities.Any())
            {
                baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
            }

            Effect = baseEffect;
        }
    }
}
