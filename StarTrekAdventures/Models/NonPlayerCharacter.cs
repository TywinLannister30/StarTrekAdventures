using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using System.Text.Json.Serialization;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class NonPlayerCharacter
{
    public NonPlayerCharacter() 
    { 
        Source = BookSource.Core;
    }

    public NonPlayerCharacter(NonPlayerCharacter npc)
    {
        Name = npc.Name;
        TypeEnum = npc.TypeEnum;
        Description = npc.Description;

        Traits = new List<string>();

        foreach (var trait in npc.Traits)
        {
            Traits.Add(trait);
        }

        Values = npc.Values;
        Focuses = npc.Focuses;

        PersonalThreat = npc.PersonalThreat;
        Protection = npc.Protection;
        
        Attributes = new CharacterAttributes
        {
            Control = npc.Attributes.Control,
            Daring = npc.Attributes.Daring,
            Fitness = npc.Attributes.Fitness,
            Insight = npc.Attributes.Insight,
            Presence = npc.Attributes.Presence,
            Reason = npc.Attributes.Reason,
        };

        Departments = new Departments
        {
            Command = npc.Departments.Command,
            Conn = npc.Departments.Conn,
            Engineering = npc.Departments.Engineering,
            Security = npc.Departments.Security,
            Science = npc.Departments.Science,
            Medicine = npc.Departments.Medicine,
        };

        Attacks = new List<Weapon>();
        foreach (var attack in npc.Attacks)
        {
            Attacks.Add(new Weapon(attack));
        }

        EscalationAttacks = npc.EscalationAttacks;

        SpecialRules = new List<NpcSpecialRule>();
        foreach (var specialrule in npc.SpecialRules)
        {
            SpecialRules.Add(new NpcSpecialRule(specialrule));
        }

        Source = npc.Source;
    }

    public string Name { get; set; }

    public string Type { get { return TypeEnum.ToString() + " NPC"; } } 

    [JsonIgnore]
    public NPCType TypeEnum { get; set; }

    public string Description { get; set; }

    public List<string> Traits { get; set; }

    public List<string> Values { get; set; }

    public List<string> Focuses { get; set; }

    public int PersonalThreat { get; set; }

    public int Protection { get; set; }

    public CharacterAttributes Attributes { get; set; }

    public Departments Departments { get; set; }

    public ICollection<Weapon> Attacks { get; set; }

    [JsonIgnore]
    public List<(string, int)> EscalationAttacks { get; set; }

    public ICollection<NpcSpecialRule> SpecialRules { get; set; }

    [JsonIgnore]
    public bool RandomSpecies { get; set; }

    public string Source { get; set; }

    internal void AddOneToTwoDifferentDepartments()
    {
        var displinesAvailable = new List<string>
        {
            DepartmentName.Command,
            DepartmentName.Conn,
            DepartmentName.Engineering,
            DepartmentName.Medicine,
            DepartmentName.Science,
            DepartmentName.Security
        };

        var choices = displinesAvailable.OrderBy(n => Util.GetRandom()).Take(2);

        foreach (var choice in choices)
        {
            if (choice == DepartmentName.Command) Departments.Command++;
            if (choice == DepartmentName.Conn) Departments.Conn++;
            if (choice == DepartmentName.Engineering) Departments.Engineering++;
            if (choice == DepartmentName.Medicine) Departments.Medicine++;
            if (choice == DepartmentName.Science) Departments.Science++;
            if (choice == DepartmentName.Security) Departments.Security++;
        }
    }

    internal void AdjustAttributesForSpecies(Species species)
    {
        Attributes.Control += species.AttributeModifiers.Control;
        Attributes.Daring += species.AttributeModifiers.Daring;
        Attributes.Fitness += species.AttributeModifiers.Fitness;
        Attributes.Insight += species.AttributeModifiers.Insight;
        Attributes.Presence += species.AttributeModifiers.Presence;
        Attributes.Reason += species.AttributeModifiers.Reason;

        if (species.ThreeRandomAttributes)
        {
            var attributes = typeof(CharacterAttributes).GetProperties();

            var picks = attributes.OrderBy(n => Util.GetRandom()).Take(3).ToList();

            if (picks.Any(x => x.Name == AttributeName.Control)) Attributes.Control++;
            if (picks.Any(x => x.Name == AttributeName.Daring)) Attributes.Daring++;
            if (picks.Any(x => x.Name == AttributeName.Fitness)) Attributes.Fitness++;
            if (picks.Any(x => x.Name == AttributeName.Insight)) Attributes.Insight++;
            if (picks.Any(x => x.Name == AttributeName.Presence)) Attributes.Presence++;
            if (picks.Any(x => x.Name == AttributeName.Reason)) Attributes.Reason++;
        }

        if (species.OneOfTheseModifiers != null)
        {
            var attributes = new List<string>();

            if (species.OneOfTheseModifiers.Control > 0) attributes.Add(AttributeName.Control);
            if (species.OneOfTheseModifiers.Daring > 0) attributes.Add(AttributeName.Daring);
            if (species.OneOfTheseModifiers.Fitness > 0) attributes.Add(AttributeName.Fitness);
            if (species.OneOfTheseModifiers.Insight > 0) attributes.Add(AttributeName.Insight);
            if (species.OneOfTheseModifiers.Presence > 0) attributes.Add(AttributeName.Presence);
            if (species.OneOfTheseModifiers.Reason > 0) attributes.Add(AttributeName.Reason);

            var pick = attributes.OrderBy(n => Util.GetRandom()).First();

            if (pick == AttributeName.Control) Attributes.Control++;
            if (pick == AttributeName.Daring) Attributes.Daring++;
            if (pick == AttributeName.Fitness) Attributes.Fitness++;
            if (pick == AttributeName.Insight) Attributes.Insight++;
            if (pick == AttributeName.Presence) Attributes.Presence++;
            if (pick == AttributeName.Reason) Attributes.Reason++;
        }
    }
}
