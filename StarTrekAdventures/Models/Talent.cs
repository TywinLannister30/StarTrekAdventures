using StarTrekAdventures.Constants;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class Talent
{
    public Talent()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string Requirement
    {
        get
        {
            var retVal = string.Empty;
            var requirementsCount = 0;

            if (MainCharacterOnly)
            {
                retVal += AddValue("Main character only", requirementsCount > 0);
                requirementsCount++;
            }

            if (!string.IsNullOrEmpty(TraitRequirement))
            {
                retVal += AddValue(TraitRequirement, requirementsCount > 0);
                requirementsCount++;
            }

            if (AnyTraitRequirement != null)
            {
                retVal += AddValue(string.Join(" or ", AnyTraitRequirement), requirementsCount > 0);
                requirementsCount++;
            }

            if (TalentRequirement != null)
            {
                retVal += AddValue(TalentRequirement, requirementsCount > 0);
                requirementsCount++;
            }

            if (AnyRoleRequirement != null)
            {
                retVal += AddValue(string.Join(" or ", AnyRoleRequirement), requirementsCount > 0);
                retVal += " only";
                requirementsCount++;
            }

            if (!string.IsNullOrEmpty(MayNotTakeWithRole))
            {
                if (requirementsCount > 0)
                    retVal += AddValue($"not the {MayNotTakeWithRole}", true);
                else
                    retVal += AddValue($"Not the {MayNotTakeWithRole}", false);
               
                requirementsCount++;
            }

            if (GMPermission)
            {
                if (requirementsCount > 0)
                    retVal += ", or gamemaster’s permission";
                else
                    retVal += "Gamemaster’s permission";

            }

            if (DepartmentRequirements != null)
            {
                retVal += AddValue(DepartmentRequirements.GetString(), requirementsCount > 0);
                requirementsCount++;
            }

            if (AttributeRequirements != null)
            {
                if (AttributeRequirements.Control > 0)
                {
                    retVal += AddValue($"Control {AttributeRequirements.Control}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (AttributeRequirements.Daring > 0)
                {
                    retVal += AddValue($"Daring {AttributeRequirements.Daring}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (AttributeRequirements.Fitness > 0)
                {
                    retVal += AddValue($"Fitness {AttributeRequirements.Fitness}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (AttributeRequirements.Insight > 0)
                {
                    retVal += AddValue($"Insight {AttributeRequirements.Insight}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (AttributeRequirements.Presence > 0)
                {
                    retVal += AddValue($"Presence {AttributeRequirements.Presence}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (AttributeRequirements.Reason > 0)
                {
                    retVal += AddValue($"Reason {AttributeRequirements.Reason}+", requirementsCount > 0);
                    requirementsCount++;
                }
            }

            if (RequiresPsychologyFocus)
            {
                if (requirementsCount > 0)
                    retVal += ", a psychology-related focus";
                else
                    retVal += "A psychology-related focus";

            }

            return retVal;
        }
    }

    public ICollection<string> Description { get; set; }

    [JsonIgnore]
    public string TraitRequirement { get; set; }

    [JsonIgnore]
    public ICollection<string> AnyTraitRequirement { get; set; }

    [JsonIgnore]
    public string FocusRequirement { get; set; }

    [JsonIgnore]
    public string TalentRequirement { get; set; }

    [JsonIgnore]
    public string MayNotTakeWithRole{ get; set; }

    [JsonIgnore]
    public ICollection<string> AnyRoleRequirement { get; set; }

    [JsonIgnore]
    public ICollection<string> GainRandomFocus { get; set; }

    [JsonIgnore]
    public string GenderRequirement { get; set; }

    [JsonIgnore]
    public bool GMPermission { get; set; }

    [JsonIgnore]
    public string MayNotTakeWithTalent { get; set; }

    [JsonIgnore]
    public DepartmentRequirements DepartmentRequirements { get; set; }

    [JsonIgnore]
    public CharacterAttributes AttributeRequirements { get; set; }

    [JsonIgnore]
    public string TraitGained { get; set; }

    [JsonIgnore]
    public int StressModifier { get; set; }

    [JsonIgnore]
    public int ProtectionModifier { get; set; }

    [JsonIgnore]
    public bool MixedHeritageAllowed { get; set; } = true;

    [JsonIgnore]
    public bool Symbiote { get; set; }

    [JsonIgnore]
    public bool MayBeSelected { get; set; } = true;

    [JsonIgnore]
    public int AdditionalValues { get; set; }

    [JsonIgnore]
    public bool BorgImplants { get; set; }

    [JsonIgnore]
    public string AddDepartmentToStress { get; set; }

    [JsonIgnore]
    public bool ExtraRole { get; set; }

    [JsonIgnore]
    public bool ChooseFocus { get; set; }

    [JsonIgnore]
    public bool MainCharacterOnly { get; set; }

    [JsonIgnore]
    public bool RequiresPsychologyFocus { get; set; }

    [JsonIgnore]
    public int Weight { get; set; }

    public string Source { get; set; }

    private static string AddValue(string value, bool leadWithComma)
    {
        var retVal = string.Empty;
        if (leadWithComma) retVal += ", ";
        retVal += value;
        return retVal;
    }
}
