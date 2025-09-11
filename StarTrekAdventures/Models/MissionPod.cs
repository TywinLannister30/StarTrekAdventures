namespace StarTrekAdventures.Models;

public class MissionPod
{
    public string Name { get; set; }

    public StarshipSystems Systems { get; set; }

    public Departments Departments { get; set; }

    public ICollection<string> Talents { get; set; }

    public ICollection<string> ChooseOneTalent { get; set; }
}
