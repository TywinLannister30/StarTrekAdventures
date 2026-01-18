
using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class CharacterEnvironment
{
    public CharacterEnvironment()
    {
        Source = BookSource.Core;
        SpeciesHomeworld = new List<string>();
    }

    public string Name { get; set; }
    public CharacterAttributes AttributeChoices { get; set; }
    public Departments DepartmentChoices { get; set; }
    public bool SpeciesAttributes { get; set; }
    public bool AnotherSpeciesAttributes { get; set; }
    public bool AnyDepartment { get; set; }
    public List<string> SpeciesHomeworld { get; set; }
    public int Weight { get; set; }
    public string Source { get; set; }
}
