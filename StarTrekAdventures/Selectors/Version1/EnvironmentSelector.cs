using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
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
            new Environment { Name = "Homeworld", DisciplineChoices = new CharacterDisciplines { Command = 1, Security = 1, Science = 1 }, SpeciesAttributes = true },
            new Environment { Name = "Busy Colony", AttributeChoices = new CharacterAttributes { Daring = 1, Presence = 1 }, DisciplineChoices = new CharacterDisciplines { Command = 1, Security = 1, Science = 1 } },
            new Environment { Name = "Isolated Colony", AttributeChoices = new CharacterAttributes { Reason = 1, Insight = 1 }, DisciplineChoices = new CharacterDisciplines { Engineering = 1, Science = 1, Medicine = 1 } },
            new Environment { Name = "Frontier Colony", AttributeChoices = new CharacterAttributes { Control = 1, Fitness = 1 }, DisciplineChoices = new CharacterDisciplines { Conn = 1, Security = 1, Medicine = 1 } },
            new Environment { Name = "Starship or Stabase", AttributeChoices = new CharacterAttributes { Control = 1, Insight = 1 }, DisciplineChoices = new CharacterDisciplines { Command = 1, Conn = 1, Engineering = 1 } },
            new Environment { Name = "Another Species' World", AnotherSpeciesAttributes = true, AnyDiscipline = true }
        };
    }
}
