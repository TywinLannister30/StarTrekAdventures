
using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class Hatchery
{
    public Hatchery()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }
    public CharacterAttributes Attributes { get; set; }
    public Departments DepartmentModifiers { get; set; }
    public List<string> AvailableFocuses { get; set; }
    public string Source { get; set; }
}
