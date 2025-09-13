using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class ServiceRecord
{
    public ServiceRecord()
    {
        Source = BookSource.Core;
    }
    public string Name { get; set; }

    public string Description { get; set; }

    public string SpecialRule { get; set; }

    public string Source { get; set; }
}
