namespace StarTrekAdventures.Models;

public class MissionProfile
{
    public string Name { get; set; }

    public string Description { get; set; }

    public StarshipSystems Systems { get; set; }

    public bool AnyOneSystem { get; set; }

    public Departments Departments { get; set; }

    public ICollection<string> TalentChoices { get; set; }

    public int Weight { get; set; }
}
