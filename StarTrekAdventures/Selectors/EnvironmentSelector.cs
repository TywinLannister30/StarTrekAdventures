using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors
{
    public static class EnvironmentSelector
    {
        public static Environment ChooseEnvironment()
        {
            return Environments.OrderBy(n => Util.GetRandom()).First();
        }

        public static Environment GetEnvironment(string name)
        {
            return Environments.First(x => x.Name == name);
        }

        private static readonly List<Environment> Environments = new List<Environment>
        {
            new Environment { Name = "Homeworld", DepartmentChoices = new CharacterDepartments { Command = 1, Security = 1, Science = 1 }, SpeciesAttributes = true },
            new Environment { Name = "Busy Colony", AttributeChoices = new CharacterAttributes { Daring = 1, Presence = 1 }, DepartmentChoices = new CharacterDepartments { Command = 1, Security = 1, Science = 1 } },
            new Environment { Name = "Isolated Colony", AttributeChoices = new CharacterAttributes { Reason = 1, Insight = 1 }, DepartmentChoices = new CharacterDepartments { Engineering = 1, Science = 1, Medicine = 1 } },
            new Environment { Name = "Frontier Colony", AttributeChoices = new CharacterAttributes { Control = 1, Fitness = 1 }, DepartmentChoices = new CharacterDepartments { Conn = 1, Security = 1, Medicine = 1 } },
            new Environment { Name = "Starship or Stabase", AttributeChoices = new CharacterAttributes { Control = 1, Insight = 1 }, DepartmentChoices = new CharacterDepartments { Command = 1, Conn = 1, Engineering = 1 } },
            new Environment { Name = "Another Species' World", AnotherSpeciesAttributes = true, AnyDepartment = true }
        };
    }
}
