namespace StarTrekAdventures.Models;

public class Spaceframe
{
    public string Name { get; set; }

    public int LaunchYear { get; set; }

    public string Overview { get; set; }

    public string Capabilities { get; set; }

    public string RefitsAndVariants { get; set; }

    public ICollection<string> SuggestedMissionProfiles { get; set; }

    public string NameingConventions { get; set; }

    public ICollection<string> Traits { get; set; }

    public int Scale { get; set; }

    public StarshipSystems Systems { get; set; }

    public Departments Departments { get; set; }

    public ICollection<string> Weapons { get; set; }

    public int GrapplerCableStrength { get; set; }

    public int TractorBeamStrength { get; set; }

    public ICollection<string> Talents { get; set; }

    public ICollection<string> ChooseOneTalent { get; set; }

    public ICollection<string> SpecialRules { get; set; }

    public int Weight { get; set; }
}
