using StarTrekAdventures.Constants;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class NpcSpecialRule
{
    public NpcSpecialRule() 
    { 
        Source = BookSource.Core;
    }

    public NpcSpecialRule(NpcSpecialRule specialrule)
    {
        Name = specialrule.Name;

        Description = new List<string>();
        foreach (var description in specialrule.Description)
        {
            Description.Add(description);
        }

        HideIfGenerating = specialrule.HideIfGenerating;
        AddOneToTwoDifferentDepartments = specialrule.AddOneToTwoDifferentDepartments;
        UnarmedStrikesCanBeDeadly = specialrule.UnarmedStrikesCanBeDeadly;

        AddQualitiesToUnarmedStrikes = new List<string>();
        if (specialrule.AddQualitiesToUnarmedStrikes != null)
        {
            foreach (var quality in specialrule.AddQualitiesToUnarmedStrikes)
            {
                AddQualitiesToUnarmedStrikes.Add(quality);
            }
        }

        AddRandomFocus = new List<string>();
        if (specialrule.AddRandomFocus != null)
        {
            foreach (var focus in specialrule.AddRandomFocus)
            {
                AddRandomFocus.Add(focus);
            }
        }

        Source = specialrule.Source;
    }

    public string Name { get; set; }

    public List<string> Description { get; set; }

    [JsonIgnore]
    public bool HideIfGenerating { get; set; }

    [JsonIgnore]
    public bool AddOneToTwoDifferentDepartments { get; set; }

    [JsonIgnore]
    public bool UnarmedStrikesCanBeDeadly { get; set; }

    [JsonIgnore]
    public List<string> AddQualitiesToUnarmedStrikes { get; set; }

    [JsonIgnore]
    public List<string> AddRandomFocus { get; set; }

    [JsonIgnore]
    public int ProtectionModifier { get; set; }

    public string Source { get; set; }
}
