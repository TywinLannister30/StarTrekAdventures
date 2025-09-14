using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using System.Text.Json.Serialization;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class StarshipWeapon
{
    public StarshipWeapon() 
    {
        Source = BookSource.Core;
    }

    public StarshipWeapon(StarshipWeapon weapon)
    {
        Name = weapon.Name;
        Effect = weapon.Effect;
        Type = weapon.Type;
        Range = weapon.Range;
        Damage = weapon.Damage;
        DamageBasedOnScale = weapon.DamageBasedOnScale;

        Qualities = new List<WeaponQuality>();
        foreach (var quality in weapon.Qualities)
        {
            Qualities.Add(quality);
        }

        IsTractorBeam = weapon.IsTractorBeam;

        Source = weapon.Source;
    }

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

    public string Source { get; set; }

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
                var baseEffect = string.Empty;

                if (Type == StarshipWeaponType.Mine)
                    baseEffect = $"{Type}, Damage";
                else
                    baseEffect = $"{Type}, {Range}, Damage";

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
                var damage = 0;

                if (Type == StarshipWeaponType.Mine)
                    damage = Damage;
                else
                    damage = Damage + (DamageBasedOnScale ? starship.Scale : 0) + starship.Systems.Weapons.ToBonus();

                if (Type == StarshipWeaponType.Energy)
                    damage += starship.Talents.Sum(x => x.EnergyWeaponDamageModifier);

                var baseEffect = string.Empty;

                if (Type == StarshipWeaponType.Mine)
                    baseEffect = $"{Type}, Damage {damage}";
                else
                    baseEffect = $"{Type}, {Range}, Damage {damage}";

                if (Qualities != null && Qualities.Count != 0)
                {
                    baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
                }

                Effect = baseEffect;
            }
        }
    }

    public void SetEffect(NpcStarship starship)
    {
        if (IsTractorBeam)
        {
            Effect = $"Strength {Damage + starship.Talents.Sum(x => x.TractorBeamModifier)}";
        }
        else
        {
            var damage = 0;

            if (Type == StarshipWeaponType.Mine)
                damage = Damage;
            else
                damage = Damage + (DamageBasedOnScale ? starship.Scale : 0) + starship.Systems.Weapons.ToBonus();

            if (Type == StarshipWeaponType.Energy)
                damage += starship.Talents.Sum(x => x.EnergyWeaponDamageModifier);

            var baseEffect = string.Empty;

            if (Type == StarshipWeaponType.Mine)
                baseEffect = $"{Type}, Damage {damage}";
            else
                baseEffect = $"{Type}, {Range}, Damage {damage}";

            if (Qualities != null && Qualities.Count != 0)
            {
                baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
            }

            Effect = baseEffect;
        }
    }

    public void SetEffect(SmallCraft smallCraft)
    {
        var damage = 0;

        if (Type == StarshipWeaponType.Mine)
            damage = Damage;
        else
            damage = Damage + (DamageBasedOnScale ? smallCraft.Scale : 0) + smallCraft.Systems.Weapons.ToBonus();

        if (Type == StarshipWeaponType.Energy)
            damage += smallCraft.Talents.Sum(x => x.EnergyWeaponDamageModifier);

        var baseEffect = string.Empty;

        if (Type == StarshipWeaponType.Mine)
            baseEffect = $"{Type}, Damage {damage}";
        else
            baseEffect = $"{Type}, {Range}, Damage {damage}";

        if (Qualities != null && Qualities.Count != 0)
        {
            baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
        }

        Effect = baseEffect;
    }
}
