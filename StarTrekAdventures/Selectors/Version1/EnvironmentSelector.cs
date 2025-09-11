using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class EnvironmentSelector
    {
        public static CharacterEnvironment ChooseEnvironment()
        {
            return Environments.OrderBy(n => Util.GetRandom()).First();
        }

        public static CharacterEnvironment GetEnvironment(string name)
        {
            return Environments.First(x => x.Name == name);
        }

        private static readonly List<CharacterEnvironment> Environments = new()
        {
            new CharacterEnvironment { Name = "Homeworld", DisciplineChoices = new CharacterDisciplines { Command = 1, Security = 1, Science = 1 }, SpeciesAttributes = true },
            new CharacterEnvironment { Name = "Busy Colony", AttributeChoices = new CharacterAttributes { Daring = 1, Presence = 1 }, DisciplineChoices = new CharacterDisciplines { Command = 1, Security = 1, Science = 1 } },
            new CharacterEnvironment { Name = "Isolated Colony", AttributeChoices = new CharacterAttributes { Reason = 1, Insight = 1 }, DisciplineChoices = new CharacterDisciplines { Engineering = 1, Science = 1, Medicine = 1 } },
            new CharacterEnvironment { Name = "Frontier Colony", AttributeChoices = new CharacterAttributes { Control = 1, Fitness = 1 }, DisciplineChoices = new CharacterDisciplines { Conn = 1, Security = 1, Medicine = 1 } },
            new CharacterEnvironment { Name = "Starship or Stabase", AttributeChoices = new CharacterAttributes { Control = 1, Insight = 1 }, DisciplineChoices = new CharacterDisciplines { Command = 1, Conn = 1, Engineering = 1 } },
            new CharacterEnvironment { Name = "Another Species' World", AnotherSpeciesAttributes = true, AnyDiscipline = true }
        };
    }
}
