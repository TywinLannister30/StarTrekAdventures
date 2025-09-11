namespace StarTrekAdventures.Models;

public class CareerEvent
{
    public string Name { get; set; }

    public CharacterAttributes AttributeModifierChoices { get; set; }

    public Departments DepartmentModifierChoices { get; set; }

    public List<string> Focuses { get; set; }

    public bool AnyAttribute { get; set; }

    public bool AnyDepartment { get; set; }

    public ICollection<string> GainARandomTrait { get; set; } 
}
