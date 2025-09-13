using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class Starship
{
    public Starship()
    {
        Traits = new List<string>();
        Weapons = new List<StarshipWeapon>();
        Talents = new List<StarshipTalent>();
        SpecialRules = new List<StarshipSpecialRule>();
        SuggestedMissionProfiles = new List<string>();

        Systems = new StarshipSystems();
        Departments = new Departments();
    }

    public string Name { get; set; }

    public string Registration { get; set; }

    public string SpaceFrame { get; set; }

    public string MissionProfile { get; set; }

    public int SpaceFrameLaunchYear { get; set; }

    public int ServiceYear { get; set; }

    public int NumRefits { get; set; }

    public int Scale { get; set; }

    public int Resistance { get; set; }

    public int Shields { get; set; }

    public int CrewSupport { get; set; }

    public int SmallCraftReadiness { get; set; }

    public ICollection<string> Traits { get; set; }

    public StarshipSystems Systems { get; set; }

    public Departments Departments { get; set; }

    public ICollection<StarshipWeapon> Weapons { get; set; }

    public ICollection<StarshipTalent> Talents { get; set; }

    public ICollection<StarshipSpecialRule> SpecialRules { get; set; }

    public string CurrentMissionPod { get; set; }

    [JsonIgnore]
    public ICollection<string> SuggestedMissionProfiles { get; set; }

    public bool IsValid
    {
        get
        {
            return true;
        }
    }

    public string ValidationIssue { get; set; }

    internal void SetSpaceframe(Spaceframe spaceFrame)
    {
        SpaceFrame = spaceFrame.Name;
        Scale = spaceFrame.Scale;

        foreach (var trait in spaceFrame.Traits)
            Traits.Add(trait);

        Systems.Structure = spaceFrame.Systems.Structure;
        Systems.Comms = spaceFrame.Systems.Comms;
        Systems.Sensors = spaceFrame.Systems.Sensors;
        Systems.Weapons = spaceFrame.Systems.Weapons;
        Systems.Engines = spaceFrame.Systems.Engines;
        Systems.Computers = spaceFrame.Systems.Computers;

        Departments.Science = spaceFrame.Departments.Science;
        Departments.Medicine = spaceFrame.Departments.Medicine;
        Departments.Command = spaceFrame.Departments.Command;
        Departments.Conn = spaceFrame.Departments.Conn;
        Departments.Engineering = spaceFrame.Departments.Engineering;
        Departments.Security = spaceFrame.Departments.Security;
        
        foreach (var missionProfile in spaceFrame.SuggestedMissionProfiles)
            SuggestedMissionProfiles.Add(missionProfile);

        SpaceFrameLaunchYear = spaceFrame.LaunchYear;
    }

    internal void AddTalent(StarshipTalent starshipTalent)
    {
        Talents.Add(starshipTalent);
    }

    internal void AddSpecialRule(StarshipSpecialRule starshipSpecialRule)
    {
        SpecialRules.Add(starshipSpecialRule);
    }

    internal void SetMissionProfileSystems(MissionProfile chosenMissionProfile)
    {
        if (chosenMissionProfile.AnyOneSystem)
        {
            var choices = new List<string>
            {
                SystemName.Comms,
                SystemName.Computers,
                SystemName.Engines,
                SystemName.Sensors,
                SystemName.Structure,
                SystemName.Weapons
            };

            var choice = choices.OrderBy(n => Util.GetRandom()).First();

            if (choice == SystemName.Comms) Systems.Comms++;
            if (choice == SystemName.Computers) Systems.Computers++;
            if (choice == SystemName.Engines) Systems.Engines++;
            if (choice == SystemName.Sensors) Systems.Sensors++;
            if (choice == SystemName.Structure) Systems.Structure++;
            if (choice == SystemName.Weapons) Systems.Weapons++;
        }
        else
        {
            Systems.Comms += chosenMissionProfile.Systems.Comms;
            Systems.Computers += chosenMissionProfile.Systems.Computers;
            Systems.Engines += chosenMissionProfile.Systems.Engines;
            Systems.Sensors += chosenMissionProfile.Systems.Sensors;
            Systems.Structure += chosenMissionProfile.Systems.Structure;
            Systems.Weapons += chosenMissionProfile.Systems.Weapons;
        }
        
    }

    internal void AddTrait(string name)
    {
        Traits.Add(name);
    }

    internal void SetMissionProfileDepartments(MissionProfile chosenMissionProfile)
    {
        Departments.Command += chosenMissionProfile.Departments.Command;
        Departments.Conn += chosenMissionProfile.Departments.Conn;
        Departments.Engineering += chosenMissionProfile.Departments.Engineering;
        Departments.Security += chosenMissionProfile.Departments.Security;
        Departments.Medicine += chosenMissionProfile.Departments.Medicine;
        Departments.Science += chosenMissionProfile.Departments.Science;
    }

    internal void PerformRefits()
    {
        var numRefits = Util.GetRandom(5);

        var yearsSinceLaunch = numRefits * 10 + Util.GetRandom(10);

        ServiceYear = SpaceFrameLaunchYear + yearsSinceLaunch;

        NumRefits = numRefits + SpecialRules.Sum(x => x.ExtraRefits);

        const int maxTimesChosen = 2;
        var maxValues = 12;

        if (SpecialRules.Any(x => x.MajorRefit)) maxValues++;

        var structureChosen = 0;
        var commsChosen = 0;
        var sensorsChosen = 0;
        var weaponsChosen = 0;
        var enginesChosen = 0;
        var computersChosen = 0;

        for (int i = 0; i < NumRefits; i++)
        {
            var choices = new List<string>();

            if (Systems.Structure < maxValues && structureChosen < maxTimesChosen) choices.Add(SystemName.Structure);
            if (Systems.Comms < maxValues && commsChosen < maxTimesChosen) choices.Add(SystemName.Comms);
            if (Systems.Sensors < maxValues && sensorsChosen < maxTimesChosen) choices.Add(SystemName.Sensors);
            if (Systems.Weapons < maxValues && weaponsChosen < maxTimesChosen) choices.Add(SystemName.Weapons);
            if (Systems.Engines < maxValues && enginesChosen < maxTimesChosen) choices.Add(SystemName.Engines);
            if (Systems.Computers < maxValues && computersChosen < maxTimesChosen) choices.Add(SystemName.Computers);

            var pick = choices.OrderBy(n => Util.GetRandom()).First();

            if (pick == SystemName.Structure) Systems.Structure++;
            if (pick == SystemName.Comms) Systems.Comms++;
            if (pick == SystemName.Sensors) Systems.Sensors++;
            if (pick == SystemName.Weapons) Systems.Weapons++;
            if (pick == SystemName.Engines) Systems.Engines++;
            if (pick == SystemName.Computers) Systems.Computers++;
        }
    }

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
        return Talents.Any(x => x.Name == StarshipTalentName.Minelayer);
    }

    internal bool HasTractorBeam()
    {
        return Weapons.Any(x => x.Name == StarshipWeaponName.TractorBeam);
    }

    internal void AddWeapon(StarshipWeapon weapon)
    {
        Weapons.Add(weapon);
    }

    internal void AddMissionPodAttributes(MissionPod chosenMissionPod)
    {
        Systems.Comms += chosenMissionPod.Systems.Comms;
        Systems.Computers += chosenMissionPod.Systems.Computers;
        Systems.Engines += chosenMissionPod.Systems.Engines;
        Systems.Sensors += chosenMissionPod.Systems.Sensors;
        Systems.Structure += chosenMissionPod.Systems.Structure;
        Systems.Weapons += chosenMissionPod.Systems.Weapons;

        Departments.Command += chosenMissionPod.Departments.Command;
        Departments.Conn += chosenMissionPod.Departments.Conn;
        Departments.Engineering += chosenMissionPod.Departments.Engineering;
        Departments.Security += chosenMissionPod.Departments.Security;
        Departments.Medicine += chosenMissionPod.Departments.Medicine;
        Departments.Science += chosenMissionPod.Departments.Science;

        CurrentMissionPod = chosenMissionPod.Name;
    }
}
