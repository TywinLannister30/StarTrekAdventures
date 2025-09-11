using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class DepartmentRequirements : Departments
{
    public Operator Operator { get; set; }
}
