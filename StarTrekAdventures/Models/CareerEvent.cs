using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class CareerEvent
{
    public CareerEvent()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public int? YearMin { get; set; }

    public int? YearMax { get; set; }

    public CharacterAttributes AttributeModifierChoices { get; set; }

    public Departments DepartmentModifierChoices { get; set; }

    public bool RandomFocus { get; set; }

    public List<string> Focuses { get; set; }

    public bool AnyAttribute { get; set; }

    public bool AnyDepartment { get; set; }

    public ICollection<string> GainARandomTrait { get; set; }

    public string Source { get; set; }
}
