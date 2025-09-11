using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class StarshipTalent
{
    public string Name { get; set; }

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
}
