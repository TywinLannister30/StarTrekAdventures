using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using System.Text.Json.Serialization;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class NpcStarship
{
    public NpcStarship()
    {
        Traits = new List<string>();
        Attacks = new List<StarshipWeapon>();
        EscalationAttacks = new List<StarshipWeapon>();
        Talents = new List<StarshipTalent>();
        SpecialRules = new List<StarshipSpecialRule>();

        Systems = new StarshipSystems();
        Departments = new Departments();

        Source = BookSource.Core;
    }

    public NpcStarship(NpcStarship npcStarship)
    {
        Name = npcStarship.Name;
        Description = npcStarship.Description;
        CrewQualityEnum = npcStarship.CrewQualityEnum;
        MissionProfile = npcStarship.MissionProfile;
        
        Traits = new List<string>();
        foreach (var trait in  npcStarship.Traits)
        {
            Traits.Add(trait);
        };

        Scale = npcStarship.Scale;
        Resistance = npcStarship.Resistance;
        Shields = npcStarship.Shields;
        CrewSupport = npcStarship.CrewSupport;
        SmallCraftReadiness = npcStarship.SmallCraftReadiness;

        Systems = new StarshipSystems
        {
            Comms = npcStarship.Systems.Comms,
            Weapons = npcStarship.Systems.Weapons,
            Sensors = npcStarship.Systems.Sensors,
            Structure = npcStarship.Systems.Structure,
            Engines = npcStarship.Systems.Engines,
            Computers = npcStarship.Systems.Computers,
        };

        Departments = new Departments
        {
            Command = npcStarship.Departments.Command,
            Conn = npcStarship.Departments.Conn,
            Engineering = npcStarship.Departments.Engineering,
            Security = npcStarship.Departments.Security,
            Science = npcStarship.Departments.Science,
            Medicine = npcStarship.Departments.Medicine,
        };

        Attacks = new List<StarshipWeapon>();
        foreach (var weapon in npcStarship.Attacks)
        {
            Attacks.Add(new StarshipWeapon(weapon));
        };

        EscalationAttacks = new List<StarshipWeapon>();
        foreach (var weapon in npcStarship.EscalationAttacks)
        {
            EscalationAttacks.Add(new StarshipWeapon(weapon));
        }
        ;

        TractorBeamStrength = npcStarship.TractorBeamStrength;
        GrapplerCableStrength = npcStarship.GrapplerCableStrength;

        Talents = new List<StarshipTalent>();
        foreach (var talent in npcStarship.Talents)
        {
            Talents.Add(talent);
        }

        SpecialRules = new List<StarshipSpecialRule>();
        foreach (var specialRule in npcStarship.SpecialRules)
        {
            SpecialRules.Add(specialRule);
        }

        NoCrewSupport = npcStarship.NoCrewSupport;

        Source = npcStarship.Source;
    }

    public string Name { get; set; }

    public List<string> Description { get; set; }

    [JsonIgnore]
    public CrewQuality CrewQualityEnum { get; set; }

    public string CrewQuality 
    { 
        get
        {
            if (CrewQualityEnum == Enums.CrewQuality.None)
                return "None";

            var attribute = (int)CrewQualityEnum + 8;
            var department = (int)CrewQualityEnum + 1;

            return $"{CrewQualityEnum} (Attribute {attribute}, Department {department})";
        }
    }

    public string MissionProfile { get; set; }

    public ICollection<string> Traits { get; set; }

    public int Scale { get; set; }

    public int Resistance { get; set; }

    public int Shields { get; set; }

    public int CrewSupport { get; set; }

    public int SmallCraftReadiness { get; set; }

    public StarshipSystems Systems { get; set; }

    public Departments Departments { get; set; }

    public ICollection<StarshipWeapon> Attacks { get; set; }

    public ICollection<StarshipWeapon> EscalationAttacks { get; set; }

    [JsonIgnore]
    public int GrapplerCableStrength { get; set; }

    [JsonIgnore]
    public int TractorBeamStrength { get; set; }

    public ICollection<StarshipTalent> Talents { get; set; }

    public ICollection<StarshipSpecialRule> SpecialRules { get; set; }

    public string Source { get; set; }

    [JsonIgnore]
    public bool NoCrewSupport { get; set; }

    internal void SetResistance()
    {
        Resistance = ((Scale + 1) / 2) + Systems.Structure.ToBonus() + Talents.Sum(x => x.ResistanceModifier);
    }

    internal void SetShields()
    {
        if (SpecialRules != null && SpecialRules.Any(x => x.StructureOnlyForShields))
            Shields = Systems.Structure;
        else
            Shields = Scale + Systems.Structure + Departments.Security;

        Shields += Talents.Sum(x => x.ShieldsModifier);
    }

    internal void SetCrewSupport()
    {
        if (NoCrewSupport)
        {
            CrewSupport = 0;
            return;
        }

        CrewSupport = Scale + SpecialRules.Sum(x => x.CrewSupportModifier);

        if (Talents.Any(x => x.HalfCrewSupport))
            CrewSupport = ((CrewSupport + 1) / 2);

        if (SpecialRules.Any(x => x.DoubleCrewSupport))
            CrewSupport *= 2;
    }

    internal void SetSmallCraftReadiness()
    {
        if (SpecialRules.Any(x => x.NoSmallCraftCapacity))
        {
            SmallCraftReadiness = 0;
            return;
        }

        SmallCraftReadiness = Scale - 1;

        if (Talents.Any(x => x.DoubleSmallCraftReadiness))
            SmallCraftReadiness *= 2;

        SmallCraftReadiness += Talents.Sum(x => x.SmallCraftReadinessModifier);
        SmallCraftReadiness += SpecialRules.Sum(x => x.SmallCraftReadinessModifier);
    }

    internal bool HasMines()
    {
        return Attacks.Any(x => x.Type == StarshipWeaponType.Mine);
    }

    internal bool HasTractorBeam()
    {
        return Attacks.Any(x => x.Name == StarshipWeaponName.TractorBeam);
    }
}
