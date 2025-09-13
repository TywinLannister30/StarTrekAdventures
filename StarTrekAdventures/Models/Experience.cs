using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class Experience
{
    public Experience()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public string Talent { get; set; }

    public bool AnyTalent { get; set; }

    public int? MaxAttribute { get; set; }

    public int? MaxDepartment{ get; set; }

    public int Weight { get; set; }

    public string Source { get; set; }
}
