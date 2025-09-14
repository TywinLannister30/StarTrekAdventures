using StarTrekAdventures.Constants;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class SmallCraft
{
    public SmallCraft()
    {
        Traits = new List<string>();
        Talents = new List<StarshipTalent>();
        SpecialRules = new List<StarshipSpecialRule>();

        Systems = new StarshipSystems();
        Departments = new Departments();

        Source = BookSource.Core;
    }

    public SmallCraft(SmallCraft smallCraft)
    {
        Name = smallCraft.Name;
        Description = smallCraft.Description;
        CrewCompliment = smallCraft.CrewCompliment;

        Traits = new List<string>();
        foreach (var trait in  smallCraft.Traits)
        {
            Traits.Add(trait);
        };

        Scale = smallCraft.Scale;
        Resistance = smallCraft.Resistance;
        Shields = smallCraft.Shields;

        Systems = new StarshipSystems
        {
            Comms = smallCraft.Systems.Comms,
            Weapons = smallCraft.Systems.Weapons,
            Sensors = smallCraft.Systems.Sensors,
            Structure = smallCraft.Systems.Structure,
            Engines = smallCraft.Systems.Engines,
            Computers = smallCraft.Systems.Computers,
        };

        Departments = new Departments
        {
            Command = smallCraft.Departments.Command,
            Conn = smallCraft.Departments.Conn,
            Engineering = smallCraft.Departments.Engineering,
            Security = smallCraft.Departments.Security,
            Science = smallCraft.Departments.Science,
            Medicine = smallCraft.Departments.Medicine,
        };

        Weapons = new List<StarshipWeapon>();
        foreach (var weapon in smallCraft.Weapons)
        {
            Weapons.Add(new StarshipWeapon(weapon));
        };

        Talents = new List<StarshipTalent>();
        foreach (var talent in smallCraft.Talents)
        {
            Talents.Add(talent);
        }

        SpecialRules = new List<StarshipSpecialRule>();
        foreach (var specialRule in smallCraft.SpecialRules)
        {
            SpecialRules.Add(specialRule);
        }

        Source = smallCraft.Source;
    }

    public string Name { get; set; }

    public List<string> Description { get; set; }

    public ICollection<string> Traits { get; set; }

    public string CrewCompliment { get; set; }

    public int Scale { get; set; }

    public int Resistance { get; set; }

    public int Shields { get; set; }

    public StarshipSystems Systems { get; set; }

    public Departments Departments { get; set; }

    public ICollection<StarshipWeapon> Weapons { get; set; }

    public ICollection<StarshipTalent> Talents { get; set; }

    public ICollection<StarshipSpecialRule> SpecialRules { get; set; }

    public string Source { get; set; }

    internal void SetResistance()
    {
        Resistance = Talents.Sum(x => x.ResistanceModifier);
    }

    internal void SetShields()
    {
        if (SpecialRules != null && SpecialRules.Any(x => x.StructureOnlyForShields))
            Shields = Systems.Structure;
        else
            Shields = Scale + Systems.Structure + Departments.Security;

        Shields += Talents.Sum(x => x.ShieldsModifier);
    }

    internal bool HasMines()
    {
        return Weapons.Any(x => x.Type == StarshipWeaponType.Mine);
    }
}
