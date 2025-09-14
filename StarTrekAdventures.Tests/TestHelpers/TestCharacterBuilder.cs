using StarTrekAdventures.Models;

namespace StarTrekAdventures.Tests.TestHelpers
{
    public static class TestCharacterBuilder
    {
        public static Character CreateBasicCharacter()
        {
            return new Character
            {
                Attributes = new CharacterAttributes
                {
                    Control = 9,
                    Daring = 9,
                    Fitness = 9,
                    Insight = 9,
                    Presence = 9,
                    Reason = 9
                },
                Departments = new Departments
                {
                    Command = 3,
                    Conn = 3,
                    Engineering = 3,
                    Security = 3,
                    Science = 3,
                    Medicine = 3
                },
                Focuses = [],
                Roles = [],
                Talents = [],
                Traits = []
            };
        }
    }
}