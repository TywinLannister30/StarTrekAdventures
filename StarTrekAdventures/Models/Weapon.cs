using System.Text.Json.Serialization;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class Weapon
{
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

    public void SetEffect(ICollection<(string, int)> escalationAttacks)
    {
        var baseEffect = string.Empty;

        var match = escalationAttacks.FirstOrDefault(e => e.Item1 == Name);

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
