namespace StarTrekAdventures.Models;

public class Upbringing
{
    public string Name { get; set; }

    public CharacterAttributes Attributes { get; set; }

    public Departments DepartmentChoices { get; set; }

    public ICollection<string> Focuses { get; set; }

    public bool AnyDepartment { get; set; }
}
