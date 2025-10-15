using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class CareerPath
{
    public CareerPath()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string Major { get; set; }

    public string Trait { get; set; }

    public string MustSelectAttribute { get; set; }

    public ICollection<string> RandomTrait { get; set; }

    public Departments DepartmentModifiers { get; set; }

    public ICollection<string> MustTakeFocuses { get; set; }


    public ICollection<string> Focuses { get; set; }

    public int Weight { get; set; }

    public string Source { get; set; }

    public string GetName()
    {
        if (string.IsNullOrEmpty(Major))
            return Name;

        return Name + " - " + Major;
    }
}
