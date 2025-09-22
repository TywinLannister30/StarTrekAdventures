using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class EnvironmentSelector : IEnvironmentSelector
{
    public CharacterEnvironment ChooseEnvironment()
    {
        return Environments.OrderBy(n => Util.GetRandom()).First();
    }

    public CharacterEnvironment GetEnvironment(string name)
    {
        return Environments.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<CharacterEnvironment> GetAllEnvironments()
    {
        return Environments;
    }

    private static readonly List<CharacterEnvironment> Environments = new()
    {
        new() { Name = "Homeworld", DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesAttributes = true },
        new() { Name = "Busy Colony", AttributeChoices = new CharacterAttributes { Daring = 1, Presence = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 } },
        new() { Name = "Isolated Colony", AttributeChoices = new CharacterAttributes { Reason = 1, Insight = 1 }, DepartmentChoices = new Departments { Engineering = 1, Science = 1, Medicine = 1 } },
        new() { Name = "Frontier Colony", AttributeChoices = new CharacterAttributes { Control = 1, Fitness = 1 }, DepartmentChoices = new Departments { Conn = 1, Security = 1, Medicine = 1 } },
        new() { Name = "Starship or Stabase", AttributeChoices = new CharacterAttributes { Control = 1, Insight = 1 }, DepartmentChoices = new Departments { Command = 1, Conn = 1, Engineering = 1 } },
        new() { Name = "Another Species' World", AnotherSpeciesAttributes = true, AnyDepartment = true }
    };
}
