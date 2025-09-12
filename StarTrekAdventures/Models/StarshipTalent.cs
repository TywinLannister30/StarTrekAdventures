using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class StarshipTalent
{
    public string Name { get; set; }

    public string Requirement
    {
        get
        {
            var retVal = string.Empty;
            var requirementsCount = 0;

            if (MinimumServiceYear > 0 && MaximumServiceYear > 0)
            {
                retVal += AddValue($"{MinimumServiceYear}-{MaximumServiceYear}", requirementsCount > 0);
                requirementsCount++;
            }
            else if (MinimumServiceYear > 0)
            {
                retVal += AddValue($"{MinimumServiceYear} onwards", requirementsCount > 0);
                requirementsCount++;
            }

            if (DepartmentRequirements != null)
            {
                retVal += AddValue(DepartmentRequirements.GetString(), requirementsCount > 0);
                requirementsCount++;
            }

            if (SystemRequirements != null)
            {
                if (SystemRequirements.Comms > 0)
                {
                    retVal += AddValue($"Comms {SystemRequirements.Comms}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (SystemRequirements.Computers > 0)
                {
                    retVal += AddValue($"Computers {SystemRequirements.Computers}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (SystemRequirements.Engines > 0)
                {
                    retVal += AddValue($"Engines {SystemRequirements.Engines}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (SystemRequirements.Sensors > 0)
                {
                    retVal += AddValue($"Sensors {SystemRequirements.Sensors}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (SystemRequirements.Structure > 0)
                {
                    retVal += AddValue($"Structure {SystemRequirements.Structure}+", requirementsCount > 0);
                    requirementsCount++;
                }
                if (SystemRequirements.Weapons > 0)
                {
                    retVal += AddValue($"Weapons {SystemRequirements.Weapons}+", requirementsCount > 0);
                    requirementsCount++;
                }
            }

            if (GMPermission)
            {
                if (requirementsCount > 0)
                    retVal += ", or gamemaster’s permission";
                else
                    retVal += "Gamemaster’s permission";

            }

            return retVal;
        }
    }

    public List<string> Description { get; set; }


    [JsonIgnore]
    public StarshipSystems SystemRequirements { get; set; }

    [JsonIgnore]
    public DepartmentRequirements DepartmentRequirements { get; set; }

    [JsonIgnore]
    public int MinimumServiceYear { get; set; }

    [JsonIgnore]
    public int MaximumServiceYear { get; set; }

    [JsonIgnore]
    public int ResistanceModifier { get; set; }

    [JsonIgnore]
    public int ShieldsModifier { get; set; }

    [JsonIgnore]
    public bool DoubleSmallCraftReadiness { get; set; }

    [JsonIgnore]
    public int SmallCraftReadinessModifier { get; set; }

    [JsonIgnore]
    public string TraitGained { get; set; }

    [JsonIgnore]
    public bool HalfCrewSupport { get; set; }

    [JsonIgnore]
    public bool GMPermission { get; set; }

    [JsonIgnore]
    public bool AddRandomWeapon { get; set; }

    [JsonIgnore]
    public bool RequiresMines { get; set; }

    [JsonIgnore]
    public bool RequiresTractorBeam { get; set; }

    [JsonIgnore]
    public int TractorBeamModifier { get; set; }

    [JsonIgnore]
    public int EnergyWeaponDamageModifier { get; set; }

    [JsonIgnore]
    public int ScaleRequirement { get; set; }

    private static string AddValue(string value, bool leadWithComma)
    {
        var retVal = string.Empty;
        if (leadWithComma) retVal += ", ";
        retVal += value;
        return retVal;
    }
}
