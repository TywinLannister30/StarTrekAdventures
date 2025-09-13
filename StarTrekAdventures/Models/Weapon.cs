using StarTrekAdventures.Constants;
using StarTrekAdventures.Selectors;
using System.Text.Json.Serialization;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class Weapon
{
    public Weapon() 
    { 
        Costs = new List<string>();
    }

    public Weapon(Weapon weapon)
    {
        Name = weapon.Name;
        Effect = weapon.Effect;
        Type = weapon.Type;
        Injury = weapon.Injury;
        Size = weapon.Size;
        Severity = weapon.Severity;

        Qualities = new List<WeaponQuality>();
        foreach (var weaponQuality in weapon.Qualities)
            Qualities.Add(weaponQuality);

        Costs = new List<string>();
        foreach (var cost in weapon.Costs)
            Costs.Add(cost);
    }

    public string Name { get; set; }

    public string Effect { get; set; }

    [JsonIgnore]
    public WeaponType Type { get; set; }

    [JsonIgnore]
    public InjuryType Injury { get; set; }

    [JsonIgnore]
    public WeaponSize Size { get; set; }

    [JsonIgnore]
    public int Severity { get; set; }

    public ICollection<WeaponQuality> Qualities { get; set; }

    [JsonIgnore]
    public ICollection<string> Costs { get; set; }

    public void SetEffect(NonPlayerCharacter npc)
    {
        if (Name == WeaponName.UnarmedStrike)
        {
            if (npc.SpecialRules.Any(x => x.UnarmedStrikesCanBeDeadly))
                Injury = InjuryType.StunOrDeadly;

            var specialRule = npc.SpecialRules.FirstOrDefault(x => x.AddQualitiesToUnarmedStrikes != null);

            if (specialRule != null)
            {
                foreach (var quality in specialRule.AddQualitiesToUnarmedStrikes)
                {
                    Qualities.Add(WeaponSelector.GetWeaponQuality(quality));
                }
            }
        }

        var baseEffect = string.Empty;

        var match = npc.EscalationAttacks.FirstOrDefault(e => e.Item1 == Name);

        if (!string.IsNullOrEmpty(match.Item1))
        {
            baseEffect = $"Escalation {match.Item2}, ";
        }

        baseEffect += Type.ToString();

        if (Injury == InjuryType.StunOrDeadly)
            baseEffect += ", Stun/Deadly";
        else
            baseEffect += $", {Injury}";

        baseEffect += $" {Severity}";

        baseEffect += ", Size";

        if (Size == WeaponSize.OneHanded)
            baseEffect += " 1H";
        else
            baseEffect += " 2H";

        if (Qualities != null && Qualities.Count != 0)
        {
            baseEffect += ", " + string.Join(", ", Qualities.Select(q => q.Name));
        }

        Effect = baseEffect;
    }
}
