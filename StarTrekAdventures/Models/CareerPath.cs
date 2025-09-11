namespace StarTrekAdventures.Models;

public class CareerPath
{
    public string Name { get; set; }

    public string Major { get; set; }

    public string Trait { get; set; }

    public string MustSelectAttribute { get; set; }

    public ICollection<string> RandomTrait { get; set; }

    public Departments DepartmentModifiers { get; set; }

    public ICollection<string> Focuses { get; set; }

    public int Weight { get; set; }

    internal string GetName()
    {
        if (string.IsNullOrEmpty(Major))
            return Name;

        return Name + " - " + Major;
    }
}
